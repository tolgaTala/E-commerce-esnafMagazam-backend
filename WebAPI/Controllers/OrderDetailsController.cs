using Business.Abstract;
using Entities.Concrete;
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
    public class OrderDetailsController : ControllerBase
    {
        IOrderDetailService _orderDetailService;

        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpPost("add")]
        public IActionResult Add(OrderDetail[] orderDetail)
        {
            var result = _orderDetailService.ListAdd(orderDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _orderDetailService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpGet("getodbyorderid")]
        //public IActionResult GetOrderDetailsByOrderId(int id)
        //{
        //    var result = _orderDetailService.GetOrderDetailsByOrderId(id);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        [HttpGet("getorderdetailbyuserid")]
        public IActionResult GetAllOrderDetailsByUserId(int id)
        {
            var result = _orderDetailService.GetAllOrderDetailsByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("checkbuyorder")]
        public IActionResult CheckBuyOrder(int productId,int userId)
        {
            var result = _orderDetailService.CheckBuyOrder(productId,userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getorderdetailsdto")]
        public IActionResult GetOrderDetailsDto()
        {
            var result = _orderDetailService.GetOrderDetailDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getorderdtobyorderid")]
        public IActionResult GetOrderDetailsDtoByOrderId(int id)
        {
            var result = _orderDetailService.GetOrderDetailsDtoByOrderId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getorderbyorderid")]
        public IActionResult GetOrderDetailsByOrderId(int id, int productId)
        {
            var result = _orderDetailService.GetOrderDetailsByOrderId(id, productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(OrderDetail orderDetail)
        {
            var result = _orderDetailService.Update(orderDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
