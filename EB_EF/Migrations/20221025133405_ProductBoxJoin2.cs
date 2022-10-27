using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EB_EF.Migrations
{
    public partial class ProductBoxJoin2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealBoxProduct_MealBoxes_MealBoxId",
                table: "MealBoxProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_MealBoxProduct_Products_ProductId",
                table: "MealBoxProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealBoxProduct",
                table: "MealBoxProduct");

            migrationBuilder.RenameTable(
                name: "MealBoxProduct",
                newName: "MealBoxesProducts");

            migrationBuilder.RenameIndex(
                name: "IX_MealBoxProduct_ProductId",
                table: "MealBoxesProducts",
                newName: "IX_MealBoxesProducts_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MealBoxesProducts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealBoxesProducts",
                table: "MealBoxesProducts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MealBoxesProducts_MealBoxId",
                table: "MealBoxesProducts",
                column: "MealBoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealBoxesProducts_MealBoxes_MealBoxId",
                table: "MealBoxesProducts",
                column: "MealBoxId",
                principalTable: "MealBoxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealBoxesProducts_Products_ProductId",
                table: "MealBoxesProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealBoxesProducts_MealBoxes_MealBoxId",
                table: "MealBoxesProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_MealBoxesProducts_Products_ProductId",
                table: "MealBoxesProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealBoxesProducts",
                table: "MealBoxesProducts");

            migrationBuilder.DropIndex(
                name: "IX_MealBoxesProducts_MealBoxId",
                table: "MealBoxesProducts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MealBoxesProducts");

            migrationBuilder.RenameTable(
                name: "MealBoxesProducts",
                newName: "MealBoxProduct");

            migrationBuilder.RenameIndex(
                name: "IX_MealBoxesProducts_ProductId",
                table: "MealBoxProduct",
                newName: "IX_MealBoxProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealBoxProduct",
                table: "MealBoxProduct",
                columns: new[] { "MealBoxId", "ProductId" });

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
    }
}
