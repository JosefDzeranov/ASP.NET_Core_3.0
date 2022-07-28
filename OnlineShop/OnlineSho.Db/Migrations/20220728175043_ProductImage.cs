using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class ProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("74bdd703-f4f9-4305-8a82-1dc493f225f5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d6d57fca-10b5-4a4d-a743-a460393e933e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fcddb991-089c-4066-be35-881feb1986f4"));

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Products",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ComparisonId", "Cost", "Description", "FavoriteId", "Name" },
                values: new object[] { new Guid("fcddb991-089c-4066-be35-881feb1986f4"), null, 5m, "Just a cheeseburger", null, "Cheeseburger" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ComparisonId", "Cost", "Description", "FavoriteId", "Name" },
                values: new object[] { new Guid("d6d57fca-10b5-4a4d-a743-a460393e933e"), null, 3m, "Just a hamburger", null, "Hamburger" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ComparisonId", "Cost", "Description", "FavoriteId", "Name" },
                values: new object[] { new Guid("74bdd703-f4f9-4305-8a82-1dc493f225f5"), null, 10m, "the biggest burger", null, "Bigburger" });
        }
    }
}
