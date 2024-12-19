using api.Dtos.Account;

namespace CustomerApi.Interfaces
{
    public interface IRegisterService
    {
        Task<NewUserDto> RegisterUserAsync(RegisterDto registerDto);
    }
}
