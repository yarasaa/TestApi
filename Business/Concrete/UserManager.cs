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
            var result = _userDal.Get(x => x.UserId == user.UserId&&x.VoteAfterAm>3&&x.Date==user.Date);
            var result2= _userDal.Get(x => x.UserId == user.UserId/* && x.VoteAfterAm == null*/);
            //var result2=_userDal.Get(x=>x.VoteBeforeAm)
            if (result != null)
            {
                return new SuccessResult(Messages.VoteFailed);
            }
            else if(result2 != null)
            {
                result2.VoteAfterAm = user.VoteAfterAm;
                _userDal.Update(result2 as User);
                
                return new SuccessResult(Messages.VoteAfterAm);
            }
            else
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.VoteBeforeAm);
            }
            

            
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<User>>(Messages.CannotBeListed);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Listed);
        }

        public IDataResult<User> GetByUserId(string userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
            
        }

        public IResult Update(User user)
        {
            

            throw new NotImplementedException();

        }
    }
}
