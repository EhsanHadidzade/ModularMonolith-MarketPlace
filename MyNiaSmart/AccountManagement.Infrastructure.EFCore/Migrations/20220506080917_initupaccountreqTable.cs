using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManagement.Infrastructure.EFCore.Migrations
{
    public partial class initupaccountreqTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UpAccountRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PI_FUllName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PI_FatherName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PI_IdentityNumber = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PI_NationalCode = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PI_BirthdayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PI_RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PI_IsMale = table.Column<bool>(type: "bit", nullable: false),
                    PI_IsNewIdentity = table.Column<bool>(type: "bit", nullable: false),
                    PI_IsNewNationalCard = table.Column<bool>(type: "bit", nullable: false),
                    PD_IdentityCard = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PD_NationalCardFrontSide = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PD_NationalCardBackSide = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PD_NationalCodeTrackingPaper = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    BI_BankName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    BI_BankAccountNumber = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    BI_CreditCardNumber = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    BI_ShabaNumber = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    BI_IsCreditCardWithFullInfo = table.Column<bool>(type: "bit", nullable: false),
                    BD_CreditCardFrontSide = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    BD_CreditCardBackSide = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    BD_ShabaPrint = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    GI_IsChequeGuarantyType = table.Column<bool>(type: "bit", nullable: false),
                    GI_ChequeNumber = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    GI_SafteNumber = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    GI_ChequeBankBranch = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    GI_ShenaseSayadiCheque = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    GD_ChequeFrontSide = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    GD_ChequeBackSide = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    GD_SafteFrontSide = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    GD_SafteBackSide = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IsRequestConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpAccountRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpAccountRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UpAccountRequests_UserId",
                table: "UpAccountRequests",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UpAccountRequests");
        }
    }
}
