using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class allproductcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ProductUsageTypes",
                newName: "FarsiTitle");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ProductTypes",
                newName: "FarsiTitle");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ProductStatuses",
                newName: "FarsiTitle");

            migrationBuilder.AddColumn<string>(
                name: "EngTitle",
                table: "ProductUsageTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngTitle",
                table: "ProductTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngTitle",
                table: "ProductStatuses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngTitle",
                table: "ProductUsageTypes");

            migrationBuilder.DropColumn(
                name: "EngTitle",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "EngTitle",
                table: "ProductStatuses");

            migrationBuilder.RenameColumn(
                name: "FarsiTitle",
                table: "ProductUsageTypes",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "FarsiTitle",
                table: "ProductTypes",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "FarsiTitle",
                table: "ProductStatuses",
                newName: "Title");
        }
    }
}
