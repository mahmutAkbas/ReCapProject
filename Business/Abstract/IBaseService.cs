using System.Collections.Generic;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IBaseService<T>
    {
        IResult Add(T item);
        IResult Delete(T item);
        IResult Update(T item);

    }
}
