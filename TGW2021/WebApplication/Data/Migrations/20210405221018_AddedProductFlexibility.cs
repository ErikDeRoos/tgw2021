using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Data.Migrations
{
    public partial class AddedProductFlexibility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStocks_Suppliers_PreferredSupplierId",
                table: "ProductStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplier_ProductStocks_ProductStockId",
                table: "ProductSupplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductStocks",
                table: "ProductStocks");

            migrationBuilder.RenameTable(
                name: "ProductStocks",
                newName: "ProductStock");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductStock",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductStocks_PreferredSupplierId",
                table: "ProductStock",
                newName: "IX_ProductStock_PreferredSupplierId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductStock",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ProductStock",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductCompositionProductId",
                table: "ProductStock",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductStock",
                table: "ProductStock",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductCompositions",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deactivated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCompositions", x => x.ProductId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStock_ProductCompositionProductId",
                table: "ProductStock",
                column: "ProductCompositionProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStock_ProductCompositions_ProductCompositionProductId",
                table: "ProductStock",
                column: "ProductCompositionProductId",
                principalTable: "ProductCompositions",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStock_Suppliers_PreferredSupplierId",
                table: "ProductStock",
                column: "PreferredSupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplier_ProductStock_ProductStockId",
                table: "ProductSupplier",
                column: "ProductStockId",
                principalTable: "ProductStock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStock_ProductCompositions_ProductCompositionProductId",
                table: "ProductStock");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductStock_Suppliers_PreferredSupplierId",
                table: "ProductStock");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplier_ProductStock_ProductStockId",
                table: "ProductSupplier");

            migrationBuilder.DropTable(
                name: "ProductCompositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductStock",
                table: "ProductStock");

            migrationBuilder.DropIndex(
                name: "IX_ProductStock_ProductCompositionProductId",
                table: "ProductStock");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductStock");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ProductStock");

            migrationBuilder.DropColumn(
                name: "ProductCompositionProductId",
                table: "ProductStock");

            migrationBuilder.RenameTable(
                name: "ProductStock",
                newName: "ProductStocks");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductStocks",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductStock_PreferredSupplierId",
                table: "ProductStocks",
                newName: "IX_ProductStocks_PreferredSupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductStocks",
                table: "ProductStocks",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStocks_Suppliers_PreferredSupplierId",
                table: "ProductStocks",
                column: "PreferredSupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplier_ProductStocks_ProductStockId",
                table: "ProductSupplier",
                column: "ProductStockId",
                principalTable: "ProductStocks",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
