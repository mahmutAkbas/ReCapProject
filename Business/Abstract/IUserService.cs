using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService : IBaseService<User>
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> Get(int userId);
    }
}
