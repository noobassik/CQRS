using Application.Authentication.Dtos;
using Application.Authentication.Services;
using Domain.Security;
using Microsoft.AspNetCore.Identity;

namespace Application.Authentication.Queries.RegisterUser
{
	public class RegisterUserHandler(
		   UserManager<CustomIdentityUser> userManager,
		   IJwtSecurityService jwtSecurityService)
		   : ICommandHandler<RegisterUserCommand, RegisterUserResult>
	{
		public async Task<RegisterUserResult> Handle(
			RegisterUserCommand request,
			CancellationToken cancellationToken)
		{
			var dto = request.RegisterDto;

			if (await userManager.Users.AnyAsync(
				u => u.UserName == dto.Username,
				cancellationToken))
			{
				throw new InvalidOperationException(
					$"Пользователь с именем '{dto.Username}' уже существует");
			}

			if (await userManager.Users.AnyAsync(
				u => u.Email == dto.Email,
				cancellationToken))
			{
				throw new InvalidOperationException(
					$"Email '{dto.Email}' уже используется");
			}

			var user = new CustomIdentityUser
			{
				FullName = dto.FullName,
				Email = dto.Email,
				UserName = dto.Username,
				About = string.Empty
			};

			var result = await userManager.CreateAsync(user, dto.Password);

			if (!result.Succeeded)
			{
				var errors = string.Join(", ", result.Errors.Select(e => e.Description));
				throw new InvalidOperationException(
					$"Не удалось создать пользователя: {errors}");
			}

			var token = jwtSecurityService.CreateToken(user);

			var response = new AuthenticationResponseDto(
				user.UserName!,
				user.Email!,
				token
			);

			return new RegisterUserResult(response);
		}
	}
}