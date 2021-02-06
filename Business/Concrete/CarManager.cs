using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarManager : IBaseService<Car>, ICarService
    {
        ICarDal _carDal;
        IColorDal _ColorDal;
        IBrandDal _brandDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public CarManager(ICarDal carDal, IColorDal ColorDal, IBrandDal brandDal)
        {
            _carDal = carDal;
            _ColorDal = ColorDal;
            _brandDal = brandDal;
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

        public List<CarJoin> GetAll()
        {
            return (from c in _carDal.GetAll()
                    join cc in _ColorDal.GetAll() on c.ColorId equals cc.ColorId
                    join b in _brandDal.GetAll() on c.BrandId equals b.BrandId
                    select new CarJoin { CarId = c.CarId, ColorName = cc.ColorName, BrandName = b.BrandName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, CarDescription = c.CarDescription }).ToList();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _carDal.GetAll().Where(cc => cc.BrandId == brandId).ToList();
        }

        public CarJoin GetByCarId(int carId)
        {
            return (from c in _carDal.GetAll()
                    join cc in _ColorDal.GetAll() on c.ColorId equals cc.ColorId
                    join b in _brandDal.GetAll() on c.BrandId equals b.BrandId
                    where c.CarId==carId
                    select new CarJoin { CarId = c.CarId, ColorName = cc.ColorName, BrandName = b.BrandName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, CarDescription = c.CarDescription }).First();
        }

        public List<Car> GetByColorId(int colorId)
        {
            return _carDal.GetAll(cc => colorId == cc.ColorId);
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
