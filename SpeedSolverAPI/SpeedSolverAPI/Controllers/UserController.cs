using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using SpeedSolverCore;
using SpeedSolverDatabase.Models;
using SpeedSolverDatabase.Repo.Exceptions;
using SpeedSolverDatabaseAccess.Services;

namespace SpeedSolverAPI.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterRequest registerRequest)
        {
            var registerResult = await UserService
                .Create()
                .Register(registerRequest);

            if (registerResult.IsSuccess) return Ok(registerResult.Value);
            return BadRequest(registerResult.Error);
        }

        [HttpPost("authorize")]
        public async Task<IActionResult> Authorize(AuthorizeRequest loginRequest)
        {
            return NotFound();
        }
    }
}
