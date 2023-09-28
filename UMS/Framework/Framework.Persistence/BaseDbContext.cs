using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Framework.Persistence;

public abstract class BaseDbContext : DbContext, IDbContext
{

    protected BaseDbContext(DbContextOptions options) : base(options)
    {

    }

    public void Migrate()
    {

    }
}