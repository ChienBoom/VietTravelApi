using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        [HttpGet("search/{value}")]
        public IActionResult SearchHotel(string value)
        {
            try
            {
                List<Hotel> hotels = _dataContext.Hotel.Where(b => b.Name.ToLower().Contains(value.ToLower())).ToList();
                if (hotels == null) return NotFound();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("searchByCityId/{value}")]
        public IActionResult SearchHotelByCityId(string value)
        {
            try
            {
                List<Hotel> hotels = _dataContext.Hotel.Where(b => b.CityId == long.Parse(value)).ToList();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

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
