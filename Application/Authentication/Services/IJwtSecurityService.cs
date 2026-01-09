using Domain.Security;

namespace Application.Authentication.Services
{
	public interface IJwtSecurityService
	{
		string CreateToken(CustomIdentityUser user);
	}
}
