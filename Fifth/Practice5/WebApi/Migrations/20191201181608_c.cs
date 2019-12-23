using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCateoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCateoryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCateoryID",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryID",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryID",
                table: "Products",
                column: "ProductCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryID",
                table: "Products",
                column: "ProductCategoryID",
                principalTable: "ProductCategories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCategoryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCategoryID",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductCateoryID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCateoryID",
                table: "Products",
                column: "ProductCateoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCateoryID",
                table: "Products",
                column: "ProductCateoryID",
                principalTable: "ProductCategories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
