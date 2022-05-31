using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class initSellerProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryDurationForCapital",
                table: "SellerPanels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryDurationForCity",
                table: "SellerPanels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryDurationForOther",
                table: "SellerPanels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WarrantyAmount",
                table: "SellerPanels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WarrantyTypeId",
                table: "SellerPanels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SellerProducts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerPanelId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarketerSharePercent = table.Column<int>(type: "int", nullable: false),
                    MarketerShareAmount = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryDurationForCity = table.Column<int>(type: "int", nullable: false),
                    DeliveryDurationForCapital = table.Column<int>(type: "int", nullable: false),
                    DeliveryDurationForOther = table.Column<int>(type: "int", nullable: false),
                    CanMarketerSee = table.Column<bool>(type: "bit", nullable: false),
                    BuyersCategory = table.Column<int>(type: "int", nullable: false),
                    WarrantyTypeId = table.Column<int>(type: "int", nullable: false),
                    WarrantyAmount = table.Column<int>(type: "int", nullable: false),
                    isConfirmedByAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellerProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerProducts_SellerPanels_SellerPanelId",
                        column: x => x.SellerPanelId,
                        principalTable: "SellerPanels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SellerProducts_ProductId",
                table: "SellerProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerProducts_SellerPanelId",
                table: "SellerProducts",
                column: "SellerPanelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SellerProducts");

            migrationBuilder.DropColumn(
                name: "DeliveryDurationForCapital",
                table: "SellerPanels");

            migrationBuilder.DropColumn(
                name: "DeliveryDurationForCity",
                table: "SellerPanels");

            migrationBuilder.DropColumn(
                name: "DeliveryDurationForOther",
                table: "SellerPanels");

            migrationBuilder.DropColumn(
                name: "WarrantyAmount",
                table: "SellerPanels");

            migrationBuilder.DropColumn(
                name: "WarrantyTypeId",
                table: "SellerPanels");
        }
    }
}
