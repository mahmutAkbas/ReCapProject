using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext reCapContext = new ReCapContext())
            {
                var result = from c in reCapContext.Cars
                             join b in reCapContext.Brands on c.BrandId equals b.BrandId
                             join cc in reCapContext.Colors on c.ColorId equals cc.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = cc.ColorName,
                                 CarDescription = c.CarDescription,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear
                             };
                return result.ToList();
            }
        }

        public CarDetailDto GetCarDetailsByCarId(int carId)
        {
            using (ReCapContext reCapContext = new ReCapContext())
            {
                var result = (from c in reCapContext.Cars
                              join b in reCapContext.Brands on c.BrandId equals b.BrandId
                              join cc in reCapContext.Colors on c.ColorId equals cc.ColorId
                              select new CarDetailDto
                              {
                                  CarId = c.CarId,
                                  BrandName = b.BrandName,
                                  ColorName = cc.ColorName,
                                  CarDescription = c.CarDescription,
                                  DailyPrice = c.DailyPrice,
                                  ModelYear = c.ModelYear
                              }).SingleOrDefault(c => c.CarId == carId);
                return result;
            }
        }
    }
}
