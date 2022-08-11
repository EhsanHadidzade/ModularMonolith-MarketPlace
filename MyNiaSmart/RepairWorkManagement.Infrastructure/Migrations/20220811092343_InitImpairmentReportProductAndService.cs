using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class InitImpairmentReportProductAndService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SystemServiceId",
                table: "UserImapairmentReports");

            migrationBuilder.CreateTable(
                name: "ImpairmentReportProducts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserImpairmentReportId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpairmentReportProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImpairmentReportProducts_UserImapairmentReports_UserImpairmentReportId",
                        column: x => x.UserImpairmentReportId,
                        principalTable: "UserImapairmentReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImpairmentReportServices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserImpairmentReportId = table.Column<long>(type: "bigint", nullable: false),
                    SystemServiceId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpairmentReportServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImpairmentReportServices_UserImapairmentReports_UserImpairmentReportId",
                        column: x => x.UserImpairmentReportId,
                        principalTable: "UserImapairmentReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImpairmentReportProducts_UserImpairmentReportId",
                table: "ImpairmentReportProducts",
                column: "UserImpairmentReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ImpairmentReportServices_UserImpairmentReportId",
                table: "ImpairmentReportServices",
                column: "UserImpairmentReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImpairmentReportProducts");

            migrationBuilder.DropTable(
                name: "ImpairmentReportServices");

            migrationBuilder.AddColumn<long>(
                name: "SystemServiceId",
                table: "UserImapairmentReports",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
