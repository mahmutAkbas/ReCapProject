using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentalService : IBaseService<Rental>
    {
        IResult CheckRental(int carId);
    }
}
