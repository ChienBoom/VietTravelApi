using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VietTravelApi.Common;
using VietTravelApi.Models;

namespace VietTravelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly Jwt _jwt;
        public AuthController(Jwt jwt)
        {
            _jwt = jwt;
        }
        [HttpGet]
        [Route("test/{username}/{role}")]
        public IActionResult CreateToken(string username, string role)
        {
            try
            {
                JwtData data = new JwtData();
                data.Username = username;
                data.Role = role;
                string token = _jwt.CreateToken(data);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
        [HttpGet]
        [Route("test/{token}")]
        public IActionResult ConfirmUser(string token)
        {
            try
            {
                if (_jwt.Auth("cus", token)) return Ok("Success");
                return Ok("Faild");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

    }
}
