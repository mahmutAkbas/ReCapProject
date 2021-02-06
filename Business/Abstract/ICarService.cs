using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<CarJoin> GetAll();
        List<Car> GetByColorId(int colorId);
        List<Car> GetByBrandId(int brandId);
        CarJoin GetByCarId(int carId);
    }
}
