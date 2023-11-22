using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rte2023Ddd.Infra.Data.Contexts.TmsDb.Migrations
{
    /// <inheritdoc />
    public partial class V001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "SEQ_ENDERE",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence<int>(
                name: "SEQ_PESSOA",
                maxValue: 2147483647L);

            migrationBuilder.CreateTable(
                name: "TMS_PESSOA",
                columns: table => new
                {
                    PES_IDENTI = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PES_TIPPES = table.Column<string>(type: "VARCHAR2(5)", maxLength: 5, nullable: false),
                    PES_CPFCNP = table.Column<string>(type: "VARCHAR2(15)", maxLength: 15, nullable: false),
                    PES_INSEST = table.Column<string>(type: "VARCHAR2(15)", maxLength: 15, nullable: true),
                    PES_INSMUN = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: true),
                    PES_DESCRI = table.Column<string>(type: "VARCHAR2(65)", maxLength: 65, nullable: false),
                    PES_DESRED = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: true),
                    PES_NOMFAN = table.Column<string>(type: "NVARCHAR2(65)", maxLength: 65, nullable: true),
                    PES_CNA_CNAE = table.Column<string>(type: "VARCHAR2(8)", maxLength: 8, nullable: true),
                    PES_DESCNA = table.Column<string>(type: "VARCHAR2(255)", maxLength: 255, nullable: true),
                    PES_DATCRI = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PES_DATALT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    PES_PRGCRI = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: false),
                    PES_USUCRI = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PES_PRGALT = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: false),
                    PES_USUALT = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    PES_USUBDD = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: false),
                    SYS_REVISA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMS_PESSOA", x => x.PES_IDENTI);
                });

            migrationBuilder.CreateTable(
                name: "TMS_ENDERE",
                columns: table => new
                {
                    EDE_IDENTI = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EDE_TIPEDE = table.Column<string>(type: "VARCHAR2(5)", maxLength: 5, nullable: false),
                    EDE_DATINI = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EDE_DATFIM = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    EDE_CEP = table.Column<string>(type: "VARCHAR2(8)", maxLength: 8, nullable: false),
                    EDE_TIPLOG = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: true),
                    EDE_ENDERE = table.Column<string>(type: "VARCHAR2(65)", maxLength: 65, nullable: false),
                    EDE_NUMERO = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: true),
                    EDE_COMPLE = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: true),
                    EDE_BAIRRO = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: true),
                    EDE_CIDADE = table.Column<string>(type: "VARCHAR2(65)", maxLength: 65, nullable: true),
                    EDE_IBGECI = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: true),
                    EDE_UNF_UNIFED = table.Column<string>(type: "VARCHAR2(2)", maxLength: 2, nullable: false),
                    EDE_ESTADO = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: true),
                    EDE_IBGEUF = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    EDE_PAIS = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: true),
                    EDE_IBGEPA = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    EDE_ATIVO = table.Column<string>(type: "VARCHAR2(1)", maxLength: 1, nullable: false),
                    EDE_PES_IDENTI = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    EDE_ORIGEM = table.Column<string>(type: "VARCHAR2(5)", maxLength: 5, nullable: false),
                    EDE_ALTEND = table.Column<string>(type: "VARCHAR2(1)", maxLength: 1, nullable: false),
                    EDE_CPA_PAIS = table.Column<string>(type: "VARCHAR2(2)", maxLength: 2, nullable: false),
                    EDE_LOC_IDENTI = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EDE_EDE_IDENTI = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    EDE_REDESP = table.Column<string>(type: "VARCHAR2(65)", maxLength: 65, nullable: true),
                    EDE_HORINI = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    EDE_HORLIM = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    EDE_HOINNA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    EDE_HOFINA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    EDE_DATCRI = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EDE_DATALT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    EDE_PRGCRI = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: false),
                    EDE_USUCRI = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EDE_PRGALT = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: false),
                    EDE_USUALT = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    EDE_USUBDD = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMS_ENDERE", x => x.EDE_IDENTI);
                    table.ForeignKey(
                        name: "FK_EDE_PES_IDENTI",
                        column: x => x.EDE_PES_IDENTI,
                        principalTable: "TMS_PESSOA",
                        principalColumn: "PES_IDENTI");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ENDERE_EDE_PES_IDENTI",
                table: "TMS_ENDERE",
                column: "EDE_PES_IDENTI");

            migrationBuilder.DropSequence(
                name: "SQ_TMS_ENDERE");

            migrationBuilder.DropSequence(
                name: "SQ_TMS_PESSOA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TMS_ENDERE");

            migrationBuilder.DropTable(
                name: "TMS_PESSOA");

            migrationBuilder.DropSequence(
                name: "SEQ_ENDERE");

            migrationBuilder.DropSequence(
                name: "SEQ_PESSOA");
        }
    }
}
