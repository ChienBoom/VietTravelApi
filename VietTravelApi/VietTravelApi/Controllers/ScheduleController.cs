using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VietTravelApi.Context;
using VietTravelApi.Models;

namespace VietTravelApi.Controllers
{
    [Route("schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        public DataContext _dataContext;
        public ScheduleController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAllSchedule()
        {
            try
            {
                return Ok(_dataContext.Schedule.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetScheduleById(long id)
        {
            try
            {
                Schedule Schedule = _dataContext.Schedule.FirstOrDefault(b => b.Id == id);
                if (Schedule == null) return NotFound();
                return Ok(Schedule);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("getByTourId/{id}")]
        public IActionResult GetScheduleByTourId(long id)
        {
            try
            {
                List< Schedule> Schedules = _dataContext.Schedule.Where(b => b.TourId == id).ToList();
                if (Schedules == null) return NotFound();
                return Ok(Schedules);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        //[HttpGet("search/{value}")]
        //public IActionResult SearchSchedule(string value)
        //{
        //    try
        //    {
        //        Schedule Schedule = _dataContext.Schedule.FirstOrDefault(b => b.Name == value);
        //        if (Schedule == null) return NotFound();
        //        return Ok(Schedule);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        [HttpPost]
        public IActionResult Post([FromBody] Schedule value)
        {
            Schedule schedule = value;
            try
            {
                _dataContext.Schedule.Add(schedule);
                _dataContext.SaveChanges();
                return Ok(schedule);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Schedule value)
        {
            try
            {
                var Schedule = _dataContext.Schedule.FirstOrDefault(b => b.Id == id);
                if (Schedule != null)
                {
                    _dataContext.Entry(Schedule).CurrentValues.SetValues(value);
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
                var Schedule = _dataContext.Schedule.FirstOrDefault(b => b.Id == id);
                if (Schedule != null)
                {
                    _dataContext.Remove(Schedule);
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
