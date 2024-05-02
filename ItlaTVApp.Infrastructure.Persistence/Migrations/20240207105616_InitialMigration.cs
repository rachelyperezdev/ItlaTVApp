using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItlaTVApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URLImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URLVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductoraId = table.Column<int>(type: "int", nullable: false),
                    GeneroPrimarioId = table.Column<int>(type: "int", nullable: false),
                    GeneroSecundarioId = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_Generos_GeneroPrimarioId",
                        column: x => x.GeneroPrimarioId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Series_Generos_GeneroSecundarioId",
                        column: x => x.GeneroSecundarioId,
                        principalTable: "Generos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Series_Productoras_ProductoraId",
                        column: x => x.ProductoraId,
                        principalTable: "Productoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Series_GeneroPrimarioId",
                table: "Series",
                column: "GeneroPrimarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_GeneroSecundarioId",
                table: "Series",
                column: "GeneroSecundarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_ProductoraId",
                table: "Series",
                column: "ProductoraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Productoras");
        }
    }
}
