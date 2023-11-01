using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using VietTravelApi.Context;
using VietTravelApi.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using VietTravelApi.Common;

namespace VietTravelApi.Controllers
{
    [Route("restaurant")]
    [ApiController]
    public class RestaurantController : Controller
    {
        public DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public DeleteModels _deleteModels;
        public int pageSize;
        public RestaurantController(DataContext dataContext, IConfiguration configuration, DeleteModels deleteModels)
        {
            _dataContext = dataContext;
            _configuration = configuration;
            _deleteModels = deleteModels;
            pageSize = int.Parse(_configuration["PageSize"]);
        }

        [HttpGet]
        public IActionResult GetAllRestaurant()
        {
            try
            {
                return Ok(_dataContext.Restaurant.Where(o => o.IsDelete == 0).ToList());
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
                int totalItem = _dataContext.Restaurant.Where(o => o.IsDelete == 0).Count();
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
                int totalItem = _dataContext.Restaurant.Where(b => b.UniCodeName.ToLower().Contains(value.ToLower()) && b.IsDelete == 0).Count();
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
        public IActionResult GetPageRestaurant(int page)
        {
            try
            {
                return Ok(_dataContext.Restaurant.Where(o => o.IsDelete == 0).Skip((page - 1) * pageSize).Take(pageSize).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetRestaurantById(long id)
        {
            try
            {
                Restaurant restaurant = _dataContext.Restaurant.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (restaurant == null) return NotFound();
                return Ok(restaurant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        //[HttpGet("search/{value}")]
        //public IActionResult SearchRestaurant(string value)
        //{
        //    try
        //    {
        //        List<Restaurant> restaurants = _dataContext.Restaurant.Where(b => b.UniCodeName.ToLower().Contains(value.ToLower())).ToList();
        //        if (restaurants == null) return NotFound();
        //        return Ok(restaurants);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        [HttpGet("search/{value}/{page}")]
        public IActionResult SearchPageRestaurant(string value, int page)
        {
            try
            {
                List<Restaurant> restaurants = _dataContext.Restaurant.Where(b => b.UniCodeName.ToLower().Contains(value.ToLower()) && b.IsDelete == 0).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                if (restaurants == null) return NotFound();
                return Ok(restaurants);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("searchByCityId/{value}")]
        public IActionResult SearchRestaurantByCityId(string value)
        {
            try
            {
                List<Restaurant> restaurants = _dataContext.Restaurant.Where(b => b.CityId == long.Parse(value) && b.IsDelete == 0).ToList();
                return Ok(restaurants);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Restaurant value)
        {
            Restaurant restaurant = value;
            try
            {
                _dataContext.Restaurant.Add(restaurant);
                _dataContext.SaveChanges();
                return Ok(restaurant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Restaurant value)
        {
            try
            {
                var restaurant = _dataContext.Restaurant.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (restaurant != null)
                {
                    if (value.Pictures.Equals("File null")) value.Pictures = restaurant.Pictures;
                    _dataContext.Entry(restaurant).CurrentValues.SetValues(value);
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
                var restaurant = _dataContext.Restaurant.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (restaurant != null)
                {
                    //_dataContext.Remove(restaurant);
                    restaurant.IsDelete = 1;
                    _deleteModels.DeleteRestaurant(id);
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
