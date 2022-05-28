using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class initSellerPanel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SellerPanels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    StoreMobileNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BuyersCategory = table.Column<int>(type: "int", nullable: false),
                    CanMarketerSee = table.Column<bool>(type: "bit", nullable: false),
                    IsConfirmedByAdmin = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerPanels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SellerPanels");
        }
    }
}
