using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

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

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<User>>();
            }
            return new SuccessDataResult<List<User>>(result);
        }

        public IDataResult<User> Get(int userId)
        {
            var result = _userDal.Get(u => u.UserId == userId);
            if (result == null)
            {
                return new ErrorDataResult<User>();
            }
            return new SuccessDataResult<User>(result);
        }
    }
}
