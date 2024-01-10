using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VietTravelApi.Context;
using VietTravelApi.Models;

namespace VietTravelApi.Controllers
{
    [Route("evaluate")]
    [ApiController]
    public class EvaluateController : ControllerBase
    {
        public DataContext _dataContext;
        public EvaluateController(DataContext dataContext)
        {
            _dataContext = dataContext;
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

        [HttpGet("evaCity/{value}")]
        public IActionResult EvaluateCityId(long value)
        {
            try
            {
                List< Evaluate> evaluates = _dataContext.Evaluate.Where(b => b.EvaId == value && b.Eva == 1 && b.IsDelete == 0).ToList();
                if (evaluates == null) return NotFound();
                else
                {
                    foreach(Evaluate eva in evaluates)
                    {
                        User user = _dataContext.User.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == eva.UserId);
                        if(user == null) return NotFound();
                        eva.User = user;
                    }
                    return Ok(evaluates);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("evaTour/{value}")]
        public IActionResult EvaluateTourId(long value)
        {
            try
            {
                List<Evaluate> evaluates = _dataContext.Evaluate.Where(b => b.EvaId == value && b.Eva == 2 && b.IsDelete == 0).ToList();
                if (evaluates == null) return NotFound();
                else
                {
                    foreach (Evaluate eva in evaluates)
                    {
                        User user = _dataContext.User.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == eva.UserId);
                        if (user == null) return NotFound();
                        eva.User = user;
                    }
                    return Ok(evaluates);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("evaHotel/{value}")]
        public IActionResult EvaluateHotelId(long value)
        {
            try
            {
                List<Evaluate> evaluates = _dataContext.Evaluate.Where(b => b.EvaId == value && b.Eva == 3 && b.IsDelete == 0).ToList();
                if (evaluates == null) return NotFound();
                else
                {
                    foreach (Evaluate eva in evaluates)
                    {
                        User user = _dataContext.User.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == eva.UserId);
                        if (user == null) return NotFound();
                        eva.User = user;
                    }
                    return Ok(evaluates);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("evaRestaurant/{value}")]
        public IActionResult EvaluateRestaurantId(long value)
        {
            try
            {
                List<Evaluate> evaluates = _dataContext.Evaluate.Where(b => b.EvaId == value && b.Eva == 4 && b.IsDelete == 0).ToList();
                if (evaluates == null) return NotFound();
                else
                {
                    foreach (Evaluate eva in evaluates)
                    {
                        User user = _dataContext.User.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == eva.UserId);
                        if (user == null) return NotFound();
                        eva.User = user;
                    }
                    return Ok(evaluates);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Evaluate value)
        {
            Evaluate evaluate = value;
            try
            {
                switch (value.Eva)
                {
                    case 1:
                        City city = _dataContext.City.FirstOrDefault(o => o.Id == value.EvaId && o.IsDelete == 0);
                        if (city == null) return BadRequest();
                        else city.NumberOfEvaluate += 1;
                        break;
                    case 2:
                        Tour tour = _dataContext.Tour.FirstOrDefault(o => o.Id == value.EvaId && o.IsDelete == 0);
                        if (tour == null) return BadRequest();
                        else tour.NumberOfEvaluate += 1;
                        break;
                    case 3:
                        Hotel hotel = _dataContext.Hotel.FirstOrDefault(o => o.Id == value.EvaId && o.IsDelete == 0);
                        if (hotel == null) return BadRequest();
                        else hotel.NumberOfEvaluate += 1;
                        break;
                    case 4:
                        Restaurant restaurant = _dataContext.Restaurant.FirstOrDefault(o => o.Id == value.EvaId && o.IsDelete == 0);
                        if (restaurant == null) return BadRequest();
                        else restaurant.NumberOfEvaluate += 1;
                        break;
                }
                _dataContext.Evaluate.Add(evaluate);
                _dataContext.SaveChanges();
                return Ok(evaluate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Evaluate value)
        {
            try
            {
                var evaluate = _dataContext.Evaluate.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                var evaluateUpdate = evaluate;
                evaluateUpdate.Content = value.Content;
                if (evaluate != null)
                {
                    _dataContext.Entry(evaluate).CurrentValues.SetValues(evaluateUpdate);
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
                var evaluate = _dataContext.Evaluate.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (evaluate != null)
                {
                    switch (evaluate.Eva)
                    {
                        case 1:
                            City city = _dataContext.City.Where(o => o.Id == evaluate.EvaId && o.IsDelete == 0).FirstOrDefault();
                            city.NumberOfEvaluate -= 1;
                            break;
                        case 2:
                            Tour tour = _dataContext.Tour.Where(o => o.Id == evaluate.EvaId && o.IsDelete == 0).FirstOrDefault();
                            tour.NumberOfEvaluate -= 1;
                            break;
                        case 3:
                            Hotel hotel = _dataContext.Hotel.Where(o => o.Id == evaluate.EvaId && o.IsDelete == 0).FirstOrDefault();
                            hotel.NumberOfEvaluate -= 1;
                            break;
                        case 4:
                            Restaurant restaurant = _dataContext.Restaurant.Where(o => o.Id == evaluate.EvaId && o.IsDelete == 0).FirstOrDefault();
                            restaurant.NumberOfEvaluate -= 1;
                            break;
                    }
                    //_dataContext.Remove(evaluate);
                    evaluate.IsDelete = 1;
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
