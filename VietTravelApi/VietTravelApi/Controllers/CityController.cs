using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public CityController(DataContext dataContext)
        {
            _dataContext = dataContext;
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

        [HttpGet("search/{value}")]
        public IActionResult SearchCity(string value)
        {
            try
            {
                City city = _dataContext.City.FirstOrDefault(b => b.Name == value);
                if (city == null) return NotFound();
                return Ok(city);
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
