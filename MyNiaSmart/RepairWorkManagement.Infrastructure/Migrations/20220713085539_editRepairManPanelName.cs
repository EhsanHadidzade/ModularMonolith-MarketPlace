using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class editRepairManPanelName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairManServices_RepainManPanels_RepairManPanelId",
                table: "RepairManServices");

            migrationBuilder.DropTable(
                name: "RepainManPanels");

            migrationBuilder.CreateTable(
                name: "RepairManPanels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommericalFullName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Capital = table.Column<string>(type: "nvarchar(56)", maxLength: 56, nullable: true),
                    City = table.Column<string>(type: "nvarchar(56)", maxLength: 56, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ShortResume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsConfirmedByAdmin = table.Column<bool>(type: "bit", nullable: false),
                    MarketerSharePercent = table.Column<int>(type: "int", nullable: false),
                    WarrantyTypeId = table.Column<int>(type: "int", nullable: false),
                    WarrantyAmount = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairManPanels", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RepairManServices_RepairManPanels_RepairManPanelId",
                table: "RepairManServices",
                column: "RepairManPanelId",
                principalTable: "RepairManPanels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairManServices_RepairManPanels_RepairManPanelId",
                table: "RepairManServices");

            migrationBuilder.DropTable(
                name: "RepairManPanels");

            migrationBuilder.CreateTable(
                name: "RepainManPanels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Capital = table.Column<string>(type: "nvarchar(56)", maxLength: 56, nullable: true),
                    City = table.Column<string>(type: "nvarchar(56)", maxLength: 56, nullable: true),
                    CommericalFullName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsConfirmedByAdmin = table.Column<bool>(type: "bit", nullable: false),
                    MarketerSharePercent = table.Column<int>(type: "int", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ShortResume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    WarrantyAmount = table.Column<int>(type: "int", nullable: false),
                    WarrantyTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepainManPanels", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RepairManServices_RepainManPanels_RepairManPanelId",
                table: "RepairManServices",
                column: "RepairManPanelId",
                principalTable: "RepainManPanels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
