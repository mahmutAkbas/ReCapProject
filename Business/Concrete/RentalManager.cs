using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental item)
        {
            var result = CheckRental(item.RentalCarId);
            if (result.Success)
            {
                _rentalDal.Add(item);
                return new SuccessResult(Messages.Added);
            }
            return new ErrorResult(Messages.ErrorRentalAdd);
        }

        public IResult Delete(Rental item)
        {
            _rentalDal.Delete(item);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(Rental item)
        {
            _rentalDal.Update(item);
            return new SuccessResult(Messages.Updated);
        }

        public IResult CheckRental(int carId)
        {
            var result = _rentalDal.GetAll(rl => rl.RentalCarId == carId && rl.ReturnDate == DateTime.MinValue);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.ErrorRentalAdd);
            }
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Rental>>();
            }
            return new SuccessDataResult<List<Rental>>(result);
        }

        public IDataResult<Rental> Get(int id)
        {
            var result = _rentalDal.Get(r => r.RentalId == id);
            if (result == null)
            {
                return new ErrorDataResult<Rental>();
            }
            return new SuccessDataResult<Rental>(result);
        }
    }
}
