using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class EngTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Products",
                newName: "FarsiTitle");

            migrationBuilder.AddColumn<string>(
                name: "EngTitle",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngTitle",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "FarsiTitle",
                table: "Products",
                newName: "Title");
        }
    }
}
