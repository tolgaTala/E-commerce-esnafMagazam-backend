
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getalldto")]
        public IActionResult GetAllDto()
        {
            var result = _productService.GetProductDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetDtoById(int id)
        {
            var result = _productService.GetDtoById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbycategoryid")]
        public IActionResult GetAllByCategoryId(int id)
        {
            var result = _productService.GetAllDtoByCategoryId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add([FromForm] Product product, [FromForm(Name = ("Image"))] IFormFile file)
        {
            var result = _productService.Add(product,file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("updateImage")]
        public IActionResult UpdateImage([FromForm] Product product, [FromForm(Name = ("Image"))] IFormFile file)
        {
            var result = _productService.UpdateWithImage(product, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpPost("delete")]
        //public IActionResult Delete(int id)
        //{
        //    var product = _productService.GetById(id);
        //    var result = _productService.Delete(product.Data);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}


        [HttpGet("getproductsdtobyfilter")]
        public IActionResult GetProductDtoByFilter(int min, int max, int id, bool artanFiyat,bool azalanFiyat,bool enYeniler)
        {
            var result = _productService.GetProductDtoByFilter(min,max,id,artanFiyat, azalanFiyat, enYeniler);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdtobysellerid")]
        public IActionResult GetDtoBySellerId(int id)
        {
            var result = _productService.GetProductDetailsBySellerId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("hidden")]
        public IActionResult Hidden(List<int> list)
        {
            var result = _productService.Hidden(list);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("starupdate")]
        public IActionResult StarUpdate(int id,int star)
        {
            var result = _productService.StarUpdate(id, star);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpPost("update")]
        //public IActionResult Update([FromForm] Product product, [FromForm(Name = ("Image"))] IFormFile file)
        //{
        //    var result = _productService.Update(product, file);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        [HttpPost("updateforsell")]
        public IActionResult UpdateForSell(int productId, int quantity)
        {
            var result = _productService.UpdateForSell(productId, quantity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("updatestok")]
        public IActionResult UpdateStok(int id, int stok)
        {
            var product = _productService.GetById(id);
            product.Data.UnitInStock = stok;
            var result = _productService.StokUpdate(product.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("deleteid")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);
            var result = _productService.Delete(product.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("retrieve")]
        public IActionResult Retrieve(int id)
        {
            var product = _productService.GetById(id);
            var result = _productService.Retrieve(product.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
