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

        #region Indexes

        builder.HasIndex(e => e.IdPerson)
            .HasName("IX_ENDERE_EDE_PES_IDENTI");

        #endregion

        builder.Property(e => e.Id)
            .HasColumnName("EDE_IDENTI")
            .ValueGeneratedOnAdd()
            .HasValueGenerator((_, __) => new SequenceValueGenerator(_schema, _sequenceName));

        builder.Property(e => e.Type)
            .HasColumnName("EDE_TIPEDE")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(5)
            .IsRequired();

        builder.Property(e => e.BeginningDate)
            .HasColumnName("EDE_DATINI")
            .IsRequired();

        builder.Property(e => e.EndingDate)
            .HasColumnName("EDE_DATFIM")
            .IsRequired(false);

        builder.Property(e => e.Cep)
            .HasColumnName("EDE_CEP")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(8)
            .IsRequired();

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

        builder.Property(e => e.City)
            .HasColumnName("EDE_CIDADE")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(65)
            .IsRequired(false);

        builder.Property(e => e.IbgeCity) 
            .HasColumnName("EDE_IBGECI")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired(false);

        builder.Property(e => e.UnitFederationCode)
            .HasColumnName("EDE_UNF_UNIFED")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(e => e.State)
            .HasColumnName("EDE_ESTADO")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired(false);

        builder.Property(e => e.IbgeUf)
            .HasColumnName("EDE_IBGEUF")
            .IsRequired(false);

        builder.Property(e => e.Country)
            .HasColumnName("EDE_PAIS")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired(false);

        builder.Property(e => e.IbgeCountry)
            .HasColumnName("EDE_IBGEPA")
            .IsRequired(false);

        builder.Ignore(e => e.Active);
        builder.Property(e => e.ActiveDb)
            .HasColumnName("EDE_ATIVO")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(1)
            .IsRequired();

        builder.Property(e => e.IdPerson)
            .HasColumnName("EDE_PES_IDENTI")
            .IsRequired(false);

        builder.Property(e => e.Origin)
            .HasColumnName("EDE_ORIGEM")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(5)
            .IsRequired();

        builder.Ignore(e => e.Changed);
        builder.Property(e => e.ChangedDb)
            .HasColumnName("EDE_ALTEND")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(1)
            .IsRequired();

        builder.Property(e => e.CountryCode) 
            .HasColumnName("EDE_CPA_PAIS")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(e => e.CityId)
            .HasColumnName("EDE_LOC_IDENTI")
            .IsRequired();

        builder.Property(e => e.ParentId)
            .HasColumnName("EDE_EDE_IDENTI")
            .IsRequired(false);

        builder.Property(e => e.RedispatchDescription)
            .HasColumnName("EDE_REDESP")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(65)
            .IsRequired(false);

        builder.Property(e => e.WindowDeliveryBegin)
            .HasColumnName("EDE_HORINI")
            .IsRequired(false);

        builder.Property(e => e.WindowDeliveryFinal)
            .HasColumnName("EDE_HORLIM")
            .IsRequired(false);

        builder.Property(e => e.RestrictWindowDeliveryBegin)
            .HasColumnName("EDE_HOINNA")
            .IsRequired(false);

        builder.Property(e => e.RestrictWindowDeliveryFinal)
            .HasColumnName("EDE_HOFINA")
            .IsRequired(false);

        #region System control columns

        builder.Property(e => e.CreatedAt)
            .HasColumnName("EDE_DATCRI")
            .IsRequired();

        builder.Property(e => e.CreatorProgram)
            .HasColumnName("EDE_PRGCRI")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired();

        builder.Property(e => e.CreatorUser)
            .HasColumnName("EDE_USUCRI")
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .HasColumnName("EDE_DATALT")
            .IsRequired(false);

        builder.Property(e => e.UpdateProgram)
            .HasColumnName("EDE_PRGALT")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired();

        builder.Property(e => e.UpdateUser)
            .HasColumnName("EDE_USUALT")
            .IsRequired(false);

        builder.Property(e => e.UserBdd)
            .HasColumnName("EDE_USUBDD")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired();

        builder.Ignore(e => e.DeletedAt);

        builder.Ignore(e => e.SysRevisa);

        #endregion

        #region Relationships

        builder.HasOne(e => e.Person)
            .WithMany(e => e.Addresses)
            .HasForeignKey(e => e.IdPerson)
            .HasConstraintName("FK_EDE_PES_IDENTI")
            .IsRequired(false);

        #endregion
    }
}
