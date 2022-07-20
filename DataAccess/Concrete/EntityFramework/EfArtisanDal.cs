using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfArtisanDal : EfEntityRepositoryBase<Artisan, EsnafMagazaContext>, IArtisanDal
    {
        public List<esnafOrdersDto> GetOrdersById(Expression<Func<esnafOrdersDto, bool>> filter = null)
        {
            using (EsnafMagazaContext context = new EsnafMagazaContext())
            {
                var result = from orderDetail in context.OrderDetails
                             join order in context.Orders on orderDetail.OrderId equals order.OrderId
                             join product in context.Products on orderDetail.ProductId equals product.ProductID
                             join user in context.Users on order.UserId equals user.UserId
                             join productuser in context.Users on product.UserId equals productuser.UserId

                             select new esnafOrdersDto()
                             {
                                 userId = order.UserId,
                                 AddressHead = order.AddressHead,
                                 companyName = productuser.CompanyName,
                                 CreateDate = orderDetail.CreateDate,
                                 orderId = orderDetail.OrderId,
                                 PhoneNumber = user.PhoneNumber,
                                 Price = orderDetail.Price,
                                 ProductDescription = product.ProductDescription,
                                 productID = orderDetail.ProductId,
                                 ProductImage = product.ImagePath,
                                 ProductName = product.ProductName,
                                 quantity = orderDetail.Quantity,
                                 status = orderDetail.Status,
                                 EsnafId = product.UserId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
        public List<esnafAnswerDto> GetQuastionsById(Expression<Func<esnafAnswerDto, bool>> filter = null)
        {
            using (EsnafMagazaContext context = new EsnafMagazaContext())
            {
                var result = from sellerQuastion in context.SellerQuestions
                             join user in context.Users on sellerQuastion.UserId equals user.UserId
                             join product in context.Products on sellerQuastion.ProductId equals product.ProductID

                             select new esnafAnswerDto()
                             {
                                 Id = sellerQuastion.Id,
                                 customerId = sellerQuastion.UserId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 productId = sellerQuastion.ProductId,
                                 ProductName = product.ProductName,
                                 Quastion = sellerQuastion.Question,
                                 QuastionDate = sellerQuastion.Date,
                                 sellerId = product.UserId,
                                 ProductImage = product.ImagePath,
                                 status = sellerQuastion.Status
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
