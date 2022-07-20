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
    public class SellerAnswersController : ControllerBase
    {

        ISellerAnswerService _sellerAnswerService;

        public SellerAnswersController(ISellerAnswerService sellerAnswerService)
        {
            _sellerAnswerService = sellerAnswerService;
        }

        [HttpPost("add")]
        public IActionResult Add(SellerAnswer entity)
        {
            var result = _sellerAnswerService.Add(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(SellerAnswer entity)
        {
            var result = _sellerAnswerService.Delete(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(SellerAnswer entity)
        {
            var result = _sellerAnswerService.Update(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _sellerAnswerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _sellerAnswerService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbyqid")]
        public IActionResult GetAllByQId(int id)
        {
            var result = _sellerAnswerService.GetAllByQId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
