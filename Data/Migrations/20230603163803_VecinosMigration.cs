using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Software2.Data.Migrations
{
    /// <inheritdoc />
    public partial class VecinosMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Certificado",
                table: "t_vecinos",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Certificado",
                table: "t_vecinos");
        }
    }
}
