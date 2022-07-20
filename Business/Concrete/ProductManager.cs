using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICacheManager _cacheManager;
        public ProductManager(IProductDal productDal, ICacheManager cacheManager)
        {
            _productDal = productDal;
            _cacheManager = cacheManager;
        }

        [SecuredOperation("product.add,esnaf,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product, IFormFile file)
        {
            product.ImagePath = FileHelper.Add(file);
            product.AddedTime = DateTime.Now;
            product.Status = true;
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

      
        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int Id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == Id));
        }

        public IDataResult<List<ProductDetailsDto>> GetAllDtoByCategoryId(int Id)
        {
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetProductDetails(p => p.CategoryId == Id));
        }

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductID == productId));
        }

        public IDataResult<List<ProductDetailsDto>> GetDtoById(int productId)
        {
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetProductDetails(p => p.ProductId == productId));
        }

        public IDataResult<List<ProductDetailsDto>> GetProductDetails()
        {

            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetProductDetails());
        }

        public IDataResult<List<ProductDetailsDto>> GetProductDetailsBySellerId(int id)
        {
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetProductDetails(p=>p.UserId==id));
        }

        public IDataResult<List<ProductDetailsDto>> GetProductDtoByFilter(int min, int max,int id, bool artanFiyat,bool azalanFiyat,bool enYeniler)
        {

            List<ProductDetailsDto> query = _productDal.GetProductDetails();

            if (min>=0 &&max!=0)
            {
              query= query.Where(p => p.Price > min && p.Price < max).ToList();
            }
            if (id!=0)
            {
                query = query.Where(p=>p.CategoryId==id).ToList();
            }
            if (artanFiyat)
            {
                query = query.OrderBy(p=>p.Price).ToList();
            }
            if (azalanFiyat)
            {
                query = query.OrderByDescending(p => p.Price).ToList();
            }
            if (enYeniler)
            {
                query = query.OrderByDescending(p => p.AddedTime).ToList(); 
            }

            return new SuccessDataResult<List<ProductDetailsDto>>(query.ToList(),"Filtre sonucu getirildi");
            //if (id!=0)//categoryid varsa
            //{
            //    return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetProductDetails(p => p.Price > min && p.Price < max &&p.CategoryId==id), "fiyat aralığına göre getirildi");

            //}
            //else
            //{
            //    return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetProductDetails(p => p.Price > min && p.Price < max), "fiyat aralığına göre getirildi");

            //}
        }

        public IResult Hidden(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var product=_productDal.Get(x=>x.ProductID==list[i]);
                product.Status = false;
                _productDal.Update(product);
            }
            return new SuccessResult();
        }

        public IResult StarUpdate(int id, int star)
        {
            var product = _productDal.Get(x => x.ProductID == id);
            product.StarRating = star;
            _productDal.Update(product);
            return new SuccessResult("Star Güncellendi");
        }

        [SecuredOperation("product.add,esnaf,admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            product.AddedTime = DateTime.Now;
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
        [SecuredOperation("product.add,esnaf,admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult UpdateWithImage(Product product, IFormFile file)
        {
            product.ImagePath = FileHelper.Add(file);
            product.AddedTime = DateTime.Now;
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult UpdateForSell(int productId, int quantity)
        {
            var product = _productDal.Get(x => x.ProductID == productId);
            product.UnitInStock -= quantity;
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
        public IResult StokUpdate(Product product)
        {

            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        [SecuredOperation("esnaf,admin")]
        public IResult Delete(Product product)
        {
            product.Status = false;
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        [SecuredOperation("esnaf,admin")]
        public IResult Retrieve(Product product)
        {
            product.Status = true;
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductRetrieved);
        }
    }
}
