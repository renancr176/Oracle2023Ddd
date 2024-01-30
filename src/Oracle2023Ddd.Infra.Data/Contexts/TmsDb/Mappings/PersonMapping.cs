using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oracle2023Ddd.Domain.Core.Data;
using Oracle2023Ddd.Domain.TmsContext.Entities;

namespace Oracle2023Ddd.Infra.Data.Contexts.TmsDb.Mappings;

public class PersonMapping : EntityAutoIncrementIdMap<Person>
{
    public static string _schema = "TMS";
    public static string _sequenceName = "SEQ_PESSOA";

    public override void Configure(EntityTypeBuilder<Person> builder)
    {
        base.Configure(builder);

        builder.ToTable("TMS_PESSOA");

        #region Indexes

        builder.HasIndex(e => e.IdCnae)
            .HasName("FK_TMS_CNAE_CNA_CNAE");

        #endregion

        builder.Property(e => e.Id)
            .HasColumnName("PES_IDENTI")
            .ValueGeneratedOnAdd()
            .HasValueGenerator((_, __) => new SequenceValueGenerator(_schema, _sequenceName));

        builder.Ignore(e => e.TypePerson);

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

        builder.Property(e => e.IdCnae)
            .HasColumnName("PES_CNA_CNAE")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(8)
            .IsRequired(false);

        builder.Property(e => e.CnaeDescription)
            .HasColumnName("PES_DESCNA")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(255)
            .IsRequired(false);

        #region System control columns

        builder.Property(e => e.CreatedAt)
            .HasColumnName("PES_DATCRI")
            .IsRequired();

        builder.Property(e => e.CreatorProgram)
            .HasColumnName("PES_PRGCRI")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired();

        builder.Property(e => e.CreatorUser)
            .HasColumnName("PES_USUCRI")
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .HasColumnName("PES_DATALT")
            .IsRequired(false);

        builder.Property(e => e.UpdateProgram)
            .HasColumnName("PES_PRGALT")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired(false);

        builder.Property(e => e.UpdateUser)
            .HasColumnName("PES_USUALT")
            .IsRequired(false);

        builder.Property(e => e.UserBdd)
            .HasColumnName("PES_USUBDD")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired();

        builder.Property(e => e.SysRevisa)
            .HasColumnName("SYS_REVISA")
            .IsRequired();

        builder.Ignore(e => e.DeletedAt);

        #endregion

        #region Relationships

        builder.HasOne(e => e.Cnae)
            .WithMany(e => e.People)
            .HasForeignKey(e => e.IdCnae)
            .IsRequired(false)
            .HasConstraintName("FK_PES_CNA_CNAE");

        builder.HasMany(e => e.Addresses)
            .WithOne(e => e.Person)
            .HasForeignKey(e => e.IdPerson)
            .IsRequired(false);

        builder.HasMany(e => e.Customers)
            .WithOne(e => e.Person)
            .HasForeignKey(e => e.IdPerson);

        #endregion
    }
}
