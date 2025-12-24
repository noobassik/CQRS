using Infrastructure.Data.DataBaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Data.Extensions
{
    public static class DatabaseExtensions
    {
        public static async Task InitializeDatabaseAsync(this WebApplication app)
        {
            using IServiceScope scope = app.Services.CreateScope();
            var dbContext = scope
                .ServiceProvider
                .GetRequiredService<ApplicationDbContext>();
            await dbContext.Database.MigrateAsync();

            await SeedData(dbContext);
        }

        private static async Task SeedData(ApplicationDbContext dbContext)
        {
            await SeedTopicsAsync(dbContext);
        }

        private static async Task SeedTopicsAsync(ApplicationDbContext dbContext)
        {
            if (!await dbContext.Topics.AnyAsync())
            {
                await dbContext.Topics.AddRangeAsync(InitialData.Topics);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
