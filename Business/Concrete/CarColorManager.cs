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
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color item)
        {
            if (item.ColorName.Length >= 2)
            {
                _colorDal.Add(item);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.ErrorColor);
            }
        }

        public IResult Delete(Color item)
        {
            _colorDal.Delete(item);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(cc => cc.ColorId == colorId));
        }

        public IResult Update(Color item)
        {
            if (item.ColorName.Length >= 2)
            {
                _colorDal.Update(item);
                return new SuccessResult(Messages.Updated);
            }
            else
            {
                return new ErrorResult(Messages.ErrorColor);
            }
        }
    }
}
