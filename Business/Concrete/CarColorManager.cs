using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _ColorDal;

        public ColorManager(IColorDal ColorDal)
        {
            _ColorDal = ColorDal;
        }

        public void Add(Color item)
        {
            if (item.ColorName.Length >= 2)
            {
                _ColorDal.Add(item);
            }
            else
            {
                Console.WriteLine("[Color] must be min length 2");
            }
        }

        public void Delete(Color item)
        {
            _ColorDal.Delete(item);
        }

        public List<Color> GetAll()
        {

            return _ColorDal.GetAll();
        }

        public Color GetById(int ColorId)
        {
            return _ColorDal.GetById(cc => cc.ColorId == ColorId);
        }

        public void Update(Color item)
        {
            if (item.ColorName.Length >= 2)
            {
                _ColorDal.Update(item);
            }
            else
            {
                Console.WriteLine("[Color] must be min length 2");
            }
        }
    }
}
