﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
        private readonly IConfiguration _configuration;
        public int pageSize;
        public TourController(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
            pageSize = int.Parse(_configuration["PageSize"]);
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

        [HttpGet]
        [Route("totalPage")]
        public IActionResult TotalPage()
        {
            try
            {
                int totalPage;
                int totalItem = _dataContext.Tour.Count();
                if (totalItem % pageSize == 0) return Ok(totalItem/pageSize);
                return Ok(totalItem / pageSize + 1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("search/totalPage/{value}")]
        public IActionResult SearchTotalPage(string value)
        {
            try
            {
                int totalPage;
                int totalItem = _dataContext.Tour.Where(b => b.UniCodeName.ToLower().Contains(value.ToLower())).Count();
                if (totalItem % pageSize == 0) return Ok(totalItem / pageSize);
                return Ok(totalItem / pageSize + 1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("page/{page}")]
        public IActionResult GetPageTour(int page)
        {
            try
            {
                return Ok(_dataContext.Tour.Skip((page-1) * pageSize).Take(pageSize).ToList());
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

        [HttpGet("searchByCityId/{value}")]
        public IActionResult SearchTourByCityId(string value)
        {
            try
            {
                List<Tour> tours = _dataContext.Tour.Where(b => b.CityId == long.Parse(value)).ToList();
                return Ok(tours);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("searchByCityId/{value}/{page}")]
        public IActionResult SearchPageTourByCityId(string value, int page)
        {
            try
            {
                List<Tour> tours = _dataContext.Tour.Where(b => b.CityId == long.Parse(value)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return Ok(tours);
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
        //        List<Tour> tours = _dataContext.Tour.Where(b => b.UniCodeName.ToLower().Contains(value.ToLower())).ToList();
        //        if (tours == null) return NotFound();
        //        return Ok(tours);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        [HttpGet("search/{value}/{page}")]
        public IActionResult SearchPageTour(string value, int page)
        {
            try
            {
                List<Tour> tours = _dataContext.Tour.Where(b => b.UniCodeName.ToLower().Contains(value.ToLower())).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                if (tours == null) return NotFound();
                return Ok(tours);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tour value)
        {
            Tour tour = value;
            try
            {
                _dataContext.Tour.Add(tour);
                _dataContext.SaveChanges();
                return Ok(tour);
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
                var tour = _dataContext.Tour.FirstOrDefault(b => b.Id == id);
                if (tour != null)
                {
                    _dataContext.Entry(tour).CurrentValues.SetValues(value);
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
                var tour = _dataContext.Tour.FirstOrDefault(b => b.Id == id);
                if (tour != null)
                {
                    _dataContext.Remove(tour);
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
