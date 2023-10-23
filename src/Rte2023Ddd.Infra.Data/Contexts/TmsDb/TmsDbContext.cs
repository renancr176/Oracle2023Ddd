using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Rte2023Ddd.Domain.Core.Data;
using Rte2023Ddd.Domain.Core.Messages;

namespace Rte2023Ddd.Infra.Data.Contexts.TmsDb; 

public class TmsDbContext : DbContext, IUnitOfWork
{
    private readonly IMediator _mediatorHandler;

    public TmsDbContext(DbContextOptions<TmsDbContext> options, IMediator mediatorHandler)
        : base(options)
    {
        _mediatorHandler = mediatorHandler;
    }

    public IDbContextTransaction Transaction { get; private set; }

    #region DbSets
    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            optionsBuilder.UseOracle(config.GetConnectionString("TMS"));
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Ignore<Event>();

        #region Mappings

        #endregion
    }

    public virtual async Task BeginTransaction()
    {
        if (Transaction == null)
            Transaction = await Database.BeginTransactionAsync();
    }

    public virtual async Task CreateSavepoint(string savePointName)
    {
        Transaction.CreateSavepoint(savePointName);
    }

    public virtual async Task RollbackToSavepoint(string savePointName)
    {
        Transaction.RollbackToSavepoint(savePointName);
    }

    public async Task<bool> Commit()
    {
        var sucesso = await base.SaveChangesAsync() > 0;
        if (Transaction != null)
        {
            Transaction.Commit();
            Transaction = null;
        }
        if (sucesso) await _mediatorHandler.PublishEvent(this);

        return sucesso;
    }
}
