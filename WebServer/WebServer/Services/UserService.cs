using WebServer.Exceptions;
using WebServer.Model;
using WebServer.Model.Dto;
using WebServer.Repository.Interfaces;
using WebServer.Services.Interfaces;
using WebServer.Tools;

namespace WebServer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        

        public UserService(IUserRepository repository) {
            _repository = repository;
        }
        public async Task<List<User>> GetUsersAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task RegistrationAsync(UserDto user)
        {
            if (user == null) {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            var check = await _repository.GetByLoginAsync(user.Login);
            if (check != null)
            {
                throw new UserAlreadyExistsException("User with this email or username already exists.");
            }
            
            var User = new User();
            User.Login = user.Login;
            User.Password = HashHelper.HashPassword(user.Password);

            await _repository.AddAsync(User);
        }
    }
}
