using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class RemoveRelMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellerProductMedias_SellerProducts_SellerProductId",
                table: "SellerProductMedias");

            migrationBuilder.DropIndex(
                name: "IX_SellerProductMedias_SellerProductId",
                table: "SellerProductMedias");

            migrationBuilder.AlterColumn<long>(
                name: "SellerProductId",
                table: "SellerProductMedias",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "SellerProductId",
                table: "SellerProductMedias",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_SellerProductMedias_SellerProductId",
                table: "SellerProductMedias",
                column: "SellerProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SellerProductMedias_SellerProducts_SellerProductId",
                table: "SellerProductMedias",
                column: "SellerProductId",
                principalTable: "SellerProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
