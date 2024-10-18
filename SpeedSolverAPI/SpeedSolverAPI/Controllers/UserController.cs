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
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            
            var registeredUser = await UserService
                .Create()
                .Register(registerRequest);

            if (registeredUser != null)
            {
                return Ok(registeredUser.UserId);
            }

            return BadRequest("This user still exists. Try new credentials.");

        }

        [HttpPost("authorize")]
        public async Task<IActionResult> Authorize(AuthorizeRequest loginRequest)
        {

            User? user = null;

            try
            {
                user = await UserService.Create().Authorize(loginRequest);
            }
            catch(FailedLoginException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(user);
        }
    }
}
