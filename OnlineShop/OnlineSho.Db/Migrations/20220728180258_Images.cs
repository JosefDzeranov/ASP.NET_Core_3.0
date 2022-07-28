using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class Images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("b2043c27-b966-401f-8365-efb126d759e5"), null, 5m, "Just a cheeseburger", null, "/images/burger1.jpg", "Cheeseburger" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ComparisonId", "Cost", "Description", "FavoriteId", "ImagePath", "Name" },
                values: new object[] { new Guid("9f4a4366-c13b-4d3c-bb8d-b4f46b8d4206"), null, 3m, "Just a hamburger", null, "/images/hamburger.jpg", "Hamburger" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ComparisonId", "Cost", "Description", "FavoriteId", "ImagePath", "Name" },
                values: new object[] { new Guid("ccb0ae4a-a268-46d0-98a6-191b59dde35a"), null, 10m, "the biggest burger", null, "/images/bigburger.jpg", "Bigburger" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f4a4366-c13b-4d3c-bb8d-b4f46b8d4206"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b2043c27-b966-401f-8365-efb126d759e5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ccb0ae4a-a268-46d0-98a6-191b59dde35a"));

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
    }
}
