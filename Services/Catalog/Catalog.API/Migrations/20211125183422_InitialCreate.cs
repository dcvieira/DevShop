using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "T-Shirt" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "Mug" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), "Accessories" });

            migrationBuilder.InsertData(
                table: "CatalogItems",
                columns: new[] { "Id", "CategoryId", "Description", "ImgUrl", "Name", "Price" },
                values: new object[] { new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "ANGULAR T-Shirt", "https://cdn.shopify.com/s/files/1/0528/4148/0360/products/unisex-premium-t-shirt-true-royal-front-601befd7623e4_360x.jpg?v=1612443619", "ANGULAR T-Shirt", 25m });

            migrationBuilder.InsertData(
                table: "CatalogItems",
                columns: new[] { "Id", "CategoryId", "Description", "ImgUrl", "Name", "Price" },
                values: new object[] { new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "VUE T-Shirt", "https://cdn.shopify.com/s/files/1/0528/4148/0360/products/unisex-premium-t-shirt-navy-front-601bf2c110bb9_1800x1800.jpg?v=1612444364", "VUE T-Shirt", 25m });

            migrationBuilder.InsertData(
                table: "CatalogItems",
                columns: new[] { "Id", "CategoryId", "Description", "ImgUrl", "Name", "Price" },
                values: new object[] { new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"), new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "JAVASCRIPT Mug with Color Inside", "https://cdn.shopify.com/s/files/1/0528/4148/0360/products/white-ceramic-mug-with-color-inside-yellow-11oz-left-602ed2f551170_1800x1800.jpg?v=1613681400", "JAVASCRIPT Mug with Color Inside", 16m });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_CategoryId",
                table: "CatalogItems",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogItems");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
