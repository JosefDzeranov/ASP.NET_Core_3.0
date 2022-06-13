using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class NewImages2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("0468eb6c-d1e3-4241-9bbd-c556ef1267f5"), 450m, "Автор: Стивен Кинг Жанр: мистика, ужасы", "/images/products/king.jpg", "Оно", 1025 },
                    { new Guid("560900d8-55c5-427d-9e2f-ec43fbfb9311"), 350m, "Автор: Терри Пратчетт Жанр: фэнтези", "/images/products/terri.jpg", "Мрачный жнец", 356 },
                    { new Guid("0e46f88c-f1b1-49fe-a6f5-5ec1b9b59766"), 300m, "Автор: Джек Лондон Жанр: роман", "/images/products/london.jpg", "Странник по звездам", 332 },
                    { new Guid("4d340a05-a91f-4b19-b3a4-06cbdf142281"), 350m, "Автор: Дарья Донцова Жанр: детектив", "/images/products/don.png", "Крутые наследнички", 425 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0468eb6c-d1e3-4241-9bbd-c556ef1267f5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0e46f88c-f1b1-49fe-a6f5-5ec1b9b59766"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4d340a05-a91f-4b19-b3a4-06cbdf142281"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("560900d8-55c5-427d-9e2f-ec43fbfb9311"));

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
    }
}
