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
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyidwithdetails")]
        public IActionResult GetByIdWithDetails(int carId)
        {
            var result = _carService.GetByIdWithDetails(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }

        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }

        [HttpGet("getcarsbybrand")]
        public IActionResult GetCarsByBrandIdWithDetail(int brandId)
        {
            var result = _carService.GetCarsByBrandIdWithDetail(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getcarsbycolor")]
        public IActionResult GetCarsByColor(int colorId)
        {
            var result = _carService.GetCarsByColorIdWithDetails(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }

        [HttpGet("getcarsbyfilters")]
        public IActionResult GetCarsByFilters(int colorId,int brandId)
        {
            var result = _carService.GetCarsByFilters(colorId,brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }


        [HttpGet("getcardetail")]
        public IActionResult GetCarDetail()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }

        [HttpPost("add")]
        public IActionResult Post(Car car)
        {
            var result = _carService.AddCar(car);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.UpdateCar(car);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.DeleteCar(car);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


    }
}
