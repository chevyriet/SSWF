using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EB_EF.Migrations
{
    public partial class ProductBoxJoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealBoxProduct_MealBoxes_MealBoxesId",
                table: "MealBoxProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_MealBoxProduct_Products_ProductsId",
                table: "MealBoxProduct");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "MealBoxProduct",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "MealBoxesId",
                table: "MealBoxProduct",
                newName: "MealBoxId");

            migrationBuilder.RenameIndex(
                name: "IX_MealBoxProduct_ProductsId",
                table: "MealBoxProduct",
                newName: "IX_MealBoxProduct_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealBoxProduct_MealBoxes_MealBoxId",
                table: "MealBoxProduct",
                column: "MealBoxId",
                principalTable: "MealBoxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealBoxProduct_Products_ProductId",
                table: "MealBoxProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealBoxProduct_MealBoxes_MealBoxId",
                table: "MealBoxProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_MealBoxProduct_Products_ProductId",
                table: "MealBoxProduct");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "MealBoxProduct",
                newName: "ProductsId");

            migrationBuilder.RenameColumn(
                name: "MealBoxId",
                table: "MealBoxProduct",
                newName: "MealBoxesId");

            migrationBuilder.RenameIndex(
                name: "IX_MealBoxProduct_ProductId",
                table: "MealBoxProduct",
                newName: "IX_MealBoxProduct_ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealBoxProduct_MealBoxes_MealBoxesId",
                table: "MealBoxProduct",
                column: "MealBoxesId",
                principalTable: "MealBoxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealBoxProduct_Products_ProductsId",
                table: "MealBoxProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
