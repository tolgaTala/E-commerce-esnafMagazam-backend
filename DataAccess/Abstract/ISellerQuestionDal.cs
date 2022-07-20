using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ISellerQuestionDal : IEntityRepository<SellerQuestion>
    {
        List<QuestionAndAnswerDto> GetQustionAndAnswerDto(Expression<Func<QuestionAndAnswerDto, bool>> filter = null);
    }
}
