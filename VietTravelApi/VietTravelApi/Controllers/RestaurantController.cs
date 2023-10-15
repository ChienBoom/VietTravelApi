using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using VietTravelApi.Context;
using VietTravelApi.Models;
using System.Linq;

namespace VietTravelApi.Controllers
{
    [Route("restaurant")]
    [ApiController]
    public class RestaurantController : Controller
    {
        public DataContext _dataContext;
        public RestaurantController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAllRestaurant()
        {
            try
            {
                return Ok(_dataContext.Restaurant.ToList());
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
                Restaurant restaurant = _dataContext.Restaurant.FirstOrDefault(b => b.Id == id);
                if (restaurant == null) return NotFound();
                return Ok(restaurant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("search/{value}")]
        public IActionResult SearchRestaurant(string value)
        {
            try
            {
                List<Restaurant> restaurants = _dataContext.Restaurant.Where(b => b.UniCodeName.ToLower().Contains(value.ToLower())).ToList();
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
                List<Restaurant> restaurants = _dataContext.Restaurant.Where(b => b.CityId == long.Parse(value)).ToList();
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
                var restaurant = _dataContext.Restaurant.FirstOrDefault(b => b.Id == id);
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
                var restaurant = _dataContext.Restaurant.FirstOrDefault(b => b.Id == id);
                if (restaurant != null)
                {
                    _dataContext.Remove(restaurant);
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
