using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class initSelerProductMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmedBySeller",
                table: "SellerProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SellerProductMedias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaURL = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MediaAlt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MediaTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsSelectedBySeller = table.Column<bool>(type: "bit", nullable: false),
                    SellerProductId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerProductMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellerProductMedias_SellerProducts_SellerProductId",
                        column: x => x.SellerProductId,
                        principalTable: "SellerProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SellerProductMedias_SellerProductId",
                table: "SellerProductMedias",
                column: "SellerProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SellerProductMedias");

            migrationBuilder.DropColumn(
                name: "IsConfirmedBySeller",
                table: "SellerProducts");
        }
    }
}
