﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oracle2023Ddd.Infra.Data.Contexts.TmsDb.Migrations
{
    /// <inheritdoc />
    public partial class V100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TMS_CNAE",
                columns: table => new
                {
                    CNA_CNAE = table.Column<string>(type: "VARCHAR2(8)", maxLength: 8, nullable: false),
                    CNA_RELAC = table.Column<string>(type: "VARCHAR2(8)", maxLength: 8, nullable: true),
                    CNA_DESCRI = table.Column<string>(type: "VARCHAR2(255)", maxLength: 255, nullable: false),
                    CNA_SUBCLA = table.Column<string>(type: "VARCHAR2(2)", maxLength: 2, nullable: true),
                    CNA_GRUPO = table.Column<string>(type: "VARCHAR2(1)", maxLength: 1, nullable: true),
                    CNA_DIVISA = table.Column<string>(type: "VARCHAR2(2)", maxLength: 2, nullable: true),
                    CNA_ATIVID = table.Column<string>(type: "VARCHAR2(8)", maxLength: 8, nullable: true),
                    CNA_CAPNCM = table.Column<string>(type: "VARCHAR2(5)", maxLength: 5, nullable: true),
                    CNA_SECAO = table.Column<string>(type: "VARCHAR2(1)", maxLength: 1, nullable: true),
                    CNA_CLASSE = table.Column<string>(type: "VARCHAR2(2)", maxLength: 2, nullable: true),
                    CNA_DATCRI = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CNA_DATALT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    CNA_PRGCRI = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: false),
                    CNA_USUCRI = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CNA_PRGALT = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: true),
                    CNA_USUALT = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    CNA_USUBDD = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMS_CNAE", x => x.CNA_CNAE);
                });

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
                    PES_PRGALT = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: true),
                    PES_USUALT = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    PES_USUBDD = table.Column<string>(type: "VARCHAR2(35)", maxLength: 35, nullable: false),
                    SYS_REVISA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMS_PESSOA", x => x.PES_IDENTI);
                    table.ForeignKey(
                        name: "FK_PES_CNA_CNAE",
                        column: x => x.PES_CNA_CNAE,
                        principalTable: "TMS_CNAE",
                        principalColumn: "CNA_CNAE");
                });

            migrationBuilder.CreateTable(
                name: "TMS_CLIENT",
                columns: table => new
                {
                    CLI_IDENTI = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CLI_EMP_IDENTI = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CLI_CLACOM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CLI_TIPCTR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CLI_ESPEST = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CLI_REGAPU = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CLI_DATCAD = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CLI_SITFIS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CLI_ATIVO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CLI_PES_IDENTI = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CLI_SITREC = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CLI_DATCON = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    CLI_SITDES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CLI_CLACLI = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CLI_UNI_IDENTI_VINCUL = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    CLI_ZTB_IDENTI = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CLI_EDE_IDENTI_PRINCI = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    CLI_CODEXT = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CLI_UNI_IDENTI = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    CLI_CLG_IDENTI = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    CLI_ORICAD = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RegisterSourceDb = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
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
                name: "IX_TMS_CLIENT_CLI_PES_IDENTI",
                table: "TMS_CLIENT",
                column: "CLI_PES_IDENTI");

            migrationBuilder.CreateIndex(
                name: "IX_TMS_ENDERE_EDE_PES_IDENTI",
                table: "TMS_ENDERE",
                column: "EDE_PES_IDENTI");

            migrationBuilder.CreateIndex(
                name: "FK_TMS_CNAE_CNA_CNAE",
                table: "TMS_PESSOA",
                column: "PES_CNA_CNAE");

            migrationBuilder.DropSequence("SQ_TMS_ENDERE");

            migrationBuilder.DropSequence("SQ_TMS_CLIENT");

            migrationBuilder.DropSequence("SQ_TMS_PESSOA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TMS_CLIENT");

            migrationBuilder.DropTable(
                name: "TMS_ENDERE");

            migrationBuilder.DropTable(
                name: "TMS_PESSOA");

            migrationBuilder.DropTable(
                name: "TMS_CNAE");
        }
    }
}
