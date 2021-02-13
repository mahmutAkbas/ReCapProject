using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IColorService : IBaseService<Color>
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int ColorId);
    }
}
