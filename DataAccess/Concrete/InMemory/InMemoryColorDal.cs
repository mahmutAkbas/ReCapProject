using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> Colors;

        public InMemoryColorDal()
        {
            this.Colors = new List<Color> { 
                new Color{ColorId=1,ColorName="White"},
                new Color{ColorId=2,ColorName="Red"},
                new Color{ColorId=3,ColorName="Green"},
                new Color{ColorId=4,ColorName="Yellow"},
                new Color{ColorId=5,ColorName="Gray"},
                new Color{ColorId=6,ColorName="Black"},
                new Color{ColorId=7,ColorName="Blue"},
            };
        }

        public void Add(Color Color)
        {
            Colors.Add(Color);
        }

        public void Delete(Color Color)
        {
            var result = Colors.SingleOrDefault(cc => cc.ColorId == Color.ColorId);
            Colors.Remove(result);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll()
        {
            return Colors;
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Color GetById(int Color)
        {
            return Colors.SingleOrDefault(cc => cc.ColorId == Color);
        }

        public Color GetById(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Color Color)
        {
            var result = Colors.SingleOrDefault(cc => cc.ColorId == Color.ColorId);
            result.ColorName = Color.ColorName;
        }
    }
}
