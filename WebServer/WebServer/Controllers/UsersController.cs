using Microsoft.AspNetCore.Mvc;
using WebServer.Model.Dto;
using WebServer.Services.Interfaces;

namespace WebServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;
        public UsersController(IUserService userService) {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers() 
        {
            return Ok(await _userService.GetUsersAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDto user)
        {
            await _userService.RegistrationAsync(user);
            return Ok();
        }
    }
}
