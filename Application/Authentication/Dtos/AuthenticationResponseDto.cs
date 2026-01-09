namespace Application.Authentication.Dtos
{
	public record AuthenticationResponseDto(
		string Username,
		string Email,
		string Token
	);
}
