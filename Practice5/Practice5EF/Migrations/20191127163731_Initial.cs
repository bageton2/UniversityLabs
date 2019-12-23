using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Practice5EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductCategoryGID = table.Column<Guid>(nullable: false),
                    Caption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ProductCategoryGID);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderGID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProviderGID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductGID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    ProductCategoryGID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductGID);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryGID",
                        column: x => x.ProductCategoryGID,
                        principalTable: "ProductCategories",
                        principalColumn: "ProductCategoryGID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductsToProviders",
                columns: table => new
                {
                    ProductToProviderGID = table.Column<Guid>(nullable: false),
                    ProductGID = table.Column<Guid>(nullable: true),
                    ProviderGID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsToProviders", x => x.ProductToProviderGID);
                    table.ForeignKey(
                        name: "FK_ProductsToProviders_Products_ProductGID",
                        column: x => x.ProductGID,
                        principalTable: "Products",
                        principalColumn: "ProductGID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductsToProviders_Providers_ProviderGID",
                        column: x => x.ProviderGID,
                        principalTable: "Providers",
                        principalColumn: "ProviderGID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryGID",
                table: "Products",
                column: "ProductCategoryGID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsToProviders_ProductGID",
                table: "ProductsToProviders",
                column: "ProductGID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsToProviders_ProviderGID",
                table: "ProductsToProviders",
                column: "ProviderGID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsToProviders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
