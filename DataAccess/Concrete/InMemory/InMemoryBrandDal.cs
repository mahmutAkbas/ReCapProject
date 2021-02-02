using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<Brand> GetAll()
        {
            return brands;
        }

        public Brand GetById(int brandId)
        {
          return  brands.SingleOrDefault(b => b.BrandId == brandId);
        }

        public void Update(Brand brand)
        {
            var result = brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            result.BrandName = brand.BrandName;
        }
    }
}
