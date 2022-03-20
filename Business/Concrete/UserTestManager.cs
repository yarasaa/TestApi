using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;

using Entities.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserTestManager : IUserTestService
    {
        IUserTestDal _userTestDal;


        public UserTestManager(IUserTestDal userTestDal)
        {
            _userTestDal = userTestDal;
        }

        public IResult Add(UserTest userTest)
        {
            var result=_userTestDal.GetAll(x=>x.UserId==userTest.UserId&&x.Date==userTest.Date).ToList().Count;
            
            
            
            if (result<3)
            {
                _userTestDal.Add(userTest);
                return new SuccessResult(Messages.VoteSuccess);
            }
            else
            {
                return new SuccessResult(Messages.VoteFailed);
            }
            
            
        }

        public IDataResult<List<UserTest>> GetAll()
        {
            return new SuccessDataResult<List<UserTest>>(_userTestDal.GetAll(), Messages.Listed);
        }

        public IResult Update(UserTest userTest)
        {
            throw new NotImplementedException();
        }
    }
}
