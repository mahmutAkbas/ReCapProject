using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBrandService:IBaseService<Brand>
    {
        List<Brand> GetAll();
        Brand GetById(int brandId);
    }
}
