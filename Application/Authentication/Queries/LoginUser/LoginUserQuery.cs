using Application.Authentication.Dtos;

namespace Application.Authentication.Queries.LoginUser
{
	public record LoginUserQuery(LoginUserDto LoginDto) : IQuery<LoginUserResult>;

	public record LoginUserResult(AuthenticationResponseDto Response);
}