using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rte2023Ddd.Domain.Core.Data;
using Rte2023Ddd.Domain.TmsContext.Entities;

namespace Rte2023Ddd.Infra.Data.Contexts.TmsDb.Mappings;

public class CustomerMapping : EntityAutoIncrementIdMap<Customer>
{
    public static string _schema = "TMS";
    public static string _sequenceName = "SEQ_CLIENT";

    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        base.Configure(builder);

        builder.ToTable("TMS_CLIENT");
        
        builder.Property(e => e.Id)
            .HasColumnName("CLI_IDENTI")
            .ValueGeneratedOnAdd()
            .HasValueGenerator((_, __) => new SequenceValueGenerator(_schema, _sequenceName));

        builder.Property(e => e.IdCompany)
            .HasColumnName("CLI_EMP_IDENTI");

        builder.Property(e => e.CommercialClassification)
            .HasColumnName("CLI_CLACOM");

        builder.Property(e => e.TaxpayerType)
            .HasColumnName("CLI_TIPCTR");

        builder.Property(e => e.EstablishmentType)
            .HasColumnName("CLI_ESPEST");

        builder.Property(e => e.TaxpayerClassificationSystem)
            .HasColumnName("CLI_REGAPU");

        builder.Property(e => e.InsertDate)
            .HasColumnName("CLI_DATCAD");

        builder.Property(e => e.FiscalStatus)
            .HasColumnName("CLI_SITFIS");

        builder.Ignore(e => e.Active);
        builder.Property(e => e.ActiveDb)
            .HasColumnName("CLI_ATIVO");

        builder.Property(e => e.IdPerson)
            .HasColumnName("CLI_PES_IDENTI");

        builder.Ignore(e => e.SituationWS);
        builder.Property(e => e.SituationWSDb)
            .HasColumnName("CLI_SITREC");

        builder.Property(e => e.SearchDateWS)
            .HasColumnName("CLI_DATCON");

        builder.Property(e => e.SituationDescriptionWS)
            .HasColumnName("CLI_SITDES");

        builder.Property(e => e.CustomerClassification)
            .HasColumnName("CLI_CLACLI");

        builder.Property(e => e.IdUnitLinked)
            .HasColumnName("CLI_UNI_IDENTI_VINCUL");
        
        builder.Property(e => e.IdTaxZone)
            .HasColumnName("CLI_ZTB_IDENTI");

        builder.Property(e => e.AddressIdMain)
            .HasColumnName("CLI_EDE_IDENTI_PRINCI");

        builder.Property(e => e.ExternalCode)
            .HasColumnName("CLI_CODEXT");

        builder.Property(e => e.IdUnit)
            .HasColumnName("CLI_UNI_IDENTI");

        builder.Property(e => e.SectorLogisticId)
            .HasColumnName("CLI_CLG_IDENTI");

        builder.Property(e => e.RegisterSource)
            .HasColumnName("CLI_ORICAD");

        #region System control columns

        builder.Property(e => e.CreatedAt)
            .HasColumnName("CLI_DATCRI")
            .IsRequired();

        builder.Property(e => e.CreatorProgram)
            .HasColumnName("CLI_PRGCRI")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired();

        builder.Property(e => e.CreatorUser)
            .HasColumnName("CLI_USUCRI")
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .HasColumnName("CLI_DATALT")
            .IsRequired(false);

        builder.Property(e => e.UpdateProgram)
            .HasColumnName("CLI_PRGALT")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired(false);

        builder.Property(e => e.UpdateUser)
            .HasColumnName("CLI_USUALT")
            .IsRequired(false);

        builder.Property(e => e.UserBdd)
            .HasColumnName("CLI_USUBDD")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired();

        #endregion

        #region Relationships

        builder.HasOne(e => e.Person)
            .WithMany(e => e.Customers)
            .HasForeignKey(e => e.IdPerson)
            .IsRequired()
            .HasConstraintName("FK_CLI_PES_IDENTI");

        #endregion
    }
}