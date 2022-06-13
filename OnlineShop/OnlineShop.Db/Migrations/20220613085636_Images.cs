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
                keyValue: new Guid("484c735f-2b49-47da-a864-16a7235453ec"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4b440c91-6c7d-4269-8654-5fe34b4089a5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bebef8e9-20ef-4a84-8f48-6d5cbaecdf32"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c6fe4bbe-d224-4b64-98fd-570fa48fa26e"));

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name", "Pages" },
                values: new object[,]
                {
                    { new Guid("a7c6f2d4-5f5e-445c-a6c2-3a4f0ff5d60a"), 450m, "Автор: Стивен Кинг Жанр: мистика, ужасы", "/images/products/image1", "Оно", 1025 },
                    { new Guid("98510ec1-178c-4474-8abb-3f1d28e0dc5e"), 350m, "Автор: Терри Пратчетт Жанр: фэнтези", "/images/products/image2", "Мрачный жнец", 356 },
                    { new Guid("95b2ff2a-e979-4fed-938f-7809280caecc"), 300m, "Автор: Джек Лондон Жанр: роман", "/images/products/image3", "Странник по звездам", 332 },
                    { new Guid("8e6eba3f-b0b0-4472-b812-44e7749add1e"), 350m, "Автор: Дарья Донцова Жанр: детектив", "/images/products/image4", "Крутые наследнички", 425 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8e6eba3f-b0b0-4472-b812-44e7749add1e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("95b2ff2a-e979-4fed-938f-7809280caecc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("98510ec1-178c-4474-8abb-3f1d28e0dc5e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a7c6f2d4-5f5e-445c-a6c2-3a4f0ff5d60a"));

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Name", "Pages" },
                values: new object[,]
                {
                    { new Guid("484c735f-2b49-47da-a864-16a7235453ec"), 450m, "Автор: Стивен Кинг Жанр: мистика, ужасы", "Оно", 1025 },
                    { new Guid("4b440c91-6c7d-4269-8654-5fe34b4089a5"), 350m, "Автор: Терри Пратчетт Жанр: фэнтези", "Мрачный жнец", 356 },
                    { new Guid("c6fe4bbe-d224-4b64-98fd-570fa48fa26e"), 300m, "Автор: Джек Лондон Жанр: роман", "Странник по звездам", 332 },
                    { new Guid("bebef8e9-20ef-4a84-8f48-6d5cbaecdf32"), 350m, "Автор: Дарья Донцова Жанр: детектив", "Крутые наследнички", 425 }
                });
        }
    }
}
