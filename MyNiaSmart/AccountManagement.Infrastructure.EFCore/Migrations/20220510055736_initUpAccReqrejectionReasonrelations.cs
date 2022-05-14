using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManagement.Infrastructure.EFCore.Migrations
{
    public partial class initUpAccReqrejectionReasonrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RejectionReasons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RejectionReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UpAccountRequestRejectionReasons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpAccountRequestId = table.Column<long>(type: "bigint", nullable: false),
                    RejectionReasonId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpAccountRequestRejectionReasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpAccountRequestRejectionReasons_RejectionReasons_RejectionReasonId",
                        column: x => x.RejectionReasonId,
                        principalTable: "RejectionReasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UpAccountRequestRejectionReasons_UpAccountRequests_UpAccountRequestId",
                        column: x => x.UpAccountRequestId,
                        principalTable: "UpAccountRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UpAccountRequestRejectionReasons_RejectionReasonId",
                table: "UpAccountRequestRejectionReasons",
                column: "RejectionReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_UpAccountRequestRejectionReasons_UpAccountRequestId",
                table: "UpAccountRequestRejectionReasons",
                column: "UpAccountRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UpAccountRequestRejectionReasons");

            migrationBuilder.DropTable(
                name: "RejectionReasons");
        }
    }
}
