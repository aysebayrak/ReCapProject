using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace WepAPI.Controllers
{
    //yapılabilecek istekler 
    [Route("api/[controller]")]
    [ApiController]  //c# da ATTRIBUTE = clasla ilgili bilgi verme  bu klas bi conntroller
    //IoC Container  = 
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        
   
        [HttpGet("getall")]
         public  IActionResult GetAll()
        {
            Thread.Sleep(1000);
            var result =_carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarbybrandid")]
        public IActionResult GetCarByBrandid(int brandId)
        {
            var result = _carService.GetCarDetails(c=>c.BrandId==brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarbycolorid")]
        public IActionResult GetCarByColorid(int colorId)
        {
            var result = _carService.GetCarDetails(c => c.ColorId == colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public  IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcardetailbycarid")]
        public IActionResult GetCarDetailsByCarId(int carId)
        {
            var result = _carService.GetCarDetailsByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }

}

