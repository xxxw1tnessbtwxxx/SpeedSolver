using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using SpeedSolverCore;
using SpeedSolverCore.DTO.User;
using SpeedSolverCore.JwtProvider;
using SpeedSolverDatabase.Models;
using SpeedSolverDatabaseAccess.Repo.abc;
using SpeedSolverDatabaseAccess.Services;
using SpeedSolverDatabaseAccess.Services.abc;

namespace SpeedSolverAPI.Controllers
{
    [ApiController]
    [Route("speedsolver/api/v1/users")]
    public class UserController(IMapper mapper, Service<UserEntity> service) : ControllerBase
    {

        private readonly IMapper _mapper = mapper;
        private readonly Service<UserEntity> _userService;
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
        public async Task<IActionResult> JwtAuthorize(AuthorizeRequest authorizeRequest)
        {
            var authResult = await UserService.Create().Authorize(authorizeRequest);

            if (authResult.IsFailure)
                return BadRequest(authResult.Error);

            
            return Ok(new JwtProvider().GenerateJwtToken(_mapper.Map<User>(authResult.Value)));
        }
    }
}
