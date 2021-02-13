using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand item)
        {
            if (item.BrandName.Length >= 2)
            {
                _brandDal.Update(item);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.ErrorBrand);
            }

        }

        public IResult Delete(Brand item)
        {
            _brandDal.Delete(item);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId));
        }

        public IResult Update(Brand item)
        {
            if (item.BrandName.Length >= 2)
            {
                _brandDal.Update(item);
                return new SuccessResult(Messages.Updated);
            }
            else
            {
                return new ErrorResult(Messages.ErrorBrand);
            }
        }



    }
}
