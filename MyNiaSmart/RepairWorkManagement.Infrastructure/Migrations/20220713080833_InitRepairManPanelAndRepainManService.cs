using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class InitRepairManPanelAndRepainManService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepainManPanels",
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
                    table.PrimaryKey("PK_RepainManPanels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepairManServices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    MarketerSharePercent = table.Column<int>(type: "int", nullable: false),
                    WarrantyTypeId = table.Column<int>(type: "int", nullable: false),
                    WarrantyAmount = table.Column<int>(type: "int", nullable: false),
                    IsConfirmedByAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsEditedByClient = table.Column<bool>(type: "bit", nullable: false),
                    RepairManPanelId = table.Column<long>(type: "bigint", nullable: false),
                    SystemServiceId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairManServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairManServices_RepainManPanels_RepairManPanelId",
                        column: x => x.RepairManPanelId,
                        principalTable: "RepainManPanels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepairManServices_SystemServices_SystemServiceId",
                        column: x => x.SystemServiceId,
                        principalTable: "SystemServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepairManServices_RepairManPanelId",
                table: "RepairManServices",
                column: "RepairManPanelId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairManServices_SystemServiceId",
                table: "RepairManServices",
                column: "SystemServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepairManServices");

            migrationBuilder.DropTable(
                name: "RepainManPanels");
        }
    }
}
