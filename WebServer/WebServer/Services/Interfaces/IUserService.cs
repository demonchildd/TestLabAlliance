using WebServer.Model;
using WebServer.Model.Dto;

namespace WebServer.Services.Interfaces
{
    public interface IUserService
    {
        Task RegistrationAsync(UserDto user);

        Task<List<User>> GetUsersAsync();
    }
}
