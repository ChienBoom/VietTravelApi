using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VietTravelApi.Context;
using VietTravelApi.Models;

namespace VietTravelApi.Controllers
{
    [Route("ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        public DataContext _dataContext;
        public TicketController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAllTicket()
        {
            try
            {
                return Ok(_dataContext.Ticket.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTicketById(long id)
        {
            try
            {
                Ticket Ticket = _dataContext.Ticket.FirstOrDefault(b => b.Id == id);
                if (Ticket == null) return NotFound();
                return Ok(Ticket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        //[HttpGet("search/{value}")]
        //public IActionResult SearchTicket(string value)
        //{
        //    try
        //    {
        //        Ticket Ticket = _dataContext.Ticket.FirstOrDefault(b => b.Name == value);
        //        if (Ticket == null) return NotFound();
        //        return Ok(Ticket);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        [HttpPost]
        public IActionResult Post([FromBody] Ticket value)
        {
            Ticket Ticket = value;
            try
            {
                _dataContext.Ticket.Add(Ticket);
                _dataContext.SaveChanges();
                return Ok(Ticket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Ticket value)
        {
            try
            {
                var Ticket = _dataContext.Ticket.FirstOrDefault(b => b.Id == id);
                if (Ticket != null)
                {
                    _dataContext.Entry(Ticket).CurrentValues.SetValues(value);
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
                var Ticket = _dataContext.Ticket.FirstOrDefault(b => b.Id == id);
                if (Ticket != null)
                {
                    _dataContext.Remove(Ticket);
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

        [HttpGet]
        [Route("getTicketByUserId/{id}")]
        public IActionResult GetTicketByUserId(long id)
        {
            try
            {
                List< Ticket> tickets = _dataContext.Ticket.Where(b => b.UserId == id).ToList();
                if (tickets == null) return NotFound();
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
