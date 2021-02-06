using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand item)
        {
            if (item.BrandName.Length >= 2)
            {
                _brandDal.Add(item);
            }
            else
            {
                Console.WriteLine("[Description] must be min length 2");
            }
           
        }

        public void Delete(Brand item)
        {
            _brandDal.Delete(item);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            return _brandDal.GetById(b => b.BrandId == brandId);
        }

        public void Update(Brand item)
        {
            if (item.BrandName.Length >= 2)
            {
                _brandDal.Update(item);
            }
            else
            {
                Console.WriteLine("[Description] must be min length 2");
            }
        }
   

    
    }
}
