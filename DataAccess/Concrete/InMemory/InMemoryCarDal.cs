using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> cars;

        public InMemoryCarDal()
        {
            this.cars = new List<Car> {
            new Car{CarId=1,ColorId=1,BrandId=1,ModelYear=1992,DailyPrice=50,Description="Şahin Modeifiyeli"},
                new Car{CarId=2,ColorId=2,BrandId=2,ModelYear=2010,DailyPrice=75,Description="Ford Focus"},
                            new Car{CarId=3,ColorId=3,BrandId=5,ModelYear=2021,DailyPrice=250,Description="Volvo XC40"},
                new Car{CarId=4,ColorId=5,BrandId=3,ModelYear=2016,DailyPrice=200,Description="Volkwagen Passat"}
            };
        }

        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            var result = cars.SingleOrDefault(c => c.CarId == car.CarId);
            cars.Remove(result);
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public Car GetById(int carId)
        {
            return cars.SingleOrDefault(c => c.CarId == carId);
        }

        public void Update(Car car)
        {
            var result = cars.SingleOrDefault(c => c.CarId == car.CarId);
            result.BrandId = car.BrandId;
            result.ColorId = car.ColorId;
            result.DailyPrice = car.DailyPrice;
            result.Description = car.Description;
            result.ModelYear = car.ModelYear;
        }
    }
}
