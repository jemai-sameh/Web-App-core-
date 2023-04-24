using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCoreGLSI_B.Migrations
{
    /// <inheritdoc />
    public partial class ProduitManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "produit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProduitSousCategorie",
                columns: table => new
                {
                    produitsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ssCategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduitSousCategorie", x => new { x.produitsId, x.ssCategoriesId });
                    table.ForeignKey(
                        name: "FK_ProduitSousCategorie_produit_produitsId",
                        column: x => x.produitsId,
                        principalTable: "produit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduitSousCategorie_sscats_ssCategoriesId",
                        column: x => x.ssCategoriesId,
                        principalTable: "sscats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProduitSousCategorie_ssCategoriesId",
                table: "ProduitSousCategorie",
                column: "ssCategoriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProduitSousCategorie");

            migrationBuilder.DropTable(
                name: "produit");
        }
    }
}
