using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User item)
        {
            _userDal.Add(item);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User item)
        {
            _userDal.Delete(item);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(User item)
        {
            _userDal.Update(item);
            return new SuccessResult(Messages.Updated);
        }
    }
}
