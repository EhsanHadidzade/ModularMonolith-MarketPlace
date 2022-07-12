using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class initSystemService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemServices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarsiTitle = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EngTitle = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    BaseFeePrice = table.Column<long>(type: "bigint", nullable: false),
                    SystemSharePercent = table.Column<int>(type: "int", nullable: false),
                    ProductBrandId = table.Column<long>(type: "bigint", nullable: false),
                    ProductModelId = table.Column<long>(type: "bigint", nullable: false),
                    ProductTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ProductUsageTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemServices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemServices");
        }
    }
}
