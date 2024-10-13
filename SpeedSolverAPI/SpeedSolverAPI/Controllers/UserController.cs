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
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult> Register()
        {

            using var ctx = new SpeedContext();

            try
            {
                ctx.Users.Add(new User
                {
                    Login = "123",
                    Password = "123"
                });
                ctx.SaveChanges();
                return Ok("Added. Check it manually");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("findall")]
        public async Task<ActionResult> FindAll()
        {
            return Ok(new SpeedContext().Users.ToList());
        }
        
    }
}
