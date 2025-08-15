using CQRS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Application.Data.DataBaseContext
{
    public interface IApplicationDbContext
    {
        DbSet<Topic> Topics { get; }
    }
}
