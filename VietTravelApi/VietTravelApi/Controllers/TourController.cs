using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using VietTravelApi.Context;
using VietTravelApi.Models;

namespace VietTravelApi.Controllers
{
    [Route("tour")]
    [ApiController]
    public class TourController : ControllerBase
    {
        public DataContext _dataContext;
        public TourController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAllTour()
        {
            try
            {
                return Ok(_dataContext.Tour.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTourById(long id)
        {
            try
            {
                Tour Tour = _dataContext.Tour.FirstOrDefault(b => b.Id == id);
                if (Tour == null) return NotFound();
                return Ok(Tour);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        //[HttpGet("search/{value}")]
        //public IActionResult SearchTour(string value)
        //{
        //    try
        //    {
        //        Tour Tour = _dataContext.Tour.FirstOrDefault(b => b.Name == value);
        //        if (Tour == null) return NotFound();
        //        return Ok(Tour);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        [HttpPost]
        public IActionResult Post([FromBody] Tour value)
        {
            Tour Tour = value;
            try
            {
                _dataContext.Tour.Add(Tour);
                _dataContext.SaveChanges();
                return Ok(Tour);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Tour value)
        {
            try
            {
                var Tour = _dataContext.Tour.FirstOrDefault(b => b.Id == id);
                if (Tour != null)
                {
                    _dataContext.Entry(Tour).CurrentValues.SetValues(value);
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
                var Tour = _dataContext.Tour.FirstOrDefault(b => b.Id == id);
                if (Tour != null)
                {
                    _dataContext.Remove(Tour);
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
