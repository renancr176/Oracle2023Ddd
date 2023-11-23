using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rte2023Ddd.Domain.Core.Data;
using Rte2023Ddd.Domain.TmsContext.Entities;

namespace Rte2023Ddd.Infra.Data.Contexts.TmsDb.Mappings;

public class CustomerMapping : EntityAutoIncrementIdMap<Customer>
{
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        base.Configure(builder);

        builder.ToTable("TMS_CLIENT");
        
        builder.Property(e => e.Id)
            .HasColumnName("CLI_IDENTI");

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

        #region Relationships

        //builder.HasOne(e => e.Person)
        //    .WithOne(e => e.Customer)
        //    .HasForeignKey<Customer>(e => e.IdPerson)
        //    .IsRequired();

        #endregion
    }
}