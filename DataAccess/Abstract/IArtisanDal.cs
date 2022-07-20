using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IArtisanDal : IEntityRepository<Artisan>
    {
        List<esnafOrdersDto> GetOrdersById(Expression<Func<esnafOrdersDto, bool>> filter = null);
        List<esnafAnswerDto> GetQuastionsById(Expression<Func<esnafAnswerDto, bool>> filter = null);
    }
}
