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
    public class UserInfoManager : IUserInfoService
    {
        IUserInfoDal _userInfoDal;

        public UserInfoManager(IUserInfoDal userInfoDal)
        {
            _userInfoDal = userInfoDal;

        }


        public IResult Add(UserInfo userInfo)
        {
            var result =_userInfoDal.GetAll(x=>x.UserId == userInfo.UserId).ToList();
            if (result.Count!=0)
            {
                return new SuccessResult(Messages.UserInfoCheck);
            }
            else
            {
                _userInfoDal.Add(userInfo);
                return new SuccessResult(Messages.UserInfoAdd);
            }
        }

        public IDataResult<UserInfo> GetAll(string sicilNo)
        {
            UserInfo userInfo = _userInfoDal.GetAll(x=>x.UserId==sicilNo).FirstOrDefault();
            return new SuccessDataResult<UserInfo>(userInfo,Messages.Listed);
        }
    }
}
