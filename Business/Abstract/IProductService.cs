using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int Id);
        IDataResult<List<ProductDetailsDto>> GetAllDtoByCategoryId(int Id);
        IDataResult<Product> GetById(int productId);
        IDataResult<List<ProductDetailsDto>> GetDtoById(int productId);
        IResult Add(Product product, IFormFile file);
        IResult Update(Product product);
        IResult UpdateWithImage(Product product, IFormFile file);
        IResult StarUpdate(int id,int star);
        IResult Hidden(List<int> list);
        IResult Delete(Product product);
        IDataResult<List<ProductDetailsDto>> GetProductDetails();
        IDataResult<List<ProductDetailsDto>> GetProductDetailsBySellerId(int id);
        IDataResult<List<ProductDetailsDto>> GetProductDtoByFilter(int min,int max,int id,bool artanFiyat,bool azalanFiyat,bool enYeniler);
        IResult UpdateForSell(int productId, int quantity);
        IResult StokUpdate(Product product);
        IResult Retrieve(Product product);
    }
}
