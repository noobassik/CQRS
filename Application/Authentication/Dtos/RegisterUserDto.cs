namespace Application.Authentication.Dtos
{
	public record RegisterUserDto(
		  string FullName,
		  string Username,
		  string Email,
		  string Password
	  );
}
