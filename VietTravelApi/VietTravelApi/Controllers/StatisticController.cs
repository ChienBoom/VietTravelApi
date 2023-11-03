using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VietTravelApi.Context;
using VietTravelApi.Models;

namespace VietTravelApi.Controllers
{
    [Route("revenueStatistics")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        public DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public StatisticController(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("revenueStatisticCity")]
        public IActionResult RevenueStatisticCity()
        {
            try
            {
                Revenue revenue = new Revenue();
                List<string> Labels = new List<string>();
                List<List<Ticket>> Data = new List<List<Ticket>>();
                List<City> cities = _dataContext.City.Where(o => o.IsDelete==0).ToList();
                if (cities.Count > 0)
                {
                    foreach (City item in cities)
                    {
                        Labels.Add(item.Name);
                        var tickets = (from ticket in _dataContext.Ticket
                                       join tourPackage in _dataContext.TourPackage on ticket.TourPackageId equals tourPackage.Id
                                       join tour in _dataContext.Tour on tourPackage.TourId equals tour.Id
                                       join city in _dataContext.City on tour.CityId equals city.Id
                                       where city.Id == item.Id && tour.IsDelete ==0 && ticket.IsDelete ==0
                                       select new
                                       {
                                           ticket,
                                           tourPackage
                                       }).ToList();
                        if (tickets == null || tickets.Count < 1) Data.Add(new List<Ticket>());
                        else
                        {
                            List<Ticket> lstTicket = new List<Ticket>();
                            foreach (var t in tickets)
                            {
                                Ticket ticket = new Ticket();
                                ticket.Id = t.ticket.Id;
                                ticket.Description = t.ticket.Description;
                                ticket.BookingDate = t.ticket.BookingDate;
                                ticket.UserId = t.ticket.UserId;
                                ticket.User = t.ticket.User;
                                ticket.TourPackage = t.tourPackage;
                                ticket.TourPackageId = t.ticket.TourPackageId;
                                lstTicket.Add(ticket);
                            }
                            Data.Add(lstTicket);
                        }
                    }
                    revenue.Label = "Thành phố";
                    revenue.Labels = Labels;
                    revenue.Data = Data;
                    return Ok(revenue);
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("revenueStatisticTour")]
        public IActionResult RevenueStatisticTour()
        {
            try
            {
                Revenue revenue = new Revenue();
                List<string> Labels = new List<string>();
                List<List<Ticket>> Data = new List<List<Ticket>>();
                List<Tour> tours = _dataContext.Tour.Where(o => o.IsDelete==0).ToList();
                if (tours.Count > 0)
                {
                    foreach (Tour item in tours)
                    {
                        Labels.Add(item.Name);
                        var tickets = (from ticket in _dataContext.Ticket
                                       join tourPackage in _dataContext.TourPackage on ticket.TourPackageId equals tourPackage.Id
                                       join tour in _dataContext.Tour on tourPackage.TourId equals tour.Id
                                       where tour.Id == item.Id && ticket.IsDelete == 0
                                       select new
                                       {
                                           ticket,
                                           tourPackage
                                       }).ToList();
                        if (tickets == null || tickets.Count < 1) Data.Add(new List<Ticket>());
                        else
                        {
                            List<Ticket> lstTicket = new List<Ticket>();
                            foreach (var t in tickets)
                            {
                                Ticket ticket = new Ticket();
                                ticket.Id = t.ticket.Id;
                                ticket.Description = t.ticket.Description;
                                ticket.BookingDate = t.ticket.BookingDate;
                                ticket.UserId = t.ticket.UserId;
                                ticket.User = t.ticket.User;
                                ticket.TourPackage = t.tourPackage;
                                ticket.TourPackageId = t.ticket.TourPackageId;
                                lstTicket.Add(ticket);
                            }
                            Data.Add(lstTicket);
                        }
                    }
                    revenue.Label = "Tour";
                    revenue.Labels = Labels;
                    revenue.Data = Data;
                    return Ok(revenue);
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("revenueStatisticMonth")]
        public IActionResult RevenueStatisticMonth()
        {
            try
            {
                Revenue revenue = new Revenue();
                List<string> Labels = new List<string>();
                List<List<Ticket>> Data = new List<List<Ticket>>();
                for (int i = 1; i <= 12; i++)
                {
                    Labels.Add("Tháng " + i.ToString());
                    var tickets = (from ticket in _dataContext.Ticket
                                   join tourPackage in _dataContext.TourPackage on ticket.TourPackageId equals tourPackage.Id
                                   where ticket.BookingDate.Month == i && ticket.IsDelete == 0
                                   select new
                                   {
                                       ticket,
                                       tourPackage
                                   }).ToList();
                    if (tickets == null || tickets.Count < 1) Data.Add(new List<Ticket>());
                    else
                    {
                        List<Ticket> lstTicket = new List<Ticket>();
                        foreach (var t in tickets)
                        {
                            Ticket ticket = new Ticket();
                            ticket.Id = t.ticket.Id;
                            ticket.Description = t.ticket.Description;
                            ticket.BookingDate = t.ticket.BookingDate;
                            ticket.UserId = t.ticket.UserId;
                            ticket.User = t.ticket.User;
                            ticket.TourPackage = t.tourPackage;
                            ticket.TourPackageId = t.ticket.TourPackageId;
                            lstTicket.Add(ticket);
                        }
                        Data.Add(lstTicket);
                    }
                }
                revenue.Label = "Tháng";
                revenue.Labels = Labels;
                revenue.Data = Data;
                return Ok(revenue);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
