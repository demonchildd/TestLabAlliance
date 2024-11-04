using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WebServer.Model.Dto;
using WebServer.Services.Interfaces;

namespace WebServer.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto user)
        {
            var token = await _userService.ValidateUserAsync(user);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { access_token = token });
        }
    }
}
