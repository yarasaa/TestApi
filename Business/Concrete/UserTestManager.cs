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
        IVoteLimitDal _voteLimitDal;
        


        public UserTestManager(IUserTestDal userTestDal,IVoteLimitDal voteLimitDal)
        {
            _userTestDal = userTestDal;
            _voteLimitDal = voteLimitDal;
            
        }

        public IResult Add(UserTest userTest)
        {
            userTest.Date=DateTime.Now;
            var result=_userTestDal.GetAll(x=>x.UserId==userTest.UserId&&x.Date.Day==userTest.Date.Day).ToList();
            //var result = _userTestDal.GetAll().Where(x => x.UserId == userTest.UserId && x.Date.Day == userTest.Date.Day).ToList();


            if (result.Count == 0)
            {
                var limit = _voteLimitDal.GetAll().FirstOrDefault().Limit;

                userTest.VoteLimit = limit-1;
                _userTestDal.Add(userTest);
                return new SuccessResult(Messages.VoteSuccess);
            }
            else if(result.FindLast(x=>x.UserId==userTest.UserId&&x.Date.Day==userTest.Date.Day).VoteLimit>0)
            {
                userTest.VoteLimit = result.FindLast(x => x.UserId == userTest.UserId && x.Date.Day == userTest.Date.Day).VoteLimit-1;
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
