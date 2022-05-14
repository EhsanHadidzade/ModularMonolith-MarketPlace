using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManagement.Infrastructure.EFCore.Migrations
{
    public partial class addcapitalandcity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRequestConfirmed",
                table: "UpAccountRequests",
                newName: "IsRequestConfirmedByClient");

            migrationBuilder.AddColumn<string>(
                name: "Capital",
                table: "UpAccountRequests",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UpAccountRequests",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequestConfirmedByAdmin",
                table: "UpAccountRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capital",
                table: "UpAccountRequests");

            migrationBuilder.DropColumn(
                name: "City",
                table: "UpAccountRequests");

            migrationBuilder.DropColumn(
                name: "IsRequestConfirmedByAdmin",
                table: "UpAccountRequests");

            migrationBuilder.RenameColumn(
                name: "IsRequestConfirmedByClient",
                table: "UpAccountRequests",
                newName: "IsRequestConfirmed");
        }
    }
}
