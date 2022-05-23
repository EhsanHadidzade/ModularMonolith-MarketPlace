using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManagement.Infrastructure.EFCore.Migrations
{
    public partial class initWalletTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalWallets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    OwnerFullName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OwnerRegistrationDate = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalWallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalWallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalletOperationTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationTypeTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletOperationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalWalletOperations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    IsPay = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalWalletId = table.Column<long>(type: "bigint", nullable: false),
                    WalletOperationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalWalletOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalWalletOperations_PersonalWallets_PersonalWalletId",
                        column: x => x.PersonalWalletId,
                        principalTable: "PersonalWallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalWalletOperations_WalletOperationTypes_WalletOperationTypeId",
                        column: x => x.WalletOperationTypeId,
                        principalTable: "WalletOperationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalWalletOperations_PersonalWalletId",
                table: "PersonalWalletOperations",
                column: "PersonalWalletId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalWalletOperations_WalletOperationTypeId",
                table: "PersonalWalletOperations",
                column: "WalletOperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalWallets_UserId",
                table: "PersonalWallets",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalWalletOperations");

            migrationBuilder.DropTable(
                name: "PersonalWallets");

            migrationBuilder.DropTable(
                name: "WalletOperationTypes");
        }
    }
}
