using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class NewImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("70e4cad5-8f9c-4766-80c7-f220d7d25aa7"), 450m, "Автор: Стивен Кинг Жанр: мистика, ужасы", "/images/products/image1.jpg", "Оно", 1025 },
                    { new Guid("0000916d-63f4-4100-af9d-a3d2796485ca"), 350m, "Автор: Терри Пратчетт Жанр: фэнтези", "/images/products/image2.jpg", "Мрачный жнец", 356 },
                    { new Guid("49496534-00a2-4873-aaf4-9d931a3d61fa"), 300m, "Автор: Джек Лондон Жанр: роман", "/images/products/image3.jpg", "Странник по звездам", 332 },
                    { new Guid("0e88a42e-0293-4278-9d72-2e8724481973"), 350m, "Автор: Дарья Донцова Жанр: детектив", "/images/products/image4.png", "Крутые наследнички", 425 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0000916d-63f4-4100-af9d-a3d2796485ca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0e88a42e-0293-4278-9d72-2e8724481973"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("49496534-00a2-4873-aaf4-9d931a3d61fa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("70e4cad5-8f9c-4766-80c7-f220d7d25aa7"));

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
    }
}
