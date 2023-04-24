using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCoreGLSI_B.Migrations
{
    /// <inheritdoc />
    public partial class CorrectName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Categorie Name",
                table: "Categories",
                newName: "CategorieName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategorieName",
                table: "Categories",
                newName: "Categorie Name");
        }
    }
}
