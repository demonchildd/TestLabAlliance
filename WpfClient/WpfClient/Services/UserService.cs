using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
        public async Task<List<User>> GetUsersAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5136/api/Users");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (content == "[]")
                {
                    throw new Exception("Ответ от сервера пустой или равен null.");
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                
                return JsonSerializer.Deserialize<List<User>>(content, options);
            }
            else
            {
                throw new Exception($"Ошибка запроса: {response.ReasonPhrase}");
            }
        }



        public async Task<string> RegisterUserAsync(string login, string password)
        {
            try
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
            catch (HttpRequestException ex)
            {
                return $"Ошибка при попытке соединения с сервером: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Произошла непредвиденная ошибка: {ex.Message}";
            }
        }
    }
}
