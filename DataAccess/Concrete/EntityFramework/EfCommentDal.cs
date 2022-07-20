using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
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
    public class EfCommentDal : EfEntityRepositoryBase<Comment, EsnafMagazaContext>, ICommentDal
    {
        public List<CommentDto> GetCommentDtoByProductId(Expression<Func<CommentDto, bool>> filter )
        {
            using (EsnafMagazaContext context = new EsnafMagazaContext())
            {
                var result = from c in context.Comments
                             join p in context.Products
                             on c.ProductID equals p.ProductID
                             join u in context.Users
                             on c.UserID equals u.UserId
                             select new CommentDto
                             {
                                 ProductId = p.ProductID,
                                 UserID = u.UserId,
                                 CommentContent=c.CommentContent,
                                 CommentDate=c.CommentDate,
                                 CommentHeading = c.CommentHeading,
                                 CommentID = c.CommentID,
                                 FirstName = u.FirstName,
                                 LastName=u.LastName,
                                 ProductName = p.ProductName,
                                 Status = c.Status,
                                 CompanyName=u.CompanyName,
                                 Score = c.Score



                             }; return (filter == null ? result.ToList() : result.Where(filter).ToList());
            }
        }
    }
}
