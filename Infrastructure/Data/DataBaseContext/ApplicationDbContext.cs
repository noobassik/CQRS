using CQRS.Application.Data.DataBaseContext;
using Domain.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data.DataBaseContext
{
    public class ApplicationDbContext : IdentityDbContext<CustomIdentityUser>, IApplicationDbContext
    {
        public DbSet<Topic> Topics => Set<Topic>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly()
            );
        }
    }
}
