using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentalService : IBaseService<Rental>
    {
        IResult CheckRental(int carId);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> Get(int id);
    }
}
