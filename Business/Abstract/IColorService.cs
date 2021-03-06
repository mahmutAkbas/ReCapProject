﻿using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IColorService : IBaseService<Color>
    {
        IDataResult<Color> GetById(int colorId);
        IDataResult<List<Color>> GetAll();
    }
}
