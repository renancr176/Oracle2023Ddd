using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Oracle2023Ddd.Domain.Core.Data;
using Oracle2023Ddd.Domain.Core.Messages;
using Oracle2023Ddd.Domain.TmsContext.Entities;
using Oracle2023Ddd.Infra.Data.Contexts.TmsDb.Mappings;

namespace Oracle2023Ddd.Infra.Data.Contexts.TmsDb; 

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

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Cnae> Cnaes { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Person> People { get; set; }

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

        builder.AddSequences();

        #region Mappings

        builder.ApplyConfiguration(new AddressMapping());
        builder.ApplyConfiguration(new CnaeMapping());
        builder.ApplyConfiguration(new CustomerMapping());
        builder.ApplyConfiguration(new PersonMapping());

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
