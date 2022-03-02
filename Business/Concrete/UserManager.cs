using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            var result=_userDal.Get(x=>x.UserId==user.UserId&&x.Date.Day==user.Date.Day);
            if (result!=null)
            {
                return new SuccessResult(Messages.VoteFailed);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserVoted);
            
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<User>>(Messages.CannotBeListed);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Listed);
        }

        public IDataResult<User> GetByUserId(string userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
            
        }
    }
}
