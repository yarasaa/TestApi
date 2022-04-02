using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        IUserDal _userDal;
        



        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
            

        }

        public IDataResult<List<User>> GetAll()
        {
            
            
            return new SuccessDataResult<List<User>>(_userDal.GetAll(x=>x.SicilNo=="5283"), Messages.Listed);
        }
    }
}
