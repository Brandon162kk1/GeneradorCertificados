using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Software2.Data.Migrations
{
    /// <inheritdoc />
    public partial class DisenarCertiMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_dicert",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vecinosId = table.Column<int>(type: "integer", nullable: false),
                    logosId = table.Column<int>(type: "integer", nullable: false),
                    firmasId = table.Column<int>(type: "integer", nullable: false),
                    Certificado = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_dicert", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_dicert_t_firmas_firmasId",
                        column: x => x.firmasId,
                        principalTable: "t_firmas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_dicert_t_logos_logosId",
                        column: x => x.logosId,
                        principalTable: "t_logos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_dicert_t_vecinos_vecinosId",
                        column: x => x.vecinosId,
                        principalTable: "t_vecinos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_dicert_firmasId",
                table: "t_dicert",
                column: "firmasId");

            migrationBuilder.CreateIndex(
                name: "IX_t_dicert_logosId",
                table: "t_dicert",
                column: "logosId");

            migrationBuilder.CreateIndex(
                name: "IX_t_dicert_vecinosId",
                table: "t_dicert",
                column: "vecinosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_dicert");
        }
    }
}
