using Api.Security.Services;
using Domain.Security;
using Domain.Security.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController(UserManager<CustomIdentityUser> manager,
		IJwtSecurityService jwtSecurityService) : ControllerBase
	{
		[HttpPost("login")]
		public async Task<IResult> login(LoginRequest dto)
		{
			var user = await manager.FindByEmailAsync(dto.Email);

			if (user is null)
			{
				return Results.Unauthorized();
			}

			var result = await manager.CheckPasswordAsync(user, dto.Password);
			
			if (result)
			{
				var response = new IdentityUserResponseDto(
					user.UserName, user.Email, jwtSecurityService.CreateToken(user)
				);
				return Results.Ok(new { result = response });
			}

			return Results.Unauthorized();
		}
	}
}
