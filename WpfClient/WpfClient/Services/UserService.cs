using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WpfClient.Model;
using WpfClient.Services.Interfaces;

namespace WpfClient.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService()
        {
            _httpClient = new HttpClient();
        }
        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }


        public async Task<string> RegisterUserAsync(string login, string password)
        {
            var userDto = new
            {
                Login = login,
                Password = password
            };

            var jsonContent = new StringContent(
                JsonSerializer.Serialize(userDto),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5136/api/Users", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                return "Регистрация прошла успешно!";
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return $"Ошибка регистрации: {errorContent}";
            }
        }
    }
}
