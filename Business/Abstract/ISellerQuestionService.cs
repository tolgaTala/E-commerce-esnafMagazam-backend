using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISellerQuestionService
    {
        IResult Add(SellerQuestion entity);
        IResult Delete(SellerQuestion entity);
        IResult Update(SellerQuestion entity);
        IDataResult<List<SellerQuestion>> GetAll();
        IDataResult<SellerQuestion> GetById(int id);
        IDataResult<List<SellerQuestion>> GetAllByProductId(int id);
        IDataResult<List<QuestionAndAnswerDto>> GetAllDto();
    }
}
