using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VietTravelApi.Context;
using VietTravelApi.Models;

namespace VietTravelApi.Controllers
{
    [Route("tourguide")]
    [ApiController]
    public class TourGuideController : ControllerBase
    {
        public DataContext _dataContext;
        public TourGuideController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAllTourGuide()
        {
            try
            {
                return Ok(_dataContext.TourGuide.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTourGuideById(long id)
        {
            try
            {
                TourGuide TourGuide = _dataContext.TourGuide.FirstOrDefault(b => b.Id == id);
                if (TourGuide == null) return NotFound();
                return Ok(TourGuide);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("searchByCityId/{value}")]
        public IActionResult SearchTourGuideByCityId(string value)
        {
            try
            {
                List<TourGuide> tourGuides = _dataContext.TourGuide.Where(b => b.CityId == long.Parse(value)).ToList();
                return Ok(tourGuides);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        //[HttpGet("search/{value}")]
        //public IActionResult SearchTourGuide(string value)
        //{
        //    try
        //    {
        //        TourGuide TourGuide = _dataContext.TourGuide.FirstOrDefault(b => b.Name == value);
        //        if (TourGuide == null) return NotFound();
        //        return Ok(TourGuide);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        [HttpPost]
        public IActionResult Post([FromBody] TourGuide value)
        {
            TourGuide TourGuide = value;
            try
            {
                _dataContext.TourGuide.Add(TourGuide);
                _dataContext.SaveChanges();
                return Ok(TourGuide);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] TourGuide value)
        {
            try
            {
                var TourGuide = _dataContext.TourGuide.FirstOrDefault(b => b.Id == id);
                if (TourGuide != null)
                {
                    _dataContext.Entry(TourGuide).CurrentValues.SetValues(value);
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
                var TourGuide = _dataContext.TourGuide.FirstOrDefault(b => b.Id == id);
                if (TourGuide != null)
                {
                    _dataContext.Remove(TourGuide);
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
