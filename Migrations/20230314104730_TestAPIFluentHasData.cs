using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCoreGLSI_B.Migrations
{
    /// <inheritdoc />
    public partial class TestAPIFluentHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "sscats",
                newName: "SsCateg");

            migrationBuilder.AlterColumn<string>(
                name: "SsCateg",
                table: "sscats",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Categorie Name" },
                values: new object[] { 3, "CatFromAPIFluent" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "SsCateg",
                table: "sscats",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "sscats",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
