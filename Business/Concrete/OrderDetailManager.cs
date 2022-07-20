using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public IResult Add(OrderDetail order)
        {
            _orderDetailDal.Add(order);
            return new SuccessResult();
        }

        public IDataResult<List<OrderDetailDto>> CheckBuyOrder(int productId, int userId)
        {
            return new SuccessDataResult<List<OrderDetailDto>>(_orderDetailDal.GetOrderDetailDto(o=>o.ProductId==productId&&o.UserId==userId));
        }

        public IResult Delete(OrderDetail order)
        {
            _orderDetailDal.Delete(order);
            return new SuccessResult();
        }

        public IDataResult<OrderDetail> Get(int id)
        {
            return new SuccessDataResult<OrderDetail>(_orderDetailDal.Get(o=>o.Id==id));
        }

        public IDataResult<List<OrderDetail>> GetAll()
        {
            return new SuccessDataResult<List<OrderDetail>>(_orderDetailDal.GetAll());
        }

        public IDataResult<List<OrderDetailDto>> GetAllOrderDetailsByUserId(int id)
        {
            return new SuccessDataResult<List<OrderDetailDto>>(_orderDetailDal.GetOrderDetailDto(o=>o.UserId==id));
        }

        public IDataResult<List<OrderDetailDto>> GetOrderDetailDto()
        {
            
            return new SuccessDataResult<List<OrderDetailDto>>(_orderDetailDal.GetOrderDetailDto());
        }

        //public IDataResult<List<OrderDetail>> GetOrderDetailsByOrderId(int id)
        //{
            
        //    return new SuccessDataResult<List<OrderDetail>>(_orderDetailDal.GetAll(o=>o.OrderId==id));
        //}

        public IDataResult<List<OrderDetailDto>> GetOrderDetailsDtoByOrderId(int id)
        {
            return new SuccessDataResult<List<OrderDetailDto>>(_orderDetailDal.GetOrderDetailDto(o=>o.OrderId==id));
        }

        public IResult ListAdd(OrderDetail[] orderDetails)
        {
            foreach (var item in orderDetails)
            {
                item.CreateDate = DateTime.Now;
                _orderDetailDal.Add(item);
            }

            return new SuccessResult();
        }

        public IResult Update(OrderDetail order)
        {
            _orderDetailDal.Update(order);
            return new SuccessResult();
        }

        public IDataResult<OrderDetail> GetOrderDetailsByOrderId(int id, int productId)
        {

            return new SuccessDataResult<OrderDetail>(_orderDetailDal.Get(o => o.OrderId == id && o.ProductId == productId));
        }
    }
}
