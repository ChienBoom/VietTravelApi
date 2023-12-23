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
    [Route("tourpackage")]
    [ApiController]
    public class TourPackageController : ControllerBase
    {
        public DataContext _dataContext;
        public Jwt _jwt;
        public TourPackageController(DataContext dataContext, Jwt jwt)
        {
            _dataContext = dataContext;
            _jwt = jwt;
        }

        [HttpGet]
        public IActionResult GetAllTourPackage()
        {
            try
            {
                return Ok(_dataContext.TourPackage.Where(o => o.IsDelete == 0).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTourPackageById(long id)
        {
            try
            {
                TourPackage TourPackage = _dataContext.TourPackage.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (TourPackage == null) return NotFound();
                return Ok(TourPackage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("searchByTourId/{value}")]
        public IActionResult SearchTourPackageByTourId(string value)
        {
            try
            {
                List<TourPackage> tourPackages = _dataContext.TourPackage.Where(b => b.TourId == long.Parse(value) && b.IsDelete == 0).ToList();
                return Ok(tourPackages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        //[HttpGet("search/{value}")]
        //public IActionResult SearchTourPackage(string value)
        //{
        //    try
        //    {
        //        TourPackage TourPackage = _dataContext.TourPackage.FirstOrDefault(b => b.Name == value);
        //        if (TourPackage == null) return NotFound();
        //        return Ok(TourPackage);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        [HttpPost]
        public IActionResult Post([FromBody] TourPackage value)
        {
            TourPackage TourPackage = value;
            try
            {
                string token = HttpContext.Request.Headers["Authorization"];
                if (token == null || (!_jwt.Auth("Admin", token) && !_jwt.Auth("Customer", token))) return Unauthorized("Yêu cầu xác thực người dùng");
                _dataContext.TourPackage.Add(TourPackage);
                _dataContext.SaveChanges();
                return Ok(TourPackage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] TourPackage value)
        {
            try
            {
                string token = HttpContext.Request.Headers["Authorization"];
                if (token == null || (!_jwt.Auth("Admin", token) && !_jwt.Auth("Customer", token))) return Unauthorized("Yêu cầu xác thực người dùng");
                var TourPackage = _dataContext.TourPackage.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (TourPackage != null)
                {
                    _dataContext.Entry(TourPackage).CurrentValues.SetValues(value);
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
                if (token == null || (!_jwt.Auth("Admin", token) && !_jwt.Auth("Customer", token))) return Unauthorized("Yêu cầu xác thực người dùng");
                var TourPackage = _dataContext.TourPackage.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (TourPackage != null)
                {
                    //_dataContext.Remove(TourPackage);
                    TourPackage.IsDelete = 1;
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
