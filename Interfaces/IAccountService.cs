using api.Dtos.Account;
using CustomerApi.Dtos.Account;
using CustomerApi.Models;

namespace CustomerApi.Interfaces
{
    public interface IAccountService
    {
        Task DeleteUserAsync(string id);
        Task<List<UserProfile>> GetAllUsersAsync();
        Task<UserProfile> GetUserByEmailAsync(string email);
        Task<NewUserDto> RegisterUserAsync(RegisterDto registerDto);
        Task UpdateUserAsync(string id, UpdateUserDto updateUserDto);
    }
}
