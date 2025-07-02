using ApplicationLayer.Models.InputModels;
using BusinessLayer.AuthServices;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers.Auth
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            var errors = await _authService.Register(register);

            if (errors != null)
            {
                List<string> errorMessages = new List<string>();
                foreach (var error in errors)
                {
                    errorMessages.Add(error.Description);
                }

                if (errorMessages.Count > 0)
                    return BadRequest(new { Errors = errorMessages });
            }

            return Ok(new { Message = "Registration successful" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var result = await _authService.Login(login);

            if (result is string errorMessage)
            {
                return BadRequest(new { Error = errorMessage });
            }

            return Ok(result);
        }
    }
}
