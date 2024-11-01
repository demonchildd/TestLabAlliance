using Microsoft.AspNetCore.Mvc;

namespace WebServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("Users")]
        public IActionResult GetUsers() 
        {
            return Ok();
        }
    }
}
