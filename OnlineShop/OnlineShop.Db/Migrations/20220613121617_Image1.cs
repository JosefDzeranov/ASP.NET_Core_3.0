using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class Image1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name", "Pages" },
                values: new object[,]
                {
                    { new Guid("e584204a-a402-46c9-afc5-556392d53214"), 450m, "Автор: Стивен Кинг Жанр: мистика, ужасы", "/images/products/image1.jpg", "Оно", 1025 },
                    { new Guid("f1fb6aa1-0734-4ce1-a703-c98fd7d2527b"), 350m, "Автор: Терри Пратчетт Жанр: фэнтези", "/images/products/image2.jpg", "Мрачный жнец", 356 },
                    { new Guid("6077ff1c-0f23-403f-94b6-bdcbb72c6e40"), 300m, "Автор: Джек Лондон Жанр: роман", "/images/products/image3.jpg", "Странник по звездам", 332 },
                    { new Guid("ee4ad8ee-3a4e-480e-922c-be7cdb3ce8b9"), 350m, "Автор: Дарья Донцова Жанр: детектив", "/images/products/image4.jpg", "Крутые наследнички", 425 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6077ff1c-0f23-403f-94b6-bdcbb72c6e40"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e584204a-a402-46c9-afc5-556392d53214"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ee4ad8ee-3a4e-480e-922c-be7cdb3ce8b9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f1fb6aa1-0734-4ce1-a703-c98fd7d2527b"));

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
    }
}
