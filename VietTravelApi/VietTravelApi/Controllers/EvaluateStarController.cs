using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VietTravelApi.Common;
using VietTravelApi.Context;
using VietTravelApi.Models;

namespace VietTravelApi.Controllers
{
    [Route("evaluateStar")]
    [ApiController]
    public class EvaluateStarController : ControllerBase
    {
        public DataContext _dataContext;
        public Jwt _jwt;
        public EvaluateStarController(DataContext dataContext, Jwt jwt)
        {
            _dataContext = dataContext;
            _jwt = jwt;
        }

        //[HttpGet]
        //public IActionResult GetAllEvaluate()
        //{
        //    try
        //    {
        //        return Ok(_dataContext.Evaluate.ToList());
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetEvaluateById(long id)
        //{
        //    try
        //    {
        //        Evaluate Evaluate = _dataContext.Evaluate.FirstOrDefault(b => b.Id == id);
        //        if (Evaluate == null) return NotFound();
        //        return Ok(Evaluate);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        [HttpGet("evaStarCity/{value}")]
        public IActionResult EvaluateStarCityId(long value)
        {
            try
            {
                List<EvaluateStar> evaluateStars = _dataContext.EvaluateStar.Where(b => b.EvaId == value && b.Eva == 1 && b.IsDelete == 0).ToList();
                if (evaluateStars == null) return NotFound();
                else
                {
                    foreach (EvaluateStar eva in evaluateStars)
                    {
                        User user = _dataContext.User.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == eva.UserId);
                        if (user == null) return NotFound();
                        eva.User = user;
                    }
                    return Ok(evaluateStars);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("evaStarTour/{value}")]
        public IActionResult EvaluateStarTourId(long value)
        {
            try
            {
                List<EvaluateStar> evaluateStars = _dataContext.EvaluateStar.Where(b => b.EvaId == value && b.Eva == 2 && b.IsDelete == 0).ToList();
                if (evaluateStars == null) return NotFound();
                else
                {
                    foreach (EvaluateStar eva in evaluateStars)
                    {
                        User user = _dataContext.User.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == eva.UserId);
                        if (user == null) return NotFound();
                        eva.User = user;
                    }
                    return Ok(evaluateStars);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("evaStarHotel/{value}")]
        public IActionResult EvaluateStarHotelId(long value)
        {
            try
            {
                List<EvaluateStar> evaluateStars = _dataContext.EvaluateStar.Where(b => b.EvaId == value && b.Eva == 3 && b.IsDelete == 0).ToList();
                if (evaluateStars == null) return NotFound();
                else
                {
                    foreach (EvaluateStar eva in evaluateStars)
                    {
                        User user = _dataContext.User.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == eva.UserId);
                        if (user == null) return NotFound();
                        eva.User = user;
                    }
                    return Ok(evaluateStars);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("evaStarRestaurant/{value}")]
        public IActionResult EvaluateStarRestaurantId(long value)
        {
            try
            {
                List<EvaluateStar> evaluateStars = _dataContext.EvaluateStar.Where(b => b.EvaId == value && b.Eva == 4 && b.IsDelete == 0).ToList();
                if (evaluateStars == null) return NotFound();
                else
                {
                    foreach (EvaluateStar eva in evaluateStars)
                    {
                        User user = _dataContext.User.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == eva.UserId);
                        if (user == null) return NotFound();
                        eva.User = user;
                    }
                    return Ok(evaluateStars);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] EvaluateStar value)
        {
            EvaluateStar evaluateStar = value;
            try
            {
                string token = HttpContext.Request.Headers["Authorization"];
                if (token == null || !_jwt.Auth("Customer", token)) return Unauthorized("Yêu cầu xác thực người dùng");
                switch (value.Eva)
                {
                    case 1:
                        City city = _dataContext.City.FirstOrDefault(o => o.Id == value.EvaId && o.IsDelete == 0);
                        if (city == null) return NotFound();
                        else city.NumberOfEvaluateStar += 1;
                        List<EvaluateStar> evaluateStarCitys = _dataContext.EvaluateStar.Where(o => o.Eva == 1 && o.EvaId == city.Id && o.IsDelete == 0).ToList();
                        city.MediumStar = (float)(evaluateStarCitys.Sum(o => o.NumberStar) + value.NumberStar) / (city.NumberOfEvaluateStar);
                        //evaluateStar.CityId = value.EvaId;
                        //evaluateStar.TourId = value.EvaId;
                        //evaluateStar.HotelId = value.EvaId;
                        //evaluateStar.RestaurantId = value.EvaId;
                        evaluateStar.CityId = 1;
                        evaluateStar.TourId = 1;
                        evaluateStar.HotelId = 1;
                        evaluateStar.RestaurantId = 1;
                        break;
                    case 2:
                        Tour tour = _dataContext.Tour.FirstOrDefault(o => o.Id == value.EvaId && o.IsDelete == 0);
                        if (tour == null) return NotFound();
                        else tour.NumberOfEvaluateStar += 1;
                        List<EvaluateStar> evaluateStarTours = _dataContext.EvaluateStar.Where(o => o.Eva == 2 && o.EvaId == tour.Id && o.IsDelete == 0).ToList();
                        tour.MediumStar = (float)(evaluateStarTours.Sum(o => o.NumberStar) + value.NumberStar) / (tour.NumberOfEvaluateStar);
                        //evaluateStar.CityId = value.EvaId;
                        //evaluateStar.TourId = value.EvaId;
                        //evaluateStar.HotelId = value.EvaId;
                        //evaluateStar.RestaurantId = value.EvaId;
                        evaluateStar.CityId = 1;
                        evaluateStar.TourId = 1;
                        evaluateStar.HotelId = 1;
                        evaluateStar.RestaurantId = 1;
                        break;
                    case 3:
                        Hotel hotel = _dataContext.Hotel.FirstOrDefault(o => o.Id == value.EvaId && o.IsDelete == 0);
                        if (hotel == null) return NotFound();
                        else hotel.NumberOfEvaluateStar += 1;
                        List<EvaluateStar> evaluateStarHotels = _dataContext.EvaluateStar.Where(o => o.Eva == 3 && o.EvaId == hotel.Id && o.IsDelete == 0).ToList();
                        hotel.MediumStar = (float)(evaluateStarHotels.Sum(o => o.NumberStar) + value.NumberStar) / (hotel.NumberOfEvaluateStar);
                        //evaluateStar.CityId = value.EvaId;
                        //evaluateStar.TourId = value.EvaId;
                        //evaluateStar.HotelId = value.EvaId;
                        //evaluateStar.RestaurantId = value.EvaId;
                        evaluateStar.CityId = 1;
                        evaluateStar.TourId = 1;
                        evaluateStar.HotelId = 1;
                        evaluateStar.RestaurantId = 1;
                        break;
                    case 4:
                        Restaurant restaurant = _dataContext.Restaurant.FirstOrDefault(o => o.Id == value.EvaId && o.IsDelete == 0);
                        if (restaurant == null) return NotFound();
                        else restaurant.NumberOfEvaluateStar += 1;
                        List<EvaluateStar> evaluateStarRes = _dataContext.EvaluateStar.Where(o => o.Eva == 4 && o.EvaId == restaurant.Id && o.IsDelete == 0).ToList();
                        restaurant.MediumStar = (float)(evaluateStarRes.Sum(o => o.NumberStar) + value.NumberStar) / (restaurant.NumberOfEvaluateStar);
                        //evaluateStar.CityId = value.EvaId;
                        //evaluateStar.TourId = value.EvaId;
                        //evaluateStar.HotelId = value.EvaId;
                        //evaluateStar.RestaurantId = value.EvaId;
                        evaluateStar.CityId = 1;
                        evaluateStar.TourId = 1;
                        evaluateStar.HotelId = 1;
                        evaluateStar.RestaurantId = 1;
                        break;
                }
                evaluateStar.User = null;
                _dataContext.EvaluateStar.Add(evaluateStar);
                _dataContext.SaveChanges();
                return Ok(evaluateStar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] EvaluateStar value)
        {
            try
            {
                string token = HttpContext.Request.Headers["Authorization"];
                if (token == null || !_jwt.Auth("Customer", token)) return Unauthorized("Yêu cầu xác thực người dùng");
                var evaluateStar = _dataContext.EvaluateStar.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (evaluateStar != null)
                {
                    switch (value.Eva)
                    {
                        case 1:
                            City city = _dataContext.City.FirstOrDefault(o => o.Id == value.EvaId && o.IsDelete == 0);
                            if (city == null) return NotFound();
                            List<EvaluateStar> evaluateStarCitys = _dataContext.EvaluateStar.Where(o => o.Eva == 1 && o.EvaId == city.Id && o.IsDelete == 0).ToList();
                            city.MediumStar = (float)(evaluateStarCitys.Sum(o => o.NumberStar) + value.NumberStar - evaluateStar.NumberStar) / (city.NumberOfEvaluateStar);
                            break;
                        case 2:
                            Tour tour = _dataContext.Tour.FirstOrDefault(o => o.Id == value.EvaId && o.IsDelete == 0);
                            if (tour == null) return NotFound();
                            List<EvaluateStar> evaluateStarTours = _dataContext.EvaluateStar.Where(o => o.Eva == 2 && o.EvaId == tour.Id && o.IsDelete == 0).ToList();
                            tour.MediumStar = (float)(evaluateStarTours.Sum(o => o.NumberStar) + value.NumberStar - evaluateStar.NumberStar) / (tour.NumberOfEvaluateStar);
                            break;
                        case 3:
                            Hotel hotel = _dataContext.Hotel.FirstOrDefault(o => o.Id == value.EvaId && o.IsDelete == 0);
                            if (hotel == null) return NotFound();
                            List<EvaluateStar> evaluateStarHotels = _dataContext.EvaluateStar.Where(o => o.Eva == 3 && o.EvaId == hotel.Id && o.IsDelete == 0).ToList();
                            hotel.MediumStar = (float)(evaluateStarHotels.Sum(o => o.NumberStar) + value.NumberStar - evaluateStar.NumberStar) / (hotel.NumberOfEvaluateStar);
                            break;
                        case 4:
                            Restaurant restaurant = _dataContext.Restaurant.FirstOrDefault(o => o.Id == value.EvaId && o.IsDelete == 0);
                            if (restaurant == null) return NotFound();
                            List<EvaluateStar> evaluateStarRes = _dataContext.EvaluateStar.Where(o => o.Eva == 4 && o.EvaId == restaurant.Id && o.IsDelete == 0).ToList();
                            restaurant.MediumStar = (float)(evaluateStarRes.Sum(o => o.NumberStar) + value.NumberStar - evaluateStar.NumberStar) / (restaurant.NumberOfEvaluateStar);
                            break;
                    }
                    _dataContext.Entry(evaluateStar).CurrentValues.SetValues(value);
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
                if (token == null || !_jwt.Auth("Customer", token)) return Unauthorized("Yêu cầu xác thực người dùng");
                var evaluateStar = _dataContext.EvaluateStar.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (evaluateStar != null)
                {
                    //_dataContext.Remove(evaluate);
                    evaluateStar.IsDelete = 1;
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

        [HttpGet("evaStar/{eva}/{evaId}/{username}")]
        public IActionResult GetEvaStar(int eva, long evaId, string username)
        {
            try
            {
                User user = _dataContext.User.FirstOrDefault(o => o.Username.Equals(username));
                if (user == null) return NotFound();
                EvaluateStar evaluateStar = _dataContext.EvaluateStar.FirstOrDefault(o => o.IsDelete == 0 && o.Eva == eva && o.EvaId == evaId && o.UserId == user.Id);
                if (evaluateStar == null) return Ok();
                else return Ok(evaluateStar);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
