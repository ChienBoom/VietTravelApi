using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using VietTravelApi.Common;
using VietTravelApi.Context;
using VietTravelApi.Models;

namespace VietTravelApi.Controllers
{
    [Route("hotel")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        public DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public DeleteModels _deleteModels;
        public int pageSize;
        public HotelController(DataContext dataContext, IConfiguration configuration, DeleteModels deleteModels)
        {
            _dataContext = dataContext;
            _configuration = configuration;
            _deleteModels =deleteModels;
            pageSize = int.Parse(_configuration["PageSize"]);
        }

        [HttpGet]
        public IActionResult GetAllHotel()
        {
            try
            {
                return Ok(_dataContext.Hotel.Where(o => o.IsDelete == 0).ToList());
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
                int totalItem = _dataContext.Hotel.Where(o => o.IsDelete == 0).Count();
                if (totalItem % pageSize == 0) return Ok(totalItem / pageSize);
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
                int totalItem = _dataContext.Hotel.Where(b => b.UniCodeName.ToLower().Contains(value.ToLower()) && b.IsDelete == 0).Count();
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
        public IActionResult GetPageHotel(int page)
        {
            try
            {
                return Ok(_dataContext.Hotel.Where(o => o.IsDelete == 0).Skip((page - 1) * pageSize).Take(pageSize).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetHotelById(long id)
        {
            try
            {
                Hotel Hotel = _dataContext.Hotel.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (Hotel == null) return NotFound();
                return Ok(Hotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        //[HttpGet("search/{value}")]
        //public IActionResult SearchHotel(string value)
        //{
        //    try
        //    {
        //        List<Hotel> hotels = _dataContext.Hotel.Where(b => b.UniCodeName.ToLower().Contains(value.ToLower())).ToList();
        //        if (hotels == null) return NotFound();
        //        return Ok(hotels);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        [HttpGet("search/{value}/{page}")]
        public IActionResult SearchPageHotel(string value, int page)
        {
            try
            {
                List<Hotel> hotels = _dataContext.Hotel.Where(b => b.UniCodeName.ToLower().Contains(value.ToLower()) && b.IsDelete == 0).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                if (hotels == null) return NotFound();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("searchByCityId/{value}")]
        public IActionResult SearchHotelByCityId(string value)
        {
            try
            {
                List<Hotel> hotels = _dataContext.Hotel.Where(b => b.CityId == long.Parse(value) && b.IsDelete == 0).ToList();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Hotel value)
        {
            Hotel Hotel = value;
            try
            {
                _dataContext.Hotel.Add(Hotel);
                _dataContext.SaveChanges();
                return Ok(Hotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Hotel value)
        {
            try
            {
                var Hotel = _dataContext.Hotel.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (Hotel != null)
                {
                    if (value.Pictures.Equals("File null")) value.Pictures = Hotel.Pictures;
                    value.NumberOfEvaluate = Hotel.NumberOfEvaluate;
                    value.MediumStar = Hotel.MediumStar;
                    _dataContext.Entry(Hotel).CurrentValues.SetValues(value);
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
                var Hotel = _dataContext.Hotel.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (Hotel != null)
                {
                    //_dataContext.Remove(Hotel);
                    Hotel.IsDelete = 1;
                    _deleteModels.DeleteHotel(id);
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
