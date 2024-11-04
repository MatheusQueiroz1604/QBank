using Microsoft.AspNetCore.Mvc;
using QBank.Services;
using QBank.Models;

namespace QBank.Controllers
{
    [Route("authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;
        private readonly UserService _userService;

        public AuthenticationController(AuthenticationService authenticationService, UserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.email) || string.IsNullOrWhiteSpace(request.password))
            {
                return BadRequest("Email and password are required."); // 400 Bad Request
            }

            var user = _userService.ValidateUser(request.email!, request.password!);
            if (user == null)
            {
                return Unauthorized(); // 401 Unauthorized
            }

            // Gere um token
            var token = _authenticationService.GenerateToken(user.userId);
            _authenticationService.PrintActiveTokens();
            return Ok(new { Token = token, userId = user.userId });
        }
    }

    public class LoginRequest
    {
        public string? email { get; set; }
        public string? password { get; set; }
    }
}