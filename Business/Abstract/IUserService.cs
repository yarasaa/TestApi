﻿using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {

        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        IResult Delete(User user);
        IDataResult<User> GetByUserId(string userId);
        
        
    }
}
