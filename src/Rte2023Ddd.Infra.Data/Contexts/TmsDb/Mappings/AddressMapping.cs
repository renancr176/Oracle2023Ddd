using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rte2023Ddd.Domain.Core.Data;
using Rte2023Ddd.Domain.TmsContext.Entities;

namespace Rte2023Ddd.Infra.Data.Contexts.TmsDb.Mappings;

public class AddressMapping : EntityAutoIncrementIdMap<Address>
{
    public static string _schema = "TMS";
    public static string _sequenceName = "SEQ_ENDERE";

    public override void Configure(EntityTypeBuilder<Address> builder)
    {
        base.Configure(builder);

        builder.ToTable("TMS_ENDERE");

        builder.Property(e => e.Id)
            .HasColumnName("EDE_IDENTI")
            .ValueGeneratedOnAdd()
            .HasValueGenerator((_, __) => new SequenceValueGenerator(_schema, _sequenceName));

        builder.Property(e => e.TypeAddress)
            .HasColumnName("EDE_TIPLOG")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired(false);

        builder.Property(e => e.StreetName)
            .HasColumnName("EDE_ENDERE")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(65)
            .IsRequired();

        builder.Property(e => e.Number)
            .HasColumnName("EDE_NUMERO")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired(false);

        builder.Property(e => e.Supplement)
            .HasColumnName("EDE_COMPLE")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired(false);

        builder.Property(e => e.District)
            .HasColumnName("EDE_BAIRRO")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired(false);

        builder.Property(e => e.UnitFederationCode)
            .HasColumnName("EDE_UNF_UNIFED")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(2)
            .IsRequired();

        #region Relationships

        builder.HasOne(e => e.Person)
            .WithMany(e => e.Addresses)
            .HasForeignKey(e => e.PersonId);

        #endregion
    }
}
