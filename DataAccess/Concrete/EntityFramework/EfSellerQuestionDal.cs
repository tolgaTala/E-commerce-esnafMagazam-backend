using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSellerQuestionDal : EfEntityRepositoryBase<SellerQuestion, EsnafMagazaContext>, ISellerQuestionDal
    {
        public List<QuestionAndAnswerDto> GetQustionAndAnswerDto(Expression<Func<QuestionAndAnswerDto, bool>> filter = null)
        {
            using (EsnafMagazaContext context = new EsnafMagazaContext())
            {

                var result = from q in context.SellerQuestions
                             join a in context.SellerAnswers
                             on q.Id  equals a.QuestionId
                             
                             select new QuestionAndAnswerDto
                             {
                                 QuestionId=q.Id,
                                 AnswerId=a.Id,
                                 Answer=a.Answer,
                                 Question=q.Question,
                                 ProductId=q.ProductId,
                                 SellerId=a.UserId,
                                 UserId=q.UserId,
                                 AnswerDate=a.Date,
                                 QuestionDate=q.Date

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
