using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class AddFirstData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
