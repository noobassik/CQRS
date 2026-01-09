using Domain.Security;

namespace Api.Security.Services
{
	public interface IJwtSecurityService
	{
		string CreateToken(CustomIdentityUser user);
	}
}
