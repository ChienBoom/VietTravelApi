using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Linq;
using System.Threading.Tasks;
using VietTravelApi.Context;
using VietTravelApi.Models;

namespace VietTravelApi.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public DataContext _dataContext;
        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            try
            {
                return Ok(_dataContext.User.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(long id)
        {
            try
            {
                User User = _dataContext.User.FirstOrDefault(b => b.Id == id);
                if (User == null) return NotFound();
                return Ok(User);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        //[HttpGet("search/{value}")]
        //public IActionResult SearchUser(string value)
        //{
        //    try
        //    {
        //        User User = _dataContext.User.FirstOrDefault(b => b.Name == value);
        //        if (User == null) return NotFound();
        //        return Ok(User);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            User User = value;
            try
            {
                _dataContext.User.Add(User);
                _dataContext.SaveChanges();
                return Ok(User);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] User value)
        {
            try
            {
                var User = _dataContext.User.FirstOrDefault(b => b.Id == id);
                if (User != null)
                {
                    _dataContext.Entry(User).CurrentValues.SetValues(value);
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
                var User = _dataContext.User.FirstOrDefault(b => b.Id == id);
                if (User != null)
                {
                    _dataContext.Remove(User);
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

        [HttpPost("/checkEmailExis")]
        public async Task<IActionResult> checkEmailExis([FromBody] Account value)
        {
            try
            {
                var User = _dataContext.User.FirstOrDefault(b => b.Username == value.Username);
                if (User != null)
                {
                    return Ok(value);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("/checkLogin")]
        public async Task<IActionResult> checkAccountLogin([FromBody] Account value)
        {
            try
            {
                var User = _dataContext.User.FirstOrDefault(b => b.Username == value.Username);
                if (User != null)
                {
                    if (value.Password == User.Password)
                    {
                        return Ok(User.Role);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
