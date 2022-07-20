using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SellerAnswerManager : ISellerAnswerService
    {
        ISellerAnswerDal _sellerAnswerDal;
        ISellerQuestionDal _sellerQuestionDal;
        public SellerAnswerManager(ISellerAnswerDal sellerAnswerDal, ISellerQuestionDal sellerQuestionDal)
        {
            _sellerAnswerDal = sellerAnswerDal;
            _sellerQuestionDal = sellerQuestionDal;
        }

        public IResult Add(SellerAnswer sellerAnswer)
        {
            //sellerAnswer.Date = DateTime.Now;
            //_sellerAnswerDal.Add(sellerAnswer);
            //return new SuccessResult();

            var question = _sellerQuestionDal.Get(x => x.Id == sellerAnswer.QuestionId);
            question.Status = true;
            _sellerQuestionDal.Update(question);
            sellerAnswer.Date = DateTime.Now;
            _sellerAnswerDal.Add(sellerAnswer);
            return new SuccessResult();
        }

        public IResult Delete(SellerAnswer sellerAnswer)
        {
            _sellerAnswerDal.Delete(sellerAnswer);
            return new SuccessResult();
        }

        public IDataResult<List<SellerAnswer>> GetAll()
        {
            return new SuccessDataResult<List<SellerAnswer>>(_sellerAnswerDal.GetAll());
        }

        public IDataResult<List<SellerAnswer>> GetAllByQId(int id)
        {
            return new SuccessDataResult<List<SellerAnswer>>(_sellerAnswerDal.GetAll(s=>s.QuestionId==id));
        }

        public IDataResult<SellerAnswer> GetById(int id)
        {
            return new SuccessDataResult<SellerAnswer>(_sellerAnswerDal.Get(s=>s.Id==id));
        }

        public IResult Update(SellerAnswer sellerAnswer)
        {
            _sellerAnswerDal.Update(sellerAnswer);
            return new SuccessResult();
        }
    }
}
