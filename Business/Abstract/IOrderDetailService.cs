using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderDetailService
    {
        IDataResult<List<OrderDetail>> GetAll();
        IDataResult<OrderDetail> Get(int id);
        //IDataResult<List<OrderDetail>> GetOrderDetailsByOrderId(int id);
        IDataResult<OrderDetail> GetOrderDetailsByOrderId(int id, int productId);
        IResult ListAdd(OrderDetail[] orderDetails);
        IDataResult<List<OrderDetailDto>> GetOrderDetailDto();
        IDataResult<List<OrderDetailDto>> GetAllOrderDetailsByUserId(int id);

        IDataResult<List<OrderDetailDto>> CheckBuyOrder(int productId, int userId);
        IDataResult<List<OrderDetailDto>> GetOrderDetailsDtoByOrderId(int id);
        IResult Add(OrderDetail order);
        IResult Delete(OrderDetail order);
        IResult Update(OrderDetail order);
    }
}
