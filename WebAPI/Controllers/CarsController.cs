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
    public class CarsController : ControllerBase
    {
        ICarService _carservice;

        public CarsController(ICarService carservice)
        {
            _carservice = carservice;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _carservice.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carservice.Add(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carservice.GetById(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carservice.Delete(car);
            if (!result.Succes)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);


        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carservice.Update(car);
            if (!result.Succes)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);


        }
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(Car car)
        {
            _carservice.Add(car);
            int carid = _carservice.GetAll().Data.Max(car => car.Id);
            return CreatedAtAction("getbyid", new { id = carid }, _carservice.GetById(carid));


        }
        [HttpGet("getcarsdetail")]
        public IActionResult GetCarsDetail()
        {

            var result = _carservice.GetCarsDetail();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
