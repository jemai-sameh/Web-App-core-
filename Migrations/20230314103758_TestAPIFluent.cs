using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCoreGLSI_B.Migrations
{
    /// <inheritdoc />
    public partial class TestAPIFluent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropForeignKey(
                name: "FK_sscats_cats_categorieId",
                table: "sscats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cats",
                table: "cats");

            migrationBuilder.RenameTable(
                name: "cats",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "Categorie Name");

            migrationBuilder.AlterColumn<string>(
                name: "Categorie Name",
                table: "Categories",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "A",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sscats_Categories_categorieId",
                table: "sscats",
                column: "categorieId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sscats_Categories_categorieId",
                table: "sscats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "cats");

            migrationBuilder.RenameColumn(
                name: "Categorie Name",
                table: "cats",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "cats",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldDefaultValue: "A");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cats",
                table: "cats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sscats_cats_categorieId",
                table: "sscats",
                column: "categorieId",
                principalTable: "cats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
