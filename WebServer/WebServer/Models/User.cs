using System.ComponentModel.DataAnnotations;

namespace WebServer.Model
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }


       


    }
}
