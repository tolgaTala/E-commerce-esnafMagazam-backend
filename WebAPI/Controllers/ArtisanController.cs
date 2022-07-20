using Business.Abstract;
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
    public class ArtisanController : ControllerBase
    {
        IArtisanService _artisanService;

        public ArtisanController(IArtisanService artisanService)
        {
            _artisanService = artisanService;
        }

        [HttpGet("getorders")]
        public IActionResult GetOrderDetailsByOrderId(int id)
        {
            var result = _artisanService.GetOrdersById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getquastions")]
        public IActionResult GetQuastionsBySellerId(int id)
        {
            var result = _artisanService.GetQuastionsById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getordersdtoforadmin")]
        public IActionResult GetOrdersDtoForAdmin()
        {
            var result = _artisanService.GetOrdersDtoForAdmin();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}