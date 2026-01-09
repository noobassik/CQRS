using Domain.Security;
using Infrastructure.Data.DataBaseContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
				options.User.RequireUniqueEmail = true;
			})
			.AddEntityFrameworkStores<ApplicationDbContext>();

			string secretKey = config["AuthSettings:SecretKey"]!;

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = key,
					ValidateLifetime = true,
					ValidateIssuer = false,
					ValidateAudience = false,
					ClockSkew = TimeSpan.Zero
				};
			});

			return services;
		}
	}
}
