namespace Domain.Security.Dtos
{
	public record IdentityUserResponseDto(
		string Username,
		string Email,
		string JwtToken
	);
}
