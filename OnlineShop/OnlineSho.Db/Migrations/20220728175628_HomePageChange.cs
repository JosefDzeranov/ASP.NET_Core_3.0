using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class HomePageChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("216f4453-1f86-4b38-8d47-a6db07b2257d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ae776cc5-c430-46e0-be43-e1e954dd88b5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ede5aedd-2b13-4ca3-9655-f32cb14ae4e5"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ComparisonId", "Cost", "Description", "FavoriteId", "ImagePath", "Name" },
                values: new object[] { new Guid("c08bb249-9fd9-4a1f-a91c-0c201511c6bc"), null, 5m, "Just a cheeseburger", null, "/images/burger1.jpg", "Cheeseburger" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ComparisonId", "Cost", "Description", "FavoriteId", "ImagePath", "Name" },
                values: new object[] { new Guid("41f5e894-560c-4262-8fa0-cd08c88c0e00"), null, 3m, "Just a hamburger", null, "/images/hamburger.jpg", "Hamburger" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ComparisonId", "Cost", "Description", "FavoriteId", "ImagePath", "Name" },
                values: new object[] { new Guid("e9638e87-f026-48d0-9e3f-364e90a4a09d"), null, 10m, "the biggest burger", null, "/images/burger1.jpg", "Bigburger" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("41f5e894-560c-4262-8fa0-cd08c88c0e00"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c08bb249-9fd9-4a1f-a91c-0c201511c6bc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e9638e87-f026-48d0-9e3f-364e90a4a09d"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ComparisonId", "Cost", "Description", "FavoriteId", "ImagePath", "Name" },
                values: new object[] { new Guid("ede5aedd-2b13-4ca3-9655-f32cb14ae4e5"), null, 5m, "Just a cheeseburger", null, "/images/burger1.jpg", "Cheeseburger" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ComparisonId", "Cost", "Description", "FavoriteId", "ImagePath", "Name" },
                values: new object[] { new Guid("ae776cc5-c430-46e0-be43-e1e954dd88b5"), null, 3m, "Just a hamburger", null, "/images/burger1.jpg", "Hamburger" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ComparisonId", "Cost", "Description", "FavoriteId", "ImagePath", "Name" },
                values: new object[] { new Guid("216f4453-1f86-4b38-8d47-a6db07b2257d"), null, 10m, "the biggest burger", null, "/images/burger1.jpg", "Bigburger" });
        }
    }
}
