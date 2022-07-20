using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SellerQuestionManager : ISellerQuestionService
    {
        ISellerQuestionDal _sellerQustionDal;

        public SellerQuestionManager(ISellerQuestionDal sellerQuestion)
        {
            _sellerQustionDal = sellerQuestion;
        }
        public IResult Add(SellerQuestion entity)
        {
            entity.Date = DateTime.Now;
            _sellerQustionDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(SellerQuestion entity)
        {
            _sellerQustionDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<SellerQuestion>> GetAll()
        {
            return new SuccessDataResult<List<SellerQuestion>>(_sellerQustionDal.GetAll());
        }

        public IDataResult<List<SellerQuestion>> GetAllByProductId(int id)
        {
            return new SuccessDataResult<List<SellerQuestion>>(_sellerQustionDal.GetAll(s=>s.ProductId==id));
        }

        public IDataResult<List<QuestionAndAnswerDto>> GetAllDto()
        {
            return new SuccessDataResult<List<QuestionAndAnswerDto>>(_sellerQustionDal.GetQustionAndAnswerDto());
        }

        public IDataResult<SellerQuestion> GetById(int id)
        {
            return new SuccessDataResult<SellerQuestion>(_sellerQustionDal.Get(s=>s.Id==id));
        }

        public IResult Update(SellerQuestion entity)
        {
            _sellerQustionDal.Update(entity);
            return new SuccessResult();
        }
    }
}
