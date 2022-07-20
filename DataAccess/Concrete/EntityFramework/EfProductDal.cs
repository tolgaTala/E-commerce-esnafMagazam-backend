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
    public class EfProductDal : EfEntityRepositoryBase<Product, EsnafMagazaContext>, IProductDal
    {
        public List<ProductDetailsDto> GetProductDetails(Expression<Func<ProductDetailsDto, bool>> filter = null)
        {
            using (EsnafMagazaContext context=new EsnafMagazaContext())
            {
                
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryID
                             join u in context.Users
                             on p.UserId equals u.UserId
                             select new ProductDetailsDto { ProductId = p.ProductID,
                                 ProductName = p.ProductName,
                                 CategoryId=c.CategoryID,
                                 CategoryName=c.CategoryName,
                                 UserCompany = u.CompanyName,
                                 UserId = p.UserId,
                                 UnitInStock=p.UnitInStock,
                                 Price=p.Price,
                                 ImagePath=p.ImagePath,
                                 ProductDescription=p.ProductDescription,
                                 AddedTime=p.AddedTime,
                                 LikeNumber=p.LikeNumber,
                                 Status=p.Status,
                                 StarRating=p.StarRating
                                 
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }        

    }
}
