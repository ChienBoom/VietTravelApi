using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using VietTravelApi.Context;
using VietTravelApi.Models;
using System.Linq;
using VietTravelApi.Common;

namespace VietTravelApi.Controllers
{
    [Route("event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public DataContext _dataContext;
        public Jwt _jwt;
        public EventController(DataContext dataContext, Jwt jwt)
        {
            _dataContext = dataContext;
            _jwt = jwt;
        }

        [HttpGet]
        public IActionResult GetAllEvent()
        {
            try
            {
                return Ok(_dataContext.Event.Where(o => o.IsDelete == 0).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEventById(long id)
        {
            try
            {
                Event Event = _dataContext.Event.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (Event == null) return NotFound();
                return Ok(Event);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("searchEventByTourId/{value}")]
        public IActionResult SearchEventByTourId(string value)
        {
            try
            {
                List<Event> events = _dataContext.Event.Where(b => b.TourId == long.Parse(value) && b.IsDelete == 0).ToList();
                if (events == null) return NotFound();
                return Ok(events);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Event value)
        {
            Event Event = value;
            try
            {
                string token = HttpContext.Request.Headers["Authorization"];
                if (token == null || !_jwt.Auth("Admin", token)) return Unauthorized("Yêu cầu xác thực người dùng");
                _dataContext.Event.Add(Event);
                _dataContext.SaveChanges();
                return Ok(Event);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Event value)
        {
            try
            {
                string token = HttpContext.Request.Headers["Authorization"];
                if (token == null || !_jwt.Auth("Admin", token)) return Unauthorized("Yêu cầu xác thực người dùng");
                var Event = _dataContext.Event.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (Event != null)
                {
                    if (value.Pictures.Equals("File null")) value.Pictures = Event.Pictures;
                    _dataContext.Entry(Event).CurrentValues.SetValues(value);
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
                var Event = _dataContext.Event.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (Event != null)
                {
                    //_dataContext.Remove(Event);
                    Event.IsDelete = 1;
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
