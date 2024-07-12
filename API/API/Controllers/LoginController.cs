using API.JWT;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JwtTokenService _jwtTokenService;

        public LoginController(JwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string name)
        {
            if (!name.Equals("ok"))
                return BadRequest();
            var token = _jwtTokenService.GenerateToken(name);
            return Ok(new { Token = token });
        }
    }
}
