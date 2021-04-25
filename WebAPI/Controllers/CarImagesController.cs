using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }
        [HttpPost("addimage")]
        public IActionResult AddImage([FromForm(Name ="file")] IFormFile file,[FromForm]CarImage carImage)
        {
            
            var result= _carImageService.Add(carImage, file);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
          
        }
        //[HttpGet("getimagebyid")]
       
    }
}
