using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBasketDal : EfEntityRepositoryBase<Basket, EsnafMagazaContext>, IBasketDal
    {
        public List<BasketDto> GetAllBasketDetails(Expression<Func<BasketDto, bool>> filter = null)
        {
            using (EsnafMagazaContext context = new EsnafMagazaContext())
            {
                var result = from b in context.Baskets
                             join p in context.Products
                             on b.ProductID equals p.ProductID
                             join u in context.Users
                             on p.UserId equals u.UserId                             
                             
                             select new BasketDto
                             {
                                 BasketId = b.BasketID,
                                 ProductId = b.ProductID,
                                 ProductName = p.ProductName,
                                 CompanyName = u.CompanyName,
                                 UserId = b.UserID,
                                 Price = p.Price,
                                 ImagePath = p.ImagePath,
                                 Quantity=b.Quantity,                                 

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public List<Basket> GetAllByUser()
        {
            throw new NotImplementedException();
        }
    }
}
