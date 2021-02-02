using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : IBaseService<Car>,ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car item)
        {
            _carDal.Add(item);
        }

        public void Delete(Car item)
        {
            _carDal.Delete(item);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _carDal.GetAll().Where(cc => cc.BrandId == brandId).ToList();
        }

        public Car GetByCarId(int carId)
        {
            return _carDal.GetById(carId);
        }

        public List<Car> GetByColorId(int colorId)
        {
            return _carDal.GetAll().Where(cc => cc.ColorId == colorId).ToList();
        }

        public void Update(Car item)
        {
            _carDal.Update(item);
        }
    }
}
