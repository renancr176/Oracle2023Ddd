﻿using Rte2023Ddd.Domain.Core.DomainObjects;
using System.Linq.Expressions;

namespace Rte2023Ddd.Domain.Core.Data;

public interface IRepository<TEntity> : IDisposable
    where TEntity : Entity
{
    IUnitOfWork UnitOfWork { get; }

    Task InsertAsync(TEntity obj);
    Task InsertRangeAsync(ICollection<TEntity> obj);
    Task<TEntity?> GetByIdAsync(Guid id, IEnumerable<string> includes = null);
    Task<IEnumerable<TEntity>?> GetAllAsync(IEnumerable<string> includes = null);
    Task<IEnumerable<TEntity>?> GetPagedAsync(int pageIndex, int pageSize,
        Expression<Func<TEntity?, bool>> predicate = null,
        Dictionary<Expression<Func<TEntity, object>>, OrderByEnum> ordenations = null);
    Task<IEnumerable<TEntity>?> GetPagedAsync(int pageIndex, int pageSize,
        IEnumerable<string> includes, Expression<Func<TEntity, bool>> predicate = null,
        Dictionary<Expression<Func<TEntity, object>>, OrderByEnum> ordenations = null);
    Task UpdateAsync(TEntity obj);
    Task UpdateRangeAsync(IEnumerable<TEntity> obj);
    Task DeleteAsync(Guid id);
    Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>?> FindAsync(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes = null);
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes = null);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
    Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> sumPredicate,
        Expression<Func<TEntity, bool>> predicate = null);
    Task<int> SumAsync(Expression<Func<TEntity, int>> sumPredicate, Expression<Func<TEntity, bool>> predicate = null);
    Task<long> SumAsync(Expression<Func<TEntity, long>> sumPredicate, Expression<Func<TEntity, bool>> predicate = null);
    Task<double> SumAsync(Expression<Func<TEntity, double>> sumPredicate,
        Expression<Func<TEntity, bool>> predicate = null);
    Task<float> SumAsync(Expression<Func<TEntity, float>> sumPredicate,
        Expression<Func<TEntity, bool>> predicate = null);
    Task<int> SaveChangesAsync();
}

public interface IRepositoryAutoIncrementId<TEntity> : IRepository<TEntity>
    where TEntity : EntityAutoIncrementId
{
    Task<TEntity?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}

public interface IRepositoryStringId<TEntity> : IRepository<TEntity>
    where TEntity : EntityStringId
{
    Task<TEntity?> GetByIdAsync(string id);
    Task DeleteAsync(string id);
}