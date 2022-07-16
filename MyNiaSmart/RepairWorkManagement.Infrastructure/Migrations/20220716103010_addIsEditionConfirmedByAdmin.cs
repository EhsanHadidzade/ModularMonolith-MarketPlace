using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class addIsEditionConfirmedByAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsEditedByClient",
                table: "RepairManServices",
                newName: "IsEditionConfirmedByAdmin");

            migrationBuilder.AlterColumn<int>(
                name: "MarketerShareAmount",
                table: "RepairManServices",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsEditionConfirmedByAdmin",
                table: "RepairManServices",
                newName: "IsEditedByClient");

            migrationBuilder.AlterColumn<long>(
                name: "MarketerShareAmount",
                table: "RepairManServices",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
