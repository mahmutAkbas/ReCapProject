﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IResult Add(Car item)
        {
            if (item.CarDescription.Length >= 2)
            {
                if (item.DailyPrice > 0)
                {
                    _carDal.Add(item);
                    return new SuccessResult(Messages.Added);
                }
                else
                {
                    return new ErrorResult(Messages.ErorrDailyPrice);
                }

            }
            else
            {
                return new ErrorResult(Messages.ErrorDescription);
            }
        }

        public IResult Delete(Car item)
        {
            _carDal.Delete(item);
            return new SuccessResult(Messages.Deleted);
        }
        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll().Where(cc => cc.BrandId == brandId).ToList());
        }
        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(cc => colorId == cc.ColorId));
        }

        public IDataResult<CarDetailDto> GetCarDetailByCarId(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailsByCarId(carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Update(Car item)
        {
            if (item.CarDescription.Length >= 2)
            {
                if (item.DailyPrice > 0)
                {
                    _carDal.Update(item);
                    return new SuccessResult(Messages.Updated);
                }
                else
                {
                    return new ErrorResult(Messages.ErorrDailyPrice);
                }
            }
            else
            {
                return new ErrorResult(Messages.ErrorDescription);
            }
        }
    }
}
