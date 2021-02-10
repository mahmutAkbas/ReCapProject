using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> brands;

        public InMemoryBrandDal()
        {
            this.brands = new List<Brand> {
            new Brand{ BrandId=1,BrandName="Tofaş" },
            new Brand{ BrandId=2,BrandName="Ford" },
            new Brand{ BrandId=3,BrandName="Volkwagen" },
            new Brand{ BrandId=4,BrandName="Volvo" },
            new Brand{ BrandId=5,BrandName="Renault" },
            new Brand{ BrandId=6,BrandName="Opel" },
            };
        }

        public void Add(Brand brand)
        {
            brands.Add(brand);
        }

        public void Delete(Brand brand)
        {
            var result = brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            brands.Remove(result);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            return brands;
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Brand GetById(int brandId)
        {
          return  brands.SingleOrDefault(b => b.BrandId == brandId);
        }

        public Brand GetById(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand brand)
        {
            var result = brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            result.BrandName = brand.BrandName;
        }
    }
}
