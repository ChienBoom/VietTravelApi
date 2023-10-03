using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using VietTravelApi.Context;
using VietTravelApi.Models;

namespace VietTravelApi.Controllers
{
    [Route("hotel")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        public DataContext _dataContext;
        public HotelController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAllHotel()
        {
            try
            {
                return Ok(_dataContext.Hotel.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetHotelById(long id)
        {
            try
            {
                Hotel Hotel = _dataContext.Hotel.FirstOrDefault(b => b.Id == id);
                if (Hotel == null) return NotFound();
                return Ok(Hotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        //[HttpGet("search/{value}")]
        //public IActionResult SearchHotel(string value)
        //{
        //    try
        //    {
        //        Hotel Hotel = _dataContext.Hotel.FirstOrDefault(b => b.Name == value);
        //        if (Hotel == null) return NotFound();
        //        return Ok(Hotel);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        [HttpPost]
        public IActionResult Post([FromBody] Hotel value)
        {
            Hotel Hotel = value;
            try
            {
                _dataContext.Hotel.Add(Hotel);
                _dataContext.SaveChanges();
                return Ok(Hotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Hotel value)
        {
            try
            {
                var Hotel = _dataContext.Hotel.FirstOrDefault(b => b.Id == id);
                if (Hotel != null)
                {
                    _dataContext.Entry(Hotel).CurrentValues.SetValues(value);
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
                var Hotel = _dataContext.Hotel.FirstOrDefault(b => b.Id == id);
                if (Hotel != null)
                {
                    _dataContext.Remove(Hotel);
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
