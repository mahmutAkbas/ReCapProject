using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

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
    }
}
