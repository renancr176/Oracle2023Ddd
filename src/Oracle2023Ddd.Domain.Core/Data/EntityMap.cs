using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oracle2023Ddd.Domain.Core.DomainObjects;

namespace Oracle2023Ddd.Domain.Core.Data;

public abstract class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnOrder(1);

        builder.Property(entity => entity.CreatedAt)
            .IsRequired();

        builder.Ignore(entity => entity.Notifications);

        builder.HasQueryFilter(entity => !entity.DeletedAt.HasValue);

        builder.Ignore(e => e.CreatedAt);
        builder.Ignore(e => e.UpdatedAt);
        builder.Ignore(e => e.DeletedAt);
        builder.Ignore(e => e.SysRevisa);
    }
}

public abstract class EntityAutoIncrementIdMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityAutoIncrementId
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.CreatedAt)
            .IsRequired();

        builder.Ignore(entity => entity.Notifications);

        builder.HasQueryFilter(entity => !entity.DeletedAt.HasValue);

        builder.Ignore(e => e.CreatedAt);
        builder.Ignore(e => e.UpdatedAt);
        builder.Ignore(e => e.DeletedAt);
        builder.Ignore(e => e.SysRevisa);
    }
}