using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class EditShopProductTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMappings_ProductBrands_ProductBrandId",
                table: "ProductMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductMappings_ProductModels_ProductModelId",
                table: "ProductMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductMappings_ProductStatuses_ProductStatusId",
                table: "ProductMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductMappings_ProductTypes_ProductTypeId",
                table: "ProductMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductMappings_ProductUsageType_ProductUsageTypeId",
                table: "ProductMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductUsageType",
                table: "ProductUsageType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductMappings",
                table: "ProductMappings");

            migrationBuilder.RenameTable(
                name: "ProductUsageType",
                newName: "ProductUsageTypes");

            migrationBuilder.RenameTable(
                name: "ProductMappings",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_ProductMappings_ProductUsageTypeId",
                table: "Products",
                newName: "IX_Products_ProductUsageTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductMappings_ProductTypeId",
                table: "Products",
                newName: "IX_Products_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductMappings_ProductStatusId",
                table: "Products",
                newName: "IX_Products_ProductStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductMappings_ProductModelId",
                table: "Products",
                newName: "IX_Products_ProductModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductMappings_ProductBrandId",
                table: "Products",
                newName: "IX_Products_ProductBrandId");

            migrationBuilder.DropPrimaryKey("PK_ProductTypes", "ProductTypes");
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "ProductTypes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
            migrationBuilder.AddPrimaryKey("PK_ProductTypes", "ProductTypes", "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DropPrimaryKey("PK_ProductStatuses", "ProductStatuses");
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "ProductStatuses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
            migrationBuilder.AddPrimaryKey("PK_ProductStatuses", "ProductStatuses", "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductStatuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DropPrimaryKey("PK_ProductModels", "ProductModels");
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "ProductModels",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
            migrationBuilder.AddPrimaryKey("PK_ProductModels", "ProductModels", "Id");


            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductModels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DropPrimaryKey("PK_ProductBrands", "ProductBrands");
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "ProductBrands",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
            migrationBuilder.AddPrimaryKey("PK_ProductBrands", "ProductBrands", "Id");


            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductBrands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.DropPrimaryKey("PK_ProductUsageTypes", "ProductUsageTypes");
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "ProductUsageTypes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
            //migrationBuilder.AddPrimaryKey("PK_ProductUsageTypes", "ProductUsageTypes", "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductUsageTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<long>(
                name: "ProductUsageTypeId",
                table: "Products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ProductTypeId",
                table: "Products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ProductStatusId",
                table: "Products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ProductModelId",
                table: "Products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ProductBrandId",
                table: "Products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            //migrationBuilder.DropPrimaryKey("PK_Products", "Products");
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
            //migrationBuilder.AddPrimaryKey("PK_Products", "Products", "Id");


            migrationBuilder.AddColumn<string>(
                name: "Descriotion",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Products",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Products",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductUsageTypes",
                table: "ProductUsageTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductBrands_ProductBrandId",
                table: "Products",
                column: "ProductBrandId",
                principalTable: "ProductBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductModels_ProductModelId",
                table: "Products",
                column: "ProductModelId",
                principalTable: "ProductModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductStatuses_ProductStatusId",
                table: "Products",
                column: "ProductStatusId",
                principalTable: "ProductStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductUsageTypes_ProductUsageTypeId",
                table: "Products",
                column: "ProductUsageTypeId",
                principalTable: "ProductUsageTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductBrands_ProductBrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductModels_ProductModelId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductStatuses_ProductStatusId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductUsageTypes_ProductUsageTypeId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductUsageTypes",
                table: "ProductUsageTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductStatuses");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductModels");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductBrands");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductUsageTypes");

            migrationBuilder.DropColumn(
                name: "Descriotion",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "ProductUsageTypes",
                newName: "ProductUsageType");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ProductMappings");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductUsageTypeId",
                table: "ProductMappings",
                newName: "IX_ProductMappings_ProductUsageTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductTypeId",
                table: "ProductMappings",
                newName: "IX_ProductMappings_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductStatusId",
                table: "ProductMappings",
                newName: "IX_ProductMappings_ProductStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductModelId",
                table: "ProductMappings",
                newName: "IX_ProductMappings_ProductModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductBrandId",
                table: "ProductMappings",
                newName: "IX_ProductMappings_ProductBrandId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProductTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProductStatuses",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProductModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProductBrands",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProductUsageType",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ProductUsageTypeId",
                table: "ProductMappings",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeId",
                table: "ProductMappings",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ProductStatusId",
                table: "ProductMappings",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ProductModelId",
                table: "ProductMappings",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ProductBrandId",
                table: "ProductMappings",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProductMappings",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductUsageType",
                table: "ProductUsageType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductMappings",
                table: "ProductMappings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMappings_ProductBrands_ProductBrandId",
                table: "ProductMappings",
                column: "ProductBrandId",
                principalTable: "ProductBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMappings_ProductModels_ProductModelId",
                table: "ProductMappings",
                column: "ProductModelId",
                principalTable: "ProductModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMappings_ProductStatuses_ProductStatusId",
                table: "ProductMappings",
                column: "ProductStatusId",
                principalTable: "ProductStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMappings_ProductTypes_ProductTypeId",
                table: "ProductMappings",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMappings_ProductUsageType_ProductUsageTypeId",
                table: "ProductMappings",
                column: "ProductUsageTypeId",
                principalTable: "ProductUsageType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
