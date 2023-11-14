﻿using Microsoft.AspNetCore.Http;
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
                return Ok(_dataContext.Ticket.Where(o => o.IsDelete == 0).ToList());
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
                Ticket Ticket = _dataContext.Ticket.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
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
                var Ticket = _dataContext.Ticket.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
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
                var Ticket = _dataContext.Ticket.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (Ticket != null)
                {
                    //_dataContext.Remove(Ticket);
                    Ticket.IsDelete = 1;
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
                List< Ticket> tickets = _dataContext.Ticket.Where(b => b.UserId == id && b.IsDelete == 0).ToList();
                if (tickets == null) return NotFound();
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("getTicketNew")]
        public IActionResult GetTicketNew()
        {
            try
            {
                List<Ticket> tickets = _dataContext.Ticket.Where(b => b.IsDelete == 0).OrderByDescending(o => o.BookingDate).ToList();
                foreach(Ticket item in tickets)
                {
                    item.User = _dataContext.User.FirstOrDefault(o => o.Id == item.UserId);
                    item.TourPackage = _dataContext.TourPackage.FirstOrDefault(o => o.Id == item.TourPackageId);
                    item.TourPackage.Hotel = _dataContext.Hotel.FirstOrDefault(o => o.Id == item.TourPackage.HotelId);
                    item.TourPackage.Restaurant = _dataContext.Restaurant.FirstOrDefault(o => o.Id == item.TourPackage.RestaurantId);
                }
                if(tickets.Count>10) tickets = tickets.Take(10).ToList();
                if (tickets == null) return NotFound();
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("searchTicketCustomer")]
        public IActionResult SearchTicketCustomer([FromBody] SearchTicketCusParam value)
        {
            List<Ticket> tickets1 = new List<Ticket>();
            List<Ticket> tickets2 = new List<Ticket>();
            if (value.CusName != null && value.CusName != "")
            {
                User user = _dataContext.User.FirstOrDefault(o => o.IsDelete == 0 && o.Name.Equals(value.CusName));
                if (user == null) return NotFound();
                tickets1 = _dataContext.Ticket.Where(o => o.IsDelete == 0 && o.UserId == user.Id).ToList();
            }
            if (value.CusEmail != null && value.CusEmail != "")
            {
                User user = _dataContext.User.FirstOrDefault(o => o.IsDelete == 0 && o.Email.Equals(value.CusEmail));
                if (user == null) return NotFound();
                tickets2 = _dataContext.Ticket.Where(o => o.IsDelete == 0 && o.UserId == user.Id).ToList();
            }
            //if (value.TourName != null && value.TourName != "")
            //{
            //    Tour tour = _dataContext.Tour.FirstOrDefault(o => o.IsDelete == 0 && o.Name.Equals(value.TourName));
            //    if (tour == null) return NotFound();
            //    TourPackage
            //    List<Ticket> tickets3 = _dataContext.Ticket.Where(o => o.IsDelete == 0 && o.Tour == user.Id).ToList();
            //}
            List<Ticket> tickets = tickets1.Union(tickets2).ToList();
            foreach (Ticket item in tickets)
            {
                item.User = _dataContext.User.FirstOrDefault(o => o.Id == item.UserId);
                item.TourPackage = _dataContext.TourPackage.FirstOrDefault(o => o.Id == item.TourPackageId);
                item.TourPackage.Hotel = _dataContext.Hotel.FirstOrDefault(o => o.Id == item.TourPackage.HotelId);
                item.TourPackage.Restaurant = _dataContext.Restaurant.FirstOrDefault(o => o.Id == item.TourPackage.RestaurantId);
            }
            return Ok(tickets);
        }

        [HttpGet]
        [Route("changeTicketStatus/{ticketId}/{userChange}")]
        public IActionResult ChangeTicketStatus(long ticketId, string userChange)
        {
            HistoryChangeStatusTicket history = new HistoryChangeStatusTicket();
            User user = _dataContext.User.FirstOrDefault(o => o.Email.Equals(userChange));
            if (user == null) return NotFound();
            history.ChangeBy = user.Id;
            history.TicketId = ticketId;
            history.TimeChange = DateTime.Now;
            history.oldStatus = 1;
            history.newStatus = 2;
            _dataContext.HistoryChangeStatusTicket.Add(history);
            _dataContext.SaveChanges();
            Ticket ticket = _dataContext.Ticket.FirstOrDefault(o => o.Id == ticketId);
            Ticket ticket2 = ticket;
            ticket2.Status = 2;
            _dataContext.Entry(ticket).CurrentValues.SetValues(ticket2);
            _dataContext.SaveChanges();
            return Ok();
        }
    }
}
