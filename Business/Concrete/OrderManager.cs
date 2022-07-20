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
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IResult Add(Order order)
        {
            order.OrderDate = DateTime.Now;
            _orderDal.Add(order);
            return new SuccessResult();
        }


        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult();
        }

        public IDataResult<Order> Get(int id)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(o=>o.OrderId==id)) ;
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
        }

        public IDataResult<List<Order>> GetAllByUserId(int id)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(o=>o.UserId==id));
        }

        public IDataResult<int> GetByIdAdd(Order order)
        {
            order.OrderDate = DateTime.Now;
            _orderDal.Add(order);
            return new SuccessDataResult<int>(order.OrderId,"Order Id geldi");
        }

        public IResult Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
