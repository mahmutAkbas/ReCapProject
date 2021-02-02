using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<CarColor> carColors;

        public InMemoryColorDal()
        {
            this.carColors = new List<CarColor> { 
                new CarColor{ColorId=1,ColorName="White"},
                new CarColor{ColorId=2,ColorName="Red"},
                new CarColor{ColorId=3,ColorName="Green"},
                new CarColor{ColorId=4,ColorName="Yellow"},
                new CarColor{ColorId=5,ColorName="Gray"},
                new CarColor{ColorId=6,ColorName="Black"},
                new CarColor{ColorId=7,ColorName="Blue"},
            };
        }

        public void Add(CarColor carColor)
        {
            carColors.Add(carColor);
        }

        public void Delete(CarColor carColor)
        {
            var result = carColors.SingleOrDefault(cc => cc.ColorId == carColor.ColorId);
            carColors.Remove(result);
        }

        public List<CarColor> GetAll()
        {
            return carColors;
        }

        public CarColor GetById(int carColor)
        {
            return carColors.SingleOrDefault(cc => cc.ColorId == carColor);
        }

        public void Update(CarColor carColor)
        {
            var result = carColors.SingleOrDefault(cc => cc.ColorId == carColor.ColorId);
            result.ColorName = carColor.ColorName;
        }
    }
}
