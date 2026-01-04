using Api.Exceptions.Handler;

namespace Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddExceptionHandler<CustomExceptionHandler>();
            services.AddControllers();
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

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
