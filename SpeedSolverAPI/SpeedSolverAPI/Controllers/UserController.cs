using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using SpeedSolverCore;
using SpeedSolverCore.DTO.User;
using SpeedSolverDatabase.Models;
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
            var authResult = await UserService.Create().Authorize(loginRequest);

            if (authResult.IsFailure) return BadRequest(authResult.Error);
            return Ok(new UserDto
            {
                UserId = authResult.Value.UserId,
                Name = authResult.Value.Name,
                Surname = authResult.Value.Surname,
                Patronymic = authResult.Value.Patronymic,
                Invites = authResult.Value.Invites,
                Teams = authResult.Value.Teams,
                ProjectModerated = authResult.Value.ProjectModerated,
            });
        }
    }
}
