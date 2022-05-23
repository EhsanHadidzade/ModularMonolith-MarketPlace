using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManagement.Infrastructure.EFCore.Migrations
{
    public partial class editwallettables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "WalletBalance",
                table: "PersonalWallets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "VerifyCode",
                table: "PersonalWalletOperations",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WalletBalance",
                table: "PersonalWallets");

            migrationBuilder.DropColumn(
                name: "VerifyCode",
                table: "PersonalWalletOperations");
        }
    }
}
