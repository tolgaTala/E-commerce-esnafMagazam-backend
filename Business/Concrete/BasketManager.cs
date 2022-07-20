using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class BasketManager:IBasketService
    {
        IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public IResult Add(Basket basket)
        {
            var baskets = _basketDal.GetAll(p=>p.UserID==basket.UserID);
      
            foreach (var sepet in baskets)
            {
                if (sepet.ProductID==basket.ProductID)
                {
                    sepet.Quantity++;
                    _basketDal.Update(sepet);
                    return new SuccessResult(Messages.BasketAdded);
                }
            }
            _basketDal.Add(basket);
            return new SuccessResult(Messages.BasketAdded);
        }

        public IResult Delete(Basket basket)
        {
            _basketDal.Delete(basket);
            return new SuccessResult(Messages.BasketDeleted);
        }

        public IDataResult<List<Basket>> GetAll()
        {
            return new SuccessDataResult<List<Basket>>(_basketDal.GetAll(),Messages.BasketListed);
        }

        public IDataResult<List<BasketDto>> GetAllBasketDetails()
        {
            return new SuccessDataResult<List<BasketDto>>(_basketDal.GetAllBasketDetails(),"Basket DTO Getirildi");
        }
        public IDataResult<List<BasketDto>> GetAllBasketDetailsByUser(int userId)
        {
            return new SuccessDataResult<List<BasketDto>>(_basketDal.GetAllBasketDetails(p=>p.UserId==userId), "Basket DTO Getirildi");
        }

        public IDataResult<Basket> GetById(int basketId)
        {
            return new SuccessDataResult<Basket>(_basketDal.Get(p=>p.BasketID==basketId));
        }

        public IResult Update(Basket basket)
        {
            _basketDal.Update(basket);
            return new SuccessResult();
        }
    }
}
