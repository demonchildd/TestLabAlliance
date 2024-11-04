using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        private readonly IConfiguration _configuration;


        public UserService(IUserRepository repository, IConfiguration configuration) {
            _repository = repository;
            _configuration = configuration;
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


        public async Task<string> ValidateUserAsync(UserDto user)
        {
            var check = await _repository.GetByLoginAsync(user.Login);
            if (check != null && HashHelper.VerifyPassword(user.Password, check.Password))
            {

                return "token";
            }

            return null;
        }

        private string GenerateJwtToken(User user)
        {
            // Получаем секретный ключ из конфигурации
            var secretKey = _configuration["JwtSettings:SecretKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Создаем список утверждений (claims)
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Login),
            new Claim("custom-claim", "custom-value") // Дополнительное утверждение, если нужно
        };

            // Создаем токен
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60), // Время жизни токена
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token); // Генерация строки токена
        }
    }
}
