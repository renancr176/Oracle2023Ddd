using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rte2023Ddd.Domain.Core.Data;
using Rte2023Ddd.Domain.TmsContext.Entities;

namespace Rte2023Ddd.Infra.Data.Contexts.TmsDb.Mappings;

public class PersonMapping : EntityAutoIncrementIdMap<Person>
{
    public override void Configure(EntityTypeBuilder<Person> builder)
    {
        base.Configure(builder);

        builder.ToTable("TMS_PESSOA");

        builder.Property(e => e.Id)
            .HasColumnName("PES_IDENTI");   

        builder.Property(e => e.TypePersonDb)
            .HasColumnName("PES_TIPPES")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(5)
            .IsRequired();

        builder.Property(e => e.TaxIdRegistration)
            .HasColumnName("PES_CPFCNP")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(e => e.StadualIdRegistration)
            .HasColumnName("PES_INSEST")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(15)
            .IsRequired(false);

        builder.Property(e => e.RegionalIdRegistration)
            .HasColumnName("PES_INSMUN")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired(false);

        builder.Property(e => e.Description)
            .HasColumnName("PES_DESCRI")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(65)
            .IsRequired();

        builder.Property(e => e.ReductedDescription)
            .HasColumnName("PES_DESRED")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired(false);

        builder.Property(e => e.FictitiousName)
            .HasColumnName("PES_NOMFAN")
            .HasMaxLength(65)
            .IsRequired(false);

        builder.Property(e => e.Cnae)
            .HasColumnName("PES_CNA_CNAE")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(8)
            .IsRequired(false);

        builder.Property(e => e.CnaeDescription)
            .HasColumnName("PES_DESCNA")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(e => e.PersonCreatorProgram)
            .HasColumnName("PES_PRGCRI")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired();
    }
}
