using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class initRelationForBrandAndModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProductBrandId",
                table: "ProductModels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ProductModels_ProductBrandId",
                table: "ProductModels",
                column: "ProductBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModels_ProductBrands_ProductBrandId",
                table: "ProductModels",
                column: "ProductBrandId",
                principalTable: "ProductBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductModels_ProductBrands_ProductBrandId",
                table: "ProductModels");

            migrationBuilder.DropIndex(
                name: "IX_ProductModels_ProductBrandId",
                table: "ProductModels");

            migrationBuilder.DropColumn(
                name: "ProductBrandId",
                table: "ProductModels");
        }
    }
}
