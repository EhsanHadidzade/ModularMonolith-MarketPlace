using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class editmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ProductModels",
                newName: "FarsiTitle");

            migrationBuilder.AddColumn<string>(
                name: "EngTitle",
                table: "ProductModels",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngTitle",
                table: "ProductModels");

            migrationBuilder.RenameColumn(
                name: "FarsiTitle",
                table: "ProductModels",
                newName: "Title");
        }
    }
}
