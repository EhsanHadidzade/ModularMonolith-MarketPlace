using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManagement.Infrastructure.EFCore.Migrations
{
    public partial class initPersonalityTypeAndUserPersonalityRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PersonalityTypeId",
                table: "Personalities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "PersonalityTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPersonalityRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalityId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPersonalityRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPersonalityRequests_Personalities_PersonalityId",
                        column: x => x.PersonalityId,
                        principalTable: "Personalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPersonalityRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personalities_PersonalityTypeId",
                table: "Personalities",
                column: "PersonalityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalityRequests_PersonalityId",
                table: "UserPersonalityRequests",
                column: "PersonalityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalityRequests_UserId",
                table: "UserPersonalityRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personalities_PersonalityTypes_PersonalityTypeId",
                table: "Personalities",
                column: "PersonalityTypeId",
                principalTable: "PersonalityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personalities_PersonalityTypes_PersonalityTypeId",
                table: "Personalities");

            migrationBuilder.DropTable(
                name: "PersonalityTypes");

            migrationBuilder.DropTable(
                name: "UserPersonalityRequests");

            migrationBuilder.DropIndex(
                name: "IX_Personalities_PersonalityTypeId",
                table: "Personalities");

            migrationBuilder.DropColumn(
                name: "PersonalityTypeId",
                table: "Personalities");
        }
    }
}
