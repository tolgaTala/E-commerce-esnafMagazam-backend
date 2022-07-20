using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAll();
        IDataResult<List<Order>> GetAllByUserId(int id);
        IDataResult<Order> Get(int id);
        IDataResult<int> GetByIdAdd(Order order);
        IResult Add(Order order);
        IResult Delete(Order order);
        IResult Update(Order order);

    }
}
