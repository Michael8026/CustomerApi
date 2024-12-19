using api.Dtos.Account;
using CustomerApi.Interfaces;
using System.Text;
using System.Text.Json;

namespace CustomerApi
{
    public class RegisterService : IRegisterService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RegisterService> _logger;

        public RegisterService(HttpClient httpClient, ILogger<RegisterService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
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
    }

}
