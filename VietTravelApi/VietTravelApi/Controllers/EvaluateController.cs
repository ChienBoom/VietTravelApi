using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet]
        public IActionResult GetAllEvaluate()
        {
            try
            {
                return Ok(_dataContext.Evaluate.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEvaluateById(long id)
        {
            try
            {
                Evaluate Evaluate = _dataContext.Evaluate.FirstOrDefault(b => b.Id == id);
                if (Evaluate == null) return NotFound();
                return Ok(Evaluate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        //[HttpGet("search/{value}")]
        //public IActionResult SearchEvaluate(string value)
        //{
        //    try
        //    {
        //        Evaluate Evaluate = _dataContext.Evaluate.FirstOrDefault(b => b.Name == value);
        //        if (Evaluate == null) return NotFound();
        //        return Ok(Evaluate);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        [HttpPost]
        public IActionResult Post([FromBody] Evaluate value)
        {
            Evaluate Evaluate = value;
            try
            {
                _dataContext.Evaluate.Add(Evaluate);
                _dataContext.SaveChanges();
                return Ok(Evaluate);
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
                var Evaluate = _dataContext.Evaluate.FirstOrDefault(b => b.Id == id);
                if (Evaluate != null)
                {
                    _dataContext.Entry(Evaluate).CurrentValues.SetValues(value);
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
                var Evaluate = _dataContext.Evaluate.FirstOrDefault(b => b.Id == id);
                if (Evaluate != null)
                {
                    _dataContext.Remove(Evaluate);
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
