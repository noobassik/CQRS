using Domain.Security;
using Infrastructure.Data.DataBaseContext;

namespace Api.Security.Extensions
{
	public static class IdentityOptionExtension
	{
		public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
		{
			services.AddIdentityCore<CustomIdentityUser>(options =>
			{
				options.Password.RequireDigit = false;
				options.Password.RequiredLength = 1;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireNonAlphanumeric = false;
			})
			.AddEntityFrameworkStores<ApplicationDbContext>();

			services.AddAuthentication();

			return services;
		}

	}
}
