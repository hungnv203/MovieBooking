using Microsoft.AspNetCore.Mvc;
using WS.Movie.ApplicationService.Service.Implement;
using WS.Movie.Dtos;

namespace WSWEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;

        public AuthController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var (user, token) = await _authenticationService.LoginAsync(loginDto);
                return Ok(new { user, token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
