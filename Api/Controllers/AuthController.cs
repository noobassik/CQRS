using Application.Authentication.Dtos;
using Application.Authentication.Queries.LoginUser;
using Application.Authentication.Queries.RegisterUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	 [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthenticationResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
        {
            var query = new LoginUserQuery(dto);
            var result = await mediator.Send(query);
            
            return Ok(new { result = result.Response });
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(AuthenticationResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            var command = new RegisterUserCommand(dto);
            var result = await mediator.Send(command);
            
            return Ok(new { result = result.Response });
        }
    }
}
