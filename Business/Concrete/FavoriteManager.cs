using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FavoriteManager : IFavoriteService
    {
        IFavoriteDal _favoriteDal;
        IProductDal _productDal;
        public FavoriteManager(IFavoriteDal favoriteDal, IProductDal productDal)
        {
            _favoriteDal = favoriteDal;
            _productDal = productDal;
        }

        public IResult Add(Favorite favorite)
        {
            var product = _productDal.Get(p => p.ProductID == favorite.ProductID);
            product.LikeNumber++;
            _productDal.Update(product);
            _favoriteDal.Add(favorite);
            return new SuccessResult(Messages.FavoriteAdded);
        }

        public IResult Delete(Favorite favorite)
        {
            var product = _productDal.Get(p => p.ProductID == favorite.ProductID);
            product.LikeNumber--;
            _productDal.Update(product);
            _favoriteDal.Delete(favorite);
            return new SuccessResult(Messages.FavoriteDeleted);
        }

        public IDataResult<List<Favorite>> GetAll(int userId)
        {
            return new SuccessDataResult<List<Favorite>>(_favoriteDal.GetAll(p => p.UserID == userId), Messages.FavoriteListed);
        }

        public IDataResult<Favorite> GetById(int favoriteId)
        {
            return new SuccessDataResult<Favorite>(_favoriteDal.Get(p => p.FavoriteID == favoriteId));
        }

        public IDataResult<Favorite> GetFavoriteForDelete(int userId, int productId)
        {
            return new SuccessDataResult<Favorite>(_favoriteDal.Get(p => p.UserID == userId && p.ProductID == productId));
        }

        public IResult Update(Favorite favorite)
        {
            _favoriteDal.Update(favorite);
            return new SuccessResult(Messages.FavoriteUpdated);
        }
    }
}
