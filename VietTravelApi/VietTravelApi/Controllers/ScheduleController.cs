using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VietTravelApi.Common;
using VietTravelApi.Context;
using VietTravelApi.Models;

namespace VietTravelApi.Controllers
{
    [Route("schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        public DataContext _dataContext;
        public Jwt _jwt;
        public ScheduleController(DataContext dataContext, Jwt jwt)
        {
            _dataContext = dataContext;
            _jwt = jwt;
        }

        [HttpGet]
        public IActionResult GetAllSchedule()
        {
            try
            {
                return Ok(_dataContext.Schedule.Where(o => o.IsDelete == 0).ToList());
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
                Schedule Schedule = _dataContext.Schedule.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
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
                List< Schedule> Schedules = _dataContext.Schedule.Where(b => b.TourId == id && b.IsDelete == 0).ToList();
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
                string token = HttpContext.Request.Headers["Authorization"];
                if (token == null || !_jwt.Auth("Admin", token)) return Unauthorized("Yêu cầu xác thực người dùng");
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
                string token = HttpContext.Request.Headers["Authorization"];
                if (token == null || !_jwt.Auth("Admin", token)) return Unauthorized("Yêu cầu xác thực người dùng");
                var Schedule = _dataContext.Schedule.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (Schedule != null)
                {
                    if (value.Pictures.Equals("File null")) value.Pictures = Schedule.Pictures;
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
                string token = HttpContext.Request.Headers["Authorization"];
                if (token == null || !_jwt.Auth("Admin", token)) return Unauthorized("Yêu cầu xác thực người dùng");
                var Schedule = _dataContext.Schedule.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (Schedule != null)
                {
                    //_dataContext.Remove(Schedule);
                    Schedule.IsDelete = 1;
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
