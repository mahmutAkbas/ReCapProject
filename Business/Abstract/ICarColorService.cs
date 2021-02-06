using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IColorService:IBaseService<Color>
    {
        List<Color> GetAll();
        Color GetById(int ColorId);
    }
}
