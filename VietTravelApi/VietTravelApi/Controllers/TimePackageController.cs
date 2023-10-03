using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using VietTravelApi.Context;
using VietTravelApi.Models;

namespace VietTravelApi.Controllers
{
    [Route("timepackage")]
    [ApiController]
    public class TimePackageController : ControllerBase
    {
        public DataContext _dataContext;
        public TimePackageController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAllTimePackage()
        {
            try
            {
                return Ok(_dataContext.TimePackage.ToList());
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
                TimePackage TimePackage = _dataContext.TimePackage.FirstOrDefault(b => b.Id == id);
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
                var TimePackage = _dataContext.TimePackage.FirstOrDefault(b => b.Id == id);
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
                var TimePackage = _dataContext.TimePackage.FirstOrDefault(b => b.Id == id);
                if (TimePackage != null)
                {
                    _dataContext.Remove(TimePackage);
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
