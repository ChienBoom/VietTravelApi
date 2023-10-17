using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using VietTravelApi.Context;
using VietTravelApi.Models;

namespace VietTravelApi.Controllers
{
    [Route("city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        public DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public int pageSize;
        public CityController(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
            pageSize = int.Parse(_configuration["PageSize"]);
        }

        [HttpGet]
        public IActionResult GetAllCity()
        {
            try
            {
                return Ok(_dataContext.City.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("totalPage")]
        public IActionResult TotalPage()
        {
            try
            {
                int totalPage;
                int totalItem = _dataContext.City.Count();
                if (totalItem % pageSize == 0) return Ok(totalItem / pageSize);
                return Ok(totalItem / pageSize + 1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("search/totalPage/{value}")]
        public IActionResult SearchTotalPage(string value)
        {
            try
            {
                int totalPage;
                int totalItem = _dataContext.City.Where(b => b.UniCodeName.ToLower().Contains(value.ToLower())).Count();
                if (totalItem % pageSize == 0) return Ok(totalItem / pageSize);
                return Ok(totalItem / pageSize + 1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("page/{page}")]
        public IActionResult GetPageCity(int page)
        {
            try
            {
                return Ok(_dataContext.City.Skip((page - 1) * pageSize).Take(pageSize).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCityById(long id)
        {
            try
            {
                City city = _dataContext.City.FirstOrDefault(b => b.Id == id);
                if (city == null) return NotFound();
                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        //[HttpGet("search/{value}")]
        //public IActionResult SearchCity(string value)
        //{
        //    try
        //    {
        //        List<City> cities = _dataContext.City.Where(b => b.UniCodeName.ToLower().Contains(value.ToLower())).ToList();
        //        if (cities == null) return NotFound();
        //        return Ok(cities);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        [HttpGet("search/{value}/{page}")]
        public IActionResult SearchPageTour(string value, int page)
        {
            try
            {
                List<City> cities = _dataContext.City.Where(b => b.UniCodeName.ToLower().Contains(value.ToLower())).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                if (cities == null) return NotFound();
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] City value)
        {
            City city = value;
            try
            {
                _dataContext.City.Add(city);
                _dataContext.SaveChanges();
                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] City value)
        {
            try
            {
                var City = _dataContext.City.FirstOrDefault(b => b.Id == id);
                if (City != null)
                {
                    if(value.Pictures.Equals("File null")) value.Pictures = City.Pictures;
                    value.Tours = City.Tours;
                    _dataContext.Entry(City).CurrentValues.SetValues(value);
                    _dataContext.SaveChanges();
                    return Ok(value);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                var City = _dataContext.City.FirstOrDefault(b => b.Id == id);
                if (City != null)
                {
                    _dataContext.Remove(City);
                    _dataContext.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

    }
}
