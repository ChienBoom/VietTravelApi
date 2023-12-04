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
    [Route("city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        public DataContext _dataContext;
        public DeleteModels _deleteModels;
        private readonly IConfiguration _configuration;
        public int pageSize;
        public CityController(DataContext dataContext, IConfiguration configuration, DeleteModels deleteModels)
        {
            _dataContext = dataContext;
            _configuration = configuration;
            _deleteModels = deleteModels;
            pageSize = int.Parse(_configuration["PageSize"]);
        }

        [HttpGet]
        public IActionResult GetAllCity()
        {
            try
            {
                return Ok(_dataContext.City.Where(o => o.IsDelete == 0).OrderByDescending(o => o.MediumStar).ToList());
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
                int totalItem = _dataContext.City.Where(o => o.IsDelete == 0).Count();
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
                int totalItem = _dataContext.City.Where(b => b.UniCodeName.ToLower().Contains(value.ToLower()) && b.IsDelete == 0).Count();
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
        public IActionResult GetPageCity(int page)
        {
            try
            {
                return Ok(_dataContext.City.Where(o => o.IsDelete == 0).Skip((page - 1) * pageSize).Take(pageSize).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCityById(long id)
        {
            try
            {
                City city = _dataContext.City.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (city == null) return NotFound();
                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        //[HttpGet("search/{value}")]
        //public IActionResult SearchCity(string value)
        //{
        //    try
        //    {
        //        List<City> cities = _dataContext.City.Where(b => b.UniCodeName.ToLower().Contains(value.ToLower())).ToList();
        //        if (cities == null) return NotFound();
        //        return Ok(cities);
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
                List<City> cities = _dataContext.City.Where(b => b.UniCodeName.ToLower().Contains(value.ToLower()) && b.IsDelete == 0).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                if (cities == null) return NotFound();
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] City value)
        {
            City city = value;
            try
            {
                _dataContext.City.Add(city);
                _dataContext.SaveChanges();
                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] City value)
        {
            try
            {
                var City = _dataContext.City.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (City != null)
                {
                    if (value.Pictures.Equals("File null")) value.Pictures = City.Pictures;
                    value.NumberOfEvaluate = City.NumberOfEvaluate;
                    value.MediumStar = City.MediumStar;
                    value.Tours = City.Tours;
                    _dataContext.Entry(City).CurrentValues.SetValues(value);
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
                var City = _dataContext.City.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (City != null)
                {
                    //_dataContext.Remove(City);
                    City.IsDelete = 1;
                    _deleteModels.DeleteCity(id);
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
        [Route("hotCity")]
        public IActionResult HotCity()
        {
            try
            {
                List<City> cities = _dataContext.City.Where(o => o.IsDelete == 0).OrderByDescending(o => o.MediumStar * 0.6 + o.NumberOfEvaluate * 0.4).ToList();
                if (cities.Count < 3) return Ok(cities);
                List<City> hotCities = cities.Take(3).ToList();
                List<float> hotValue = new List<float> { hotCities[0].MediumStar, hotCities[1].MediumStar, hotCities[2].MediumStar };
                hotValue = hotValue.Distinct().ToList();
                if (hotValue.Count == 1)
                {
                    return Ok(cities.Where(o => o.IsDelete == 0 && o.MediumStar == hotCities[0].MediumStar).OrderByDescending(o => o.NumberOfEvaluateStar).Take(3).ToList());
                }
                else if (hotValue.Count == 2 && hotCities[0].MediumStar == hotCities[1].MediumStar)
                {
                    List<City> hotTour1 = cities.Where(o => o.IsDelete == 0 && o.MediumStar == hotCities[0].MediumStar).OrderByDescending(o => o.NumberOfEvaluateStar).Take(2).ToList();
                    List<City> hotTour2 = cities.Where(o => o.IsDelete == 0 && o.MediumStar == hotCities[2].MediumStar).OrderByDescending(o => o.NumberOfEvaluateStar).Take(1).ToList();
                    return Ok(hotTour1.Union(hotTour2).ToList());
                }
                else if (hotValue.Count == 2 && hotCities[1].MediumStar == hotCities[2].MediumStar)
                {
                    List<City> hotTour1 = cities.Where(o => o.IsDelete == 0 && o.MediumStar == hotCities[0].MediumStar).OrderByDescending(o => o.NumberOfEvaluateStar).Take(1).ToList();
                    List<City> hotTour2 = cities.Where(o => o.IsDelete == 0 && o.MediumStar == hotCities[1].MediumStar).OrderByDescending(o => o.NumberOfEvaluateStar).Take(2).ToList();
                    return Ok(hotTour1.Union(hotTour2).ToList());
                }
                else
                {
                    List<City> hotTour1 = cities.Where(o => o.IsDelete == 0 && o.MediumStar == hotCities[0].MediumStar).OrderByDescending(o => o.NumberOfEvaluateStar).Take(1).ToList();
                    List<City> hotTour2 = cities.Where(o => o.IsDelete == 0 && o.MediumStar == hotCities[1].MediumStar).OrderByDescending(o => o.NumberOfEvaluateStar).Take(1).ToList();
                    List<City> hotTour3 = cities.Where(o => o.IsDelete == 0 && o.MediumStar == hotCities[2].MediumStar).OrderByDescending(o => o.NumberOfEvaluateStar).Take(1).ToList();
                    return Ok(hotTour1.Union(hotTour2).Union(hotTour3).ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

    }
}
