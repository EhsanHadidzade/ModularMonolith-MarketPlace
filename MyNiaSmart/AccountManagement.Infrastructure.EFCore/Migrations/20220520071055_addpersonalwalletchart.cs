using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManagement.Infrastructure.EFCore.Migrations
{
    public partial class addpersonalwalletchart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalWalletCharts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<long>(type: "bigint", nullable: false),
                    BalanceUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonalwalletId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalWalletCharts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalWalletCharts_PersonalWallets_PersonalwalletId",
                        column: x => x.PersonalwalletId,
                        principalTable: "PersonalWallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalWalletCharts_PersonalwalletId",
                table: "PersonalWalletCharts",
                column: "PersonalwalletId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalWalletCharts");
        }
    }
}
