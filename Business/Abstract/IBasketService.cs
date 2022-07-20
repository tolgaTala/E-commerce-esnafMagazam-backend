using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBasketService
    {
        IDataResult<List<Basket>> GetAll();
        IDataResult<List<BasketDto>> GetAllBasketDetails();
        IDataResult<List<BasketDto>> GetAllBasketDetailsByUser(int UserId);
        IDataResult<Basket> GetById(int basketId);
        IResult Add(Basket basket);
        IResult Update(Basket basket);
        IResult Delete(Basket basket);
    }
}
