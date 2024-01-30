using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oracle2023Ddd.Domain.Core.Data;
using Oracle2023Ddd.Domain.TmsContext.Entities;

namespace Oracle2023Ddd.Infra.Data.Contexts.TmsDb.Mappings;

public class CnaeMapping : EntityMap<Cnae>
{
    public override void Configure(EntityTypeBuilder<Cnae> builder)
    {
        base.Configure(builder);

        builder.ToTable("TMS_CNAE");

        builder.Property(e => e.Id)
            .HasColumnName("CNA_CNAE")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(8)
            .IsRequired();

        builder.Property(e => e.CodeParent)
            .HasColumnName("CNA_RELAC")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(8)
            .IsRequired(false);

        builder.Property(e => e.Description)
            .HasColumnName("CNA_DESCRI")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.SubClass)
            .HasColumnName("CNA_SUBCLA")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(2)
            .IsRequired(false);

        builder.Property(e => e.Group)
            .HasColumnName("CNA_GRUPO")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(1)
            .IsRequired(false);

        builder.Property(e => e.Division)
            .HasColumnName("CNA_DIVISA")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(2)
            .IsRequired(false);

        builder.Property(e => e.IdActivity)
            .HasColumnName("CNA_ATIVID")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(8)
            .IsRequired(false);

        builder.Property(e => e.ChapterNcm)
            .HasColumnName("CNA_CAPNCM")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(5)
            .IsRequired(false);

        builder.Property(e => e.Section)
            .HasColumnName("CNA_SECAO")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(1)
            .IsRequired(false);

        builder.Property(e => e.Class)
            .HasColumnName("CNA_CLASSE")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(2)
            .IsRequired(false);

        #region System control columns

        builder.Property(e => e.CreatedAt)
            .HasColumnName("CNA_DATCRI")
            .IsRequired();

        builder.Property(e => e.CreatorProgram)
            .HasColumnName("CNA_PRGCRI")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired();

        builder.Property(e => e.CreatorUser)
            .HasColumnName("CNA_USUCRI")
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .HasColumnName("CNA_DATALT")
            .IsRequired(false);

        builder.Property(e => e.UpdateProgram)
            .HasColumnName("CNA_PRGALT")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired(false);

        builder.Property(e => e.UpdateUser)
            .HasColumnName("CNA_USUALT")
            .IsRequired(false);

        builder.Property(e => e.UserBdd)
            .HasColumnName("CNA_USUBDD")
            .HasColumnType("VARCHAR2")
            .HasMaxLength(35)
            .IsRequired();

        #endregion

        #region Relationships

        builder.HasMany(e => e.People)
            .WithOne(e => e.Cnae)
            .HasForeignKey(e => e.IdCnae)
            .IsRequired(false);

        #endregion
    }
}