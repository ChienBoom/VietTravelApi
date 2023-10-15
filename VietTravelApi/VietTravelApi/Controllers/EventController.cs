using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using VietTravelApi.Context;
using VietTravelApi.Models;
using System.Linq;

namespace VietTravelApi.Controllers
{
    [Route("event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public DataContext _dataContext;
        public EventController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAllEvent()
        {
            try
            {
                return Ok(_dataContext.Event.ToList());
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
                Event Event = _dataContext.Event.FirstOrDefault(b => b.Id == id);
                if (Event == null) return NotFound();
                return Ok(Event);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("searchEvent/{value}")]
        public IActionResult SearchEventByTourId(string value)
        {
            try
            {
                List<Event> events = _dataContext.Event.Where(b => b.TourId == long.Parse(value)).ToList();
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
                var Event = _dataContext.Event.FirstOrDefault(b => b.Id == id);
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
                var Event = _dataContext.Event.FirstOrDefault(b => b.Id == id);
                if (Event != null)
                {
                    _dataContext.Remove(Event);
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
