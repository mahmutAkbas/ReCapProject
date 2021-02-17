using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer item)
        {
            _customerDal.Add(item);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customer item)
        {
            _customerDal.Delete(item);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(Customer item)
        {
            _customerDal.Update(item);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<CustomerDetailDto>> GetAll()
        {
            var result = _customerDal.GetCustomersDetail();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CustomerDetailDto>>();
            }
            return new SuccessDataResult<List<CustomerDetailDto>>(result);
        }

        public IDataResult<CustomerDetailDto> Get(int customerId)
        {
            var result = _customerDal.GetCustomerDetail(customerId);
            if (result == null)
            {
                return new ErrorDataResult<CustomerDetailDto>();
            }
            return new SuccessDataResult<CustomerDetailDto>(result);
        }
    }
}
