using Application.Authentication.Dtos;
using Application.Authentication.Services;
using Domain.Security;
using Microsoft.AspNetCore.Identity;

namespace Application.Authentication.Queries.LoginUser
{
	public class LoginUserHandler(
		  UserManager<CustomIdentityUser> userManager,
		  IJwtSecurityService jwtSecurityService)
		  : IQueryHandler<LoginUserQuery, LoginUserResult>
	{
		public async Task<LoginUserResult> Handle(
			LoginUserQuery request,
			CancellationToken cancellationToken)
		{
			var user = await userManager.FindByEmailAsync(request.LoginDto.Email);

			if (user is null)
			{
				throw new UnauthorizedAccessException("Неверный email или пароль");
			}

			var isPasswordValid = await userManager.CheckPasswordAsync(
				user,
				request.LoginDto.Password);

			if (!isPasswordValid)
			{
				throw new UnauthorizedAccessException("Неверный email или пароль");
			}

			var token = jwtSecurityService.CreateToken(user);

			var response = new AuthenticationResponseDto(
				user.UserName!,
				user.Email!,
				token
			);

			return new LoginUserResult(response);
		}
	}
}
