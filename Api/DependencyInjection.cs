using Api.Exceptions.Handler;
using Api.Security.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddExceptionHandler<CustomExceptionHandler>();
            services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddOpenApi();

            services.AddCors(options =>
            {
                options.AddPolicy("react-policy", policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("http://localhost:3000");
                });
            });

            services.AddMediatR(config => config
                .RegisterServicesFromAssemblies(typeof(GetTopicsHandler).Assembly));

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddIdentityServices(configuration);

            return services;
        }

        public static WebApplication UserApiServices(this WebApplication app) 
        {
            app.UseCors("react-policy");

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
            app.UseExceptionHandler(options => { });

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
