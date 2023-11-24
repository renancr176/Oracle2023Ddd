using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rte2023Ddd.Infra.Data.Contexts.TmsDb.Migrations
{
    /// <inheritdoc />
    public partial class V002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TMS_CLIENT",
                columns: table => new
                {
                    CLI_IDENTI = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CLI_EMP_IDENTI = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CLI_CLACOM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CLI_TIPCTR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CLI_ESPEST = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CLI_REGAPU = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CLI_DATCAD = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CLI_SITFIS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CLI_ATIVO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CLI_PES_IDENTI = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CLI_SITREC = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CLI_DATCON = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CLI_SITDES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CLI_CLACLI = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CLI_UNI_IDENTI_VINCUL = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CLI_ZTB_IDENTI = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CLI_EDE_IDENTI_PRINCI = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CLI_CODEXT = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CLI_UNI_IDENTI = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CLI_CLG_IDENTI = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CLI_ORICAD = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CLI_DATCRI = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CLI_DATALT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    CLI_PRGCRI = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: false),
                    CLI_USUCRI = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CLI_PRGALT = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: true),
                    CLI_USUALT = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    CLI_USUBDD = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMS_CLIENT", x => x.CLI_IDENTI);
                    table.ForeignKey(
                        name: "FK_CLI_PES_IDENTI",
                        column: x => x.CLI_PES_IDENTI,
                        principalTable: "TMS_PESSOA",
                        principalColumn: "PES_IDENTI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TMS_CLIENT_CLI_PES_IDENTI",
                table: "TMS_CLIENT",
                column: "CLI_PES_IDENTI");

            migrationBuilder.DropSequence(
                name: "SQ_TMS_CLIENT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TMS_CLIENT");
        }
    }
}
