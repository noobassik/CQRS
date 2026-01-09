using Application.Authentication.Services;
using CQRS.Application.Data.DataBaseContext;
using Infrastructure.Data.DataBaseContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructureServices(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("PostgresConnection");

			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseNpgsql(connectionString);
			});

			services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

			AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

			services.AddScoped<IJwtSecurityService, JwtSecurityService>();

			return services;
		}
	}
}
