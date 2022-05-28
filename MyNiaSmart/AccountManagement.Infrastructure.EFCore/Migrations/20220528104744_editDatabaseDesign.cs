using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManagement.Infrastructure.EFCore.Migrations
{
    public partial class editDatabaseDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCooperationRequests_Roles_RoleId",
                table: "UserCooperationRequests");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserCooperationRequests",
                newName: "PersonalityId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCooperationRequests_RoleId",
                table: "UserCooperationRequests",
                newName: "IX_UserCooperationRequests_PersonalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCooperationRequests_Personalities_PersonalityId",
                table: "UserCooperationRequests",
                column: "PersonalityId",
                principalTable: "Personalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCooperationRequests_Personalities_PersonalityId",
                table: "UserCooperationRequests");

            migrationBuilder.RenameColumn(
                name: "PersonalityId",
                table: "UserCooperationRequests",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCooperationRequests_PersonalityId",
                table: "UserCooperationRequests",
                newName: "IX_UserCooperationRequests_RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCooperationRequests_Roles_RoleId",
                table: "UserCooperationRequests",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
