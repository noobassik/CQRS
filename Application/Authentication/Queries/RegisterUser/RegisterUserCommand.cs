using Application.Authentication.Dtos;

namespace Application.Authentication.Queries.RegisterUser
{
	public record RegisterUserCommand(RegisterUserDto RegisterDto)
		: ICommand<RegisterUserResult>;

	public record RegisterUserResult(AuthenticationResponseDto Response);
}