using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using VietTravelApi.Common;
using VietTravelApi.Context;
using VietTravelApi.Models;

namespace VietTravelApi.Controllers
{
    [Route("timepackage")]
    [ApiController]
    public class TimePackageController : ControllerBase
    {
        public DataContext _dataContext;
        public Jwt _jwt;
        public TimePackageController(DataContext dataContext, Jwt jwt)
        {
            _dataContext = dataContext;
            _jwt = jwt;
        }

        [HttpGet]
        public IActionResult GetAllTimePackage()
        {
            try
            {
                return Ok(_dataContext.TimePackage.Where(o => o.IsDelete == 0).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTimePackageById(long id)
        {
            try
            {
                TimePackage TimePackage = _dataContext.TimePackage.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (TimePackage == null) return NotFound();
                return Ok(TimePackage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        //[HttpGet("search/{value}")]
        //public IActionResult SearchTimePackage(string value)
        //{
        //    try
        //    {
        //        TimePackage TimePackage = _dataContext.TimePackage.FirstOrDefault(b => b.Name == value);
        //        if (TimePackage == null) return NotFound();
        //        return Ok(TimePackage);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        [HttpPost]
        public IActionResult Post([FromBody] TimePackage value)
        {
            TimePackage TimePackage = value;
            try
            {
                string token = HttpContext.Request.Headers["Authorization"];
                if (token == null || !_jwt.Auth("Admin", token)) return Unauthorized("Yêu cầu xác thực người dùng");
                _dataContext.TimePackage.Add(TimePackage);
                _dataContext.SaveChanges();
                return Ok(TimePackage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] TimePackage value)
        {
            try
            {
                string token = HttpContext.Request.Headers["Authorization"];
                if (token == null || !_jwt.Auth("Admin", token)) return Unauthorized("Yêu cầu xác thực người dùng");
                var TimePackage = _dataContext.TimePackage.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (TimePackage != null)
                {
                    _dataContext.Entry(TimePackage).CurrentValues.SetValues(value);
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
                if (token == null || !_jwt.Auth("Admin", token)) return Unauthorized("Yêu cầu xác thực người dùng");
                var TimePackage = _dataContext.TimePackage.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (TimePackage != null)
                {
                    //_dataContext.Remove(TimePackage);
                    TimePackage.IsDelete = 1;
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
