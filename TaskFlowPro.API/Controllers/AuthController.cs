using Microsoft.AspNetCore.Mvc;
using TaskFlowPro.API.DTOs;
using TaskFlowPro.API.Services;
using TaskFlowPro.API.Helpers;

namespace TaskFlowPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _authService.Login(loginDto);

            if (user == null)
            {
                return Unauthorized(new ApiResponse<object>(
                    false,
                    "Invalid email or password.",
                    null
                ));
            }

            var token = _authService.GenerateToken(user);

            return Ok(new ApiResponse<object>(
                true,
                "Login successful.",
                new
                {
                    Token = token
                }
            ));
        }
    }
}