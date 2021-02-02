using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public interface IBaseService<T>
    {
        void Add(T item);
        void Delete(T item);
        void Update(T item);
    }
}
