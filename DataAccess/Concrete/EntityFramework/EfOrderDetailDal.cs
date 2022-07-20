using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDetailDal : EfEntityRepositoryBase<OrderDetail, EsnafMagazaContext>, IOrderDetailDal
    {
        public List<OrderDetailDto> GetOrderDetailDto(Expression<Func<OrderDetailDto, bool>> filter = null)
        {
            using (EsnafMagazaContext context=new EsnafMagazaContext())
            {
                var result = from orderDetail in context.OrderDetails
                             join order in context.Orders on orderDetail.OrderId equals order.OrderId
                             join product in context.Products on orderDetail.ProductId equals product.ProductID                             
                             join user in context.Users on order.UserId equals user.UserId   
                             join productuser in context.Users on product.UserId equals productuser.UserId
                             
                             select new OrderDetailDto()
                             {
                                 OrderId = order.OrderId,
                                 OrderDetailId=orderDetail.Id,
                                 ProductId = orderDetail.ProductId,
                                 UserId = order.UserId,
                                 ProductName = product.ProductName,
                                 ProductImage=product.ImagePath,
                                 Price = orderDetail.Price,
                                 OrderDate = order.OrderDate,
                                 Quantity = orderDetail.Quantity,
                                 AddressHead=order.AddressHead,
                                 Status=orderDetail.Status,
                                 ProductDescription=product.ProductDescription,
                                 CompanyName=productuser.CompanyName
                              };
                return filter == null ? result.ToList() :  result.Where(filter).ToList();
            }
        }
    }
}
