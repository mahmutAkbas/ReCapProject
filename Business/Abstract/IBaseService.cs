using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public interface IBaseService<T>
    {
        IResult Add(T item);
        IResult Delete(T item);
        IResult Update(T item);
    }
}
