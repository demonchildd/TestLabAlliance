using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient.Model
{
    public class User
    {
        public static User Current { get; set; }
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }


    }
}
