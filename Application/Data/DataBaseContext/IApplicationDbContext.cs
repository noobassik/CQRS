namespace CQRS.Application.Data.DataBaseContext
{
    public interface IApplicationDbContext
    {
        DbSet<Topic> Topics { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
