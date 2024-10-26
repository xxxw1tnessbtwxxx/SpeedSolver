using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using SpeedSolverCore;
using SpeedSolverCore.DTO.User;
using SpeedSolverCore.JwtProvider;
using SpeedSolverDatabase.Models;
using SpeedSolverDatabaseAccess.Services;

namespace SpeedSolverAPI.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController(IMapper mapper) : ControllerBase
    {

        private readonly IMapper _mapper = mapper;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterRequest registerRequest)
        {
            var registerResult = await UserService
                .Create()
                .Register(registerRequest);

            if (registerResult.IsSuccess) return Ok(registerResult.Value);
            return BadRequest(registerResult.Error);
        }

        [HttpPost("jwtauthorize")]
        public async Task<IActionResult> JwtAuthorize(AuthorizeRequest authorizeRequest)
        {
            var authResult = await UserService.Create().Authorize(authorizeRequest);

            if (authResult.IsFailure)
                return BadRequest(authResult.Error);

            
            return Ok(new JwtProvider().GenerateJwtToken(authResult.Value));
        }
        
        
        [HttpPost("authorize")]
        public async Task<IActionResult> Authorize(AuthorizeRequest loginRequest)
        {
            var authResult = await UserService.Create().Authorize(loginRequest);

            if (authResult.IsFailure) return BadRequest(authResult.Error);
            return Ok(_mapper.Map<User>(authResult.Value));
        }
    }
}
