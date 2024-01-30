using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oracle2023Ddd.Infra.Data.Contexts.TmsDb.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "SEQ_CLIENT",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence<int>(
                name: "SEQ_ENDERE",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence<int>(
                name: "SEQ_PESSOA",
                maxValue: 2147483647L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "SEQ_CLIENT");

            migrationBuilder.DropSequence(
                name: "SEQ_ENDERE");

            migrationBuilder.DropSequence(
                name: "SEQ_PESSOA");
        }
    }
}
