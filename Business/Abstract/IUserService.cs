using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        List<OperationClaim> GetClaims(User user);
        IResult Add(User user);
        IDataResult<User> GetByMail(string email);
        IResult Update(User user);
        IResult Hidden(List<int> list);
        IResult Delete(User user);
        IDataResult<User> GetById(int userId);
        IResult ChangePasswd(int userId, string oldPwd, string newPwd);
    }
}
