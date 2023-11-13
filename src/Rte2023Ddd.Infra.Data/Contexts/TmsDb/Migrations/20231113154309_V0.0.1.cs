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
                name: "SEQ_PESSOA",
                maxValue: 2147483647L);

            migrationBuilder.CreateTable(
                name: "TMS_PESSOA",
                columns: table => new
                {
                    PES_IDENTI = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TypePerson = table.Column<int>(type: "NUMBER(10)", nullable: false),
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TMS_PESSOA");

            migrationBuilder.DropSequence(
                name: "SEQ_PESSOA");
        }
    }
}
