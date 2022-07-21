using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class EditSystemService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngTitle",
                table: "SystemServices");

            migrationBuilder.DropColumn(
                name: "FarsiTitle",
                table: "SystemServices");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SystemServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "SystemServices",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ServiceTitleId",
                table: "SystemServices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ServiceTitles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EngTitle = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FarsiTitle = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTitles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceTitles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SystemServices");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "SystemServices");

            migrationBuilder.DropColumn(
                name: "ServiceTitleId",
                table: "SystemServices");

            migrationBuilder.AddColumn<string>(
                name: "EngTitle",
                table: "SystemServices",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FarsiTitle",
                table: "SystemServices",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }
    }
}
