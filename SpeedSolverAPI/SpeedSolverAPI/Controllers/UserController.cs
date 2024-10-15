using Microsoft.AspNetCore.Mvc;
using SpeedSolverCore;
using SpeedSolverDatabase;
using SpeedSolverDatabase.Models;
using SpeedSolverDatabase.Repo;
using SpeedSolverDatabase.Services;
using SpeedSolverDatabase.Services.abc;

namespace SpeedSolverAPI.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            UserService userService = new();
            
            var registeredUser = await userService.Register(registerRequest);

            if (registeredUser != null)
            {
                return Ok(registeredUser.UserId);
            }
            else
            {
                return BadRequest("This user still exists. Try new credentials.");
            }
        }
    }
}
