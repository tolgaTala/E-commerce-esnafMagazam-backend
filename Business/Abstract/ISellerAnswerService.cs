using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISellerAnswerService
    {
        IResult Add(SellerAnswer sellerAnswer);
        IResult Delete(SellerAnswer sellerAnswer);
        IResult Update(SellerAnswer sellerAnswer);
        IDataResult<List<SellerAnswer>> GetAll();
        IDataResult<List<SellerAnswer>> GetAllByQId(int id);
        IDataResult<SellerAnswer> GetById(int id);
    }
}
