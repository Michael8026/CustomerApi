using api.Dtos.Account;
using CustomerApi.Interfaces;
using CustomerApi.Models;
using System.Text;
using System.Text.Json;

namespace CustomerApi
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<NewUserDto> RegisterUserAsync(RegisterDto registerDto)
        {
            var apiUrl = "http://localhost:5076/api/accounts/register";

            var jsonPayload = JsonSerializer.Serialize(registerDto);

            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    var newUserDto = JsonSerializer.Deserialize<NewUserDto>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return newUserDto;

                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();

                    throw new Exception($"Failed to register user. Status: {response.StatusCode}, Error: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while registering the user.", ex);
            }
        }

        public async Task<List<UserProfile>> GetAllUsersAsync()
        {
            try
            {
                var apiUrl = "http://localhost:5076/api/accounts";

                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    var data = JsonSerializer.Deserialize<List<UserProfile>>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return data ?? new List<UserProfile>();
                }
                else
                {
                    throw new Exception($"Failed to get data. Status: {response.StatusCode}, Content: {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while calling the external API", ex);
            }
        }

    }
}
