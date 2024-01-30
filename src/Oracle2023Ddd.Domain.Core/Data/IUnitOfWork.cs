using Microsoft.EntityFrameworkCore.Storage;

namespace Oracle2023Ddd.Domain.Core.Data;

public interface IUnitOfWork
{
    IDbContextTransaction Transaction { get; }
    Task BeginTransaction();
    Task CreateSavepoint(string savePointName);
    Task RollbackToSavepoint(string savePointName);
    Task<bool> Commit();
}