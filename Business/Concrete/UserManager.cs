using Business.Abstract;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        

        public UserManager(IUserDal userDal )
        {
            _userDal = userDal;
        }
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IResult Add(User user)
        {
            user.Status = true;
            user.CreateDate = DateTime.Now;
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>( _userDal.Get(u => u.Email == email));
        }

        public IResult ChangePasswd(int userId, string oldPwd, string newPwd)
        {
            var user = _userDal.Get(p => p.UserId == userId);



            if (HashingHelper.VerifyPasswordHash(oldPwd, user.PasswordHash, user.PasswordSalt))
            {
                byte[] passwordHash1, passwordSalt1;
                HashingHelper.CreatePasswordHash(newPwd, out passwordHash1, out passwordSalt1);
                user.PasswordHash = passwordHash1;
                user.PasswordSalt = passwordSalt1;
                _userDal.Update(user);
                return new SuccessResult(Messages.ChangeSuccess);
            }
            else
            {
                return new ErrorResult(Messages.WrongPasswd);
            }

        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.UserId == userId));
        }

        public IResult Update(User user)
        {
            user.CreateDate = DateTime.Now;
            var user1 = _userDal.Get(p=>p.UserId==user.UserId);
            user.PasswordHash = user1.PasswordHash;
            user.PasswordSalt = user1.PasswordSalt;
            _userDal.Update(user);
            return new SuccessResult("Kullanıcı Güncellendi");
        }
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IResult Hidden(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var user = _userDal.Get(x => x.UserId == list[i]);
                user.Status = false;
                _userDal.Update(user);
            }
            return new SuccessResult("Başarıyla Gizlendi");
        }
    }
}
