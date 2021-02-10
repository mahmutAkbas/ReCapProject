using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarManager : IBaseService<Car>, ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car item)
        {
            if (item.CarDescription.Length >= 2)
            {
                if (item.DailyPrice > 0)
                {
                    _carDal.Add(item);
                }
                else
                {
                    Console.WriteLine("[Daily Price] must be bigger then 0");
                }

            }
            else
            {
                Console.WriteLine("[Description] must be min length 2");
            }
        }

        public void Delete(Car item)
        {
            _carDal.Delete(item);
        }

        public List<Car> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _carDal.GetAll().Where(cc => cc.BrandId == brandId).ToList();
        }

        public List<Car> GetByColorId(int colorId)
        {
            return _carDal.GetAll(cc => colorId == cc.ColorId);
        }

        public CarDetailDto GetCarDetailByCarId(int carId)
        {
            return _carDal.GetCarDetailsByCarId(carId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car item)
        {
            if (item.CarDescription.Length >= 2)
            {
                if (item.DailyPrice > 0)
                {
                    _carDal.Update(item);
                }
                else
                {
                    Console.WriteLine("[Daily Price] must be bigger then 0");
                }

            }
            else
            {
                Console.WriteLine("[Description] must be min length 2");
            }

        }
    }
}
