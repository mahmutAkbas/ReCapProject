using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService : IBaseService<Customer>
    {
        IDataResult<List<CustomerDetailDto>> GetAll();
        IDataResult<CustomerDetailDto> Get(int customerId);
    }
}
