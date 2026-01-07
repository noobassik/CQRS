using Domain.Security;
using Infrastructure.Data.DataBaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
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

            var manager = scope
                .ServiceProvider
                .GetRequiredService<UserManager<CustomIdentityUser>>();

            await dbContext.Database.MigrateAsync();

            await SeedData(dbContext, manager);
        }

        private static async Task SeedData(ApplicationDbContext dbContext, UserManager<CustomIdentityUser> manager)
        {
            await SeedTopicsAsync(dbContext);
            await SeedIdentityUsersAsync(dbContext, manager);
        }

        private static async Task SeedTopicsAsync(ApplicationDbContext dbContext)
        {
            if (!await dbContext.Topics.AnyAsync())
            {
                await dbContext.Topics.AddRangeAsync(InitialData.Topics);
                await dbContext.SaveChangesAsync();
            }
        }

        private static async Task SeedIdentityUsersAsync(ApplicationDbContext dbContext,
            UserManager<CustomIdentityUser> manager)
        {
            if (!manager.Users.Any())
            {
                foreach (var user in InitialData.IdentityUsers)
                {
                    await manager.CreateAsync(user, "1111");
                }
            }
        }
	}
}
