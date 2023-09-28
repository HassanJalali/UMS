using Framework.Core.Domain;
using Framework.Core.Persistence;
using Framework.Domain;
using System.Linq.Expressions;

namespace Framework.Persistence;

public abstract class BaseRepository<TAggregateRoot> : IRepository where TAggregateRoot : BaseEntity, IAggregateRoot

{
    protected readonly BaseDbContext dbContext;

    protected BaseRepository(IDbContext context)
    {
        this.dbContext = (BaseDbContext)context;
    }

    protected void Create(TAggregateRoot aggregateRoot)
    {
        dbContext.Set<TAggregateRoot>().Add(aggregateRoot);
    }

    protected void Edit(TAggregateRoot aggregateRoot)
    {
        dbContext.Set<TAggregateRoot>().Update(aggregateRoot);
    }

    protected void Delete(TAggregateRoot aggregateRoot)
    {
        dbContext.Set<TAggregateRoot>().Remove(aggregateRoot);
    }

    protected List<TAggregateRoot> GetAll()
    {
        return dbContext.Set<TAggregateRoot>().ToList();
    }

    protected TAggregateRoot Get(Expression<Func<TAggregateRoot, bool>> expression)
    {
        return dbContext.Set<TAggregateRoot>().Single(expression);
    }

    protected bool IsExist(Expression<Func<TAggregateRoot, bool>> expression)
    {
        return dbContext.Set<TAggregateRoot>().Any(expression);
    }
}