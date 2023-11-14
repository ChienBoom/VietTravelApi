using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using VietTravelApi.Common;
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
        public DeleteModels _deleteModels;
        public int pageSize;
        public TourController(DataContext dataContext, IConfiguration configuration, DeleteModels deleteModels)
        {
            _dataContext = dataContext;
            _configuration = configuration;
            _deleteModels = deleteModels;
            pageSize = int.Parse(_configuration["PageSize"]);
        }

        [HttpGet]
        public IActionResult GetAllTour()
        {
            try
            {
                return Ok(_dataContext.Tour.Where(o => o.IsDelete == 0).ToList());
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
                int totalItem = _dataContext.Tour.Where(o => o.IsDelete == 0).Count();
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
                int totalItem = _dataContext.Tour.Where(b => b.UniCodeName.ToLower().Contains(value.ToLower()) && b.IsDelete == 0).Count();
                if (totalItem % pageSize == 0) return Ok(totalItem / pageSize);
                return Ok(totalItem / pageSize + 1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("searchByCityId/totalPage/{value}")]
        public IActionResult SearchTotalPageByCityId(string value)
        {
            try
            {
                int totalPage;
                int totalItem = _dataContext.Tour.Where(b => b.CityId == long.Parse(value) && b.IsDelete == 0).Count();
                if (totalItem % pageSize == 0) return Ok(totalItem / pageSize);
                return Ok(totalItem / pageSize + 1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("searchRelatedTour/{value}")]
        public IActionResult SearchRelatedTour(string value)
        {
            try
            {
                Tour tour = _dataContext.Tour.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == long.Parse(value));
                if (tour == null) return NotFound();
                List <Tour> tours = _dataContext.Tour.Where(o => o.IsDelete == 0 && o.CityId == tour.CityId && o.Id != tour.Id).ToList();
                return Ok(tours);
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
                return Ok(_dataContext.Tour.Where(o => o.IsDelete == 0).Skip((page-1) * pageSize).Take(pageSize).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        //[HttpGet]
        //[Route("hotTour")]
        //public IActionResult HotTour()
        //{
        //    try
        //    {
        //        List<Tour> tours = _dataContext.Tour.OrderByDescending(o => o.MediumStar).ToList();
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        [HttpGet("{id}")]
        public IActionResult GetTourById(long id)
        {
            try
            {
                Tour Tour = _dataContext.Tour.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
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
                List<Tour> tours = _dataContext.Tour.Where(b => b.CityId == long.Parse(value) && b.IsDelete == 0).ToList();
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
                List<Tour> tours = _dataContext.Tour.Where(b => b.CityId == long.Parse(value) && b.IsDelete == 0).Skip((page - 1) * pageSize).Take(pageSize).ToList();
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
                List<Tour> tours = _dataContext.Tour.Where(b => b.UniCodeName.ToLower().Contains(value.ToLower()) && b.IsDelete == 0).Skip((page - 1) * pageSize).Take(pageSize).ToList();
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
                var tour = _dataContext.Tour.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (tour != null)
                {
                    if (value.Pictures.Equals("File null")) value.Pictures = tour.Pictures;
                    value.NumberOfEvaluate = tour.NumberOfEvaluate;
                    value.MediumStar = tour.MediumStar;
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
                var tour = _dataContext.Tour.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (tour != null)
                {
                    //_dataContext.Remove(tour);
                    tour.IsDelete = 1;
                    _deleteModels.DeleteTour(id);
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
        [Route("hotTour")]
        public IActionResult HotTour()
        {
            try
            {
                List<Tour> tours = _dataContext.Tour.Where(o => o.IsDelete == 0).OrderByDescending(o => o.MediumStar).ToList();
                List<Tour> hotTours = tours.Take(3).ToList();
                List<float> hotValue = new List<float> { hotTours[0].MediumStar, hotTours[1].MediumStar, hotTours[2].MediumStar };
                hotValue = hotValue.Distinct().ToList();
                if(hotValue.Count == 1)
                {
                    return Ok(tours.Where(o => o.IsDelete == 0 && o.MediumStar == hotTours[0].MediumStar).OrderByDescending(o => o.NumberOfEvaluateStar).Take(3).ToList());
                }
                else if(hotValue.Count == 2 && hotTours[0].MediumStar == hotTours[1].MediumStar)
                {
                    List<Tour> hotTour1 = tours.Where(o => o.IsDelete == 0 && o.MediumStar == hotValue[0]).OrderByDescending(o => o.NumberOfEvaluateStar).Take(2).ToList();
                    List<Tour> hotTour2 = tours.Where(o => o.IsDelete == 0 && o.MediumStar == hotValue[1]).OrderByDescending(o => o.NumberOfEvaluateStar).Take(1).ToList();
                    return Ok(hotTour1.Union(hotTour2).ToList());
                }
                else if(hotValue.Count == 2 && hotTours[1].MediumStar == hotTours[2].MediumStar)
                {
                    List<Tour> hotTour1 = tours.Where(o => o.IsDelete == 0 && o.MediumStar == hotTours[0].MediumStar).OrderByDescending(o => o.NumberOfEvaluateStar).Take(1).ToList();
                    List<Tour> hotTour2 = tours.Where(o => o.IsDelete == 0 && o.MediumStar == hotTours[2].MediumStar).OrderByDescending(o => o.NumberOfEvaluateStar).Take(2).ToList();
                    return Ok(hotTour1.Union(hotTour2).ToList());
                }
                else
                {
                    List<Tour> hotTour1 = tours.Where(o => o.IsDelete == 0 && o.MediumStar == hotTours[0].MediumStar).OrderByDescending(o => o.NumberOfEvaluateStar).Take(1).ToList();
                    List<Tour> hotTour2 = tours.Where(o => o.IsDelete == 0 && o.MediumStar == hotTours[1].MediumStar).OrderByDescending(o => o.NumberOfEvaluateStar).Take(1).ToList();
                    List<Tour> hotTour3 = tours.Where(o => o.IsDelete == 0 && o.MediumStar == hotTours[2].MediumStar).OrderByDescending(o => o.NumberOfEvaluateStar).Take(1).ToList();
                    return Ok(hotTour1.Union(hotTour2).Union(hotTour3).ToList());
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

    }
}
