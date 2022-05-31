using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class EditSellerPanel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoreMobileNumber",
                table: "SellerPanels",
                newName: "SellerMobileNumber");

            migrationBuilder.AddColumn<string>(
                name: "CompanyEconomicCode",
                table: "SellerPanels",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "SellerPanels",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyRegistrationCode",
                table: "SellerPanels",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsUserLegal",
                table: "SellerPanels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyEconomicCode",
                table: "SellerPanels");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "SellerPanels");

            migrationBuilder.DropColumn(
                name: "CompanyRegistrationCode",
                table: "SellerPanels");

            migrationBuilder.DropColumn(
                name: "IsUserLegal",
                table: "SellerPanels");

            migrationBuilder.RenameColumn(
                name: "SellerMobileNumber",
                table: "SellerPanels",
                newName: "StoreMobileNumber");
        }
    }
}
