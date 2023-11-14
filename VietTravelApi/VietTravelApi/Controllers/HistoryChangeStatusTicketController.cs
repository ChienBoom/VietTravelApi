using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VietTravelApi.Context;
using VietTravelApi.Models;

namespace VietTravelApi.Controllers
{
    [Route("historyChangeStatusTicket")]
    [ApiController]
    public class HistoryChangeStatusTicketController : ControllerBase
    {
        public DataContext _dataContext;
        public HistoryChangeStatusTicketController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAllHistoryChangeStatusTicket()
        {
            try
            {
                return Ok(_dataContext.HistoryChangeStatusTicket.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetHistoryChangeStatusTicketById(long id)
        {
            try
            {
                HistoryChangeStatusTicket history = _dataContext.HistoryChangeStatusTicket.FirstOrDefault(b => b.Id == id);
                if (history == null) return NotFound();
                return Ok(history);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

    }
}
