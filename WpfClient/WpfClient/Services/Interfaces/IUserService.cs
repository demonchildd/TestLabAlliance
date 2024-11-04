using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfClient.Model;

namespace WpfClient.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();

        Task<string> RegisterUserAsync(string login, string password);
    }
}
