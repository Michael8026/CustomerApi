using api.Dtos.Account;
using CustomerApi.Models;

namespace CustomerApi.Interfaces
{
    public interface IAccountService
    {
        Task<List<UserProfile>> GetAllUsersAsync();
        Task<NewUserDto> RegisterUserAsync(RegisterDto registerDto);
    }
}
