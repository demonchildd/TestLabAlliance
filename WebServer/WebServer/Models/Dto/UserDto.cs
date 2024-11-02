using System.ComponentModel.DataAnnotations;

namespace WebServer.Model.Dto
{
    public class UserDto
    {
       
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
