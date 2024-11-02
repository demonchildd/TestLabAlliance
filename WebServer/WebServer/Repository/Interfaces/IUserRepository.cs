using WebServer.Model;

namespace WebServer.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAsync();

        Task<User> GetByLoginAsync(string login);

        Task AddAsync(User user);

        
    }
}
