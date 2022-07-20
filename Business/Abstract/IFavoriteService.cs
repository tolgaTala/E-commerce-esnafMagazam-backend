using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    
        public interface IFavoriteService
        {
            IDataResult<List<Favorite>> GetAll(int userId);
            IDataResult<Favorite> GetById(int favoriteId);
            IDataResult<Favorite> GetFavoriteForDelete(int userId, int productId);

            IResult Add(Favorite favorite);
            IResult Update(Favorite favorite);
            IResult Delete(Favorite favorite);
        
    }
}
