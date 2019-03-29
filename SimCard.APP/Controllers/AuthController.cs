using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Models;
using SimCard.APP.Persistence.Services;
using SimCard.APP.ViewModels;

using System.Threading.Tasks;

namespace SimCard.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody]LoginViewModel loginViewModel)
        {
            UserViewModel user = await _authService.Authenticate(loginViewModel);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(user);
        }
    }
}
