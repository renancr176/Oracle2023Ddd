using Rte2023Ddd.Domain.Core.DomainObjects;

namespace Rte2023Ddd.Infra.Data.Contexts.TmsDb;

public abstract class TmsRepository<TEntity> : Repository<TmsDbContext, TEntity>
    where TEntity : Entity
{
    protected TmsRepository(TmsDbContext context) : base(context)
    {
    }
}

public abstract class TmsRepositoryAutoIncrementId<TEntity> : RepositoryAutoIncrementId<TmsDbContext, TEntity>
    where TEntity : EntityAutoIncrementId
{
    protected TmsRepositoryAutoIncrementId(TmsDbContext context) : base(context)
    {
    }
}

public abstract class TmsRepositoryStringId<TEntity> : RepositoryStringId<TmsDbContext, TEntity>
    where TEntity : EntityStringId
{
    protected TmsRepositoryStringId(TmsDbContext context) : base(context)
    {
    }
}
