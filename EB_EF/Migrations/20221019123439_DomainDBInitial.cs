using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EB_EF.Migrations
{
    public partial class DomainDBInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "City",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentNr",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ContainsAlcohol",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CantinaId",
                table: "MealBoxes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "City",
                table: "MealBoxes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsEighteen",
                table: "MealBoxes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MealBoxes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PickupFromTime",
                table: "MealBoxes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PickupUntilTime",
                table: "MealBoxes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "MealBoxes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "MealBoxes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "MealBoxes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CantinaId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeNr",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "City",
                table: "Cantinas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Cantinas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ServesWarm",
                table: "Cantinas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "MealBoxProduct",
                columns: table => new
                {
                    MealBoxesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealBoxProduct", x => new { x.MealBoxesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_MealBoxProduct_MealBoxes_MealBoxesId",
                        column: x => x.MealBoxesId,
                        principalTable: "MealBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealBoxProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealBoxes_CantinaId",
                table: "MealBoxes",
                column: "CantinaId");

            migrationBuilder.CreateIndex(
                name: "IX_MealBoxes_StudentId",
                table: "MealBoxes",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CantinaId",
                table: "Employees",
                column: "CantinaId");

            migrationBuilder.CreateIndex(
                name: "IX_MealBoxProduct_ProductsId",
                table: "MealBoxProduct",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Cantinas_CantinaId",
                table: "Employees",
                column: "CantinaId",
                principalTable: "Cantinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealBoxes_Cantinas_CantinaId",
                table: "MealBoxes",
                column: "CantinaId",
                principalTable: "Cantinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealBoxes_Students_StudentId",
                table: "MealBoxes",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Cantinas_CantinaId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_MealBoxes_Cantinas_CantinaId",
                table: "MealBoxes");

            migrationBuilder.DropForeignKey(
                name: "FK_MealBoxes_Students_StudentId",
                table: "MealBoxes");

            migrationBuilder.DropTable(
                name: "MealBoxProduct");

            migrationBuilder.DropIndex(
                name: "IX_MealBoxes_CantinaId",
                table: "MealBoxes");

            migrationBuilder.DropIndex(
                name: "IX_MealBoxes_StudentId",
                table: "MealBoxes");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CantinaId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentNr",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ContainsAlcohol",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CantinaId",
                table: "MealBoxes");

            migrationBuilder.DropColumn(
                name: "City",
                table: "MealBoxes");

            migrationBuilder.DropColumn(
                name: "IsEighteen",
                table: "MealBoxes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MealBoxes");

            migrationBuilder.DropColumn(
                name: "PickupFromTime",
                table: "MealBoxes");

            migrationBuilder.DropColumn(
                name: "PickupUntilTime",
                table: "MealBoxes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "MealBoxes");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "MealBoxes");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "MealBoxes");

            migrationBuilder.DropColumn(
                name: "CantinaId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeNr",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Cantinas");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Cantinas");

            migrationBuilder.DropColumn(
                name: "ServesWarm",
                table: "Cantinas");
        }
    }
}
