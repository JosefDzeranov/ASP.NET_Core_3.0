using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class AddProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("cd96483b-1355-42d8-af13-cbed6fb9c62b"), 450m, "Автор: Стивен Кинг Жанр: мистика, ужасы", "/images/products/king.jpg", "Оно", 1025 },
                    { new Guid("10c24824-0593-4a95-b389-838561e14ee0"), 350m, "Автор: Терри Пратчетт Жанр: фэнтези", "/images/products/terri.jpg", "Мрачный жнец", 356 },
                    { new Guid("51bfdd19-2d33-4b0b-896d-65432751deb4"), 300m, "Автор: Джек Лондон Жанр: роман", "/images/products/london.jpg", "Странник по звездам", 332 },
                    { new Guid("809659f0-cae4-4dc7-811c-4f4eabe5e2a4"), 350m, "Автор: Дарья Донцова Жанр: детектив", "/images/products/don.jpg", "Крутые наследнички", 425 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10c24824-0593-4a95-b389-838561e14ee0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("51bfdd19-2d33-4b0b-896d-65432751deb4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("809659f0-cae4-4dc7-811c-4f4eabe5e2a4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cd96483b-1355-42d8-af13-cbed6fb9c62b"));

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
    }
}
