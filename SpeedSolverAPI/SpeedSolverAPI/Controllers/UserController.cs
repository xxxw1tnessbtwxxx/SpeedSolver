using Microsoft.AspNetCore.Mvc;
using SpeedSolverCore;
using SpeedSolverDatabase;
using SpeedSolverDatabase.Repo;
using SpeedSolverDatabase.Services;
using SpeedSolverDatabase.Services.abc;

namespace SpeedSolverAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequests request)
        {
            try
            {
                IUserService service = new UserService(new UserRepository());
                await service.Register(request);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to register user");
            }

            return Ok("Success");
        }
        
    }
}
