using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class editRepairManPanel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarketerSharePercent",
                table: "RepairManPanels");

            migrationBuilder.AddColumn<bool>(
                name: "CanMarketerSee",
                table: "RepairManServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "MarketerShareAmount",
                table: "RepairManServices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "CanMarketerSee",
                table: "RepairManPanels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanMarketerSee",
                table: "RepairManServices");

            migrationBuilder.DropColumn(
                name: "MarketerShareAmount",
                table: "RepairManServices");

            migrationBuilder.DropColumn(
                name: "CanMarketerSee",
                table: "RepairManPanels");

            migrationBuilder.AddColumn<int>(
                name: "MarketerSharePercent",
                table: "RepairManPanels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
