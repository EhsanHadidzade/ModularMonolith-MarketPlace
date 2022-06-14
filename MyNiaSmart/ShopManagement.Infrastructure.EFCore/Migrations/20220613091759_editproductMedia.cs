using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class editproductMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "SellerProductMedias",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SellerProductMedias");
        }
    }
}
