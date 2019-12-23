using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCateoryGID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCateoryGID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCateoryGID",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductCateoryID",
                table: "Products",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ProductCateoryGID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCateoryGID",
                table: "Products",
                column: "ProductCateoryGID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCateoryGID",
                table: "Products",
                column: "ProductCateoryGID",
                principalTable: "ProductCategories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
