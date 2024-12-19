using api.Dtos.Account;
using CustomerApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        public AccountController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newUserDto = await _registerService.RegisterUserAsync(registerDto);

                if (newUserDto != null)
                {
                    return Ok(newUserDto);
                }
                else
                {
                    return StatusCode(500, "Failed to register user.");
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login(LoginDto loginDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);



        //}





    }
}
