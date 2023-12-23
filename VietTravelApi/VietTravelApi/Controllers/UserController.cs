using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Linq;
using System.Threading.Tasks;
using VietTravelApi.Common;
using VietTravelApi.Context;
using VietTravelApi.Models;
using VietTravelApi.Service;

namespace VietTravelApi.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public DataContext _dataContext;
        private readonly ISendMailService _sendMailService;
        public DeleteModels _deleteModels;
        public Jwt _jwt;
        public UserController(DataContext dataContext, ISendMailService sendMailService, DeleteModels deleteModels, Jwt jwt)
        {
            _dataContext = dataContext;
            _sendMailService = sendMailService;
            _deleteModels = deleteModels;
            _jwt = jwt;
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            try
            {
                string token = HttpContext.Request.Headers["Authorization"];
                bool test = _jwt.Auth("Admin", token);
                if (token == null || !_jwt.Auth("Admin", token)) return Unauthorized("Yêu cầu xác thực người dùng");
                return Ok(_dataContext.User.Where(o => o.IsDelete == 0).ToList());
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
                string token = HttpContext.Request.Headers["Authorization"];
                if (token == null || !_jwt.Auth("Admin", token)) return Unauthorized("Yêu cầu xác thực người dùng");
                User User = _dataContext.User.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (User == null) return NotFound();
                return Ok(User);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("searchUserByUsername/{username}")]
        public IActionResult GetUserByUsername(string username)
        {
            try
            {
                User User = _dataContext.User.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Username == username);
                if (User == null) return NotFound();
                return Ok(User);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

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
                string token = HttpContext.Request.Headers["Authorization"];
                if (token == null || (!_jwt.Auth("Customer", token) && !_jwt.Auth("Admin", token))) return Unauthorized("Yêu cầu xác thực người dùng");
                var User = _dataContext.User.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (User != null)
                {
                    if (value.Picture == "File null") value.Picture = User.Picture;
                    value.Username = User.Username;
                    value.Password = User.Password;
                    value.Role = User.Role;
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
                string token = HttpContext.Request.Headers["Authorization"];
                if (token == null || (!_jwt.Auth("Customer", token) && !_jwt.Auth("Admin", token))) return Unauthorized("Yêu cầu xác thực người dùng");
                var User = _dataContext.User.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Id == id);
                if (User != null)
                {
                    //_dataContext.Remove(User);
                    User.IsDelete = 1;
                    _deleteModels.DeleteUser(id);
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
                var User = _dataContext.User.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Username == value.Username);
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
                var User = _dataContext.User.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Username == value.Username);
                if (User != null)
                {
                    if (value.Password == User.Password)
                    {
                        JwtData jwtData = new JwtData();
                        jwtData.Username = User.Username;
                        jwtData.Role = User.Role;
                        string token = _jwt.CreateToken(jwtData);
                        HttpContext.Response.Headers.Add("Authorization", token);
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

        [HttpPost("/recoverPassword")]
        public async Task<IActionResult> RecoverPassword([FromBody] Account value)
        {
            try
            {
                var User = _dataContext.User.Where(o => o.IsDelete == 0).FirstOrDefault(b => b.Username == value.Username);
                if (User != null)
                {
                    MailContent content = new MailContent
                    {
                        To = value.Username,
                        Subject = "VietTravel - Xác minh mật khẩu",
                        Body = "Mật khẩu của bạn là:" + User.Password
                    };
                    _sendMailService.SendMail(content);
                    return Ok();
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

        [HttpGet]
        [Route("updatePassword/{userName}/{oldPassword}/{newPassword}")]
        public async Task<IActionResult> UpdatePassword(string userName, string oldPassword, string newPassword)
        {
            try
            {
                string token = HttpContext.Request.Headers["Authorization"];
                if (token == null || (!_jwt.Auth("Customer", token) && !_jwt.Auth("Admin", token))) return Unauthorized("Yêu cầu xác thực người dùng");
                User user = _dataContext.User.FirstOrDefault(o => o.Username.Equals(userName) && o.Password.Equals(oldPassword));
                if (user == null) return NotFound();
                else
                {
                    user.Password = newPassword;
                    _dataContext.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
