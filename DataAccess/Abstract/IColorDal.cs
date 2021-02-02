using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IColorDal
    {
        void Add(CarColor carColor);
        void Update(CarColor carColor);
        void Delete(CarColor carColor);
        List<CarColor> GetAll();
        CarColor GetById(int carColor);
    }
}
