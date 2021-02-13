using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult Add(Color item)
        {
            if (item.ColorName.Length >= 2)
            {
                _ColorDal.Add(item);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.ErrorColor);
            }
        }

        public IResult Delete(Color item)
        {
            _ColorDal.Delete(item);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_ColorDal.GetAll());
        }

        public IDataResult<Color> GetById(int ColorId)
        {
            return new SuccessDataResult<Color>(_ColorDal.Get(cc => cc.ColorId == ColorId));
        }

        public IResult Update(Color item)
        {
            if (item.ColorName.Length >= 2)
            {
                _ColorDal.Update(item);
                return new SuccessResult(Messages.Updated);
            }
            else
            {
                return new ErrorResult(Messages.ErrorColor);
            }
        }
    }
}
