using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("181082ae-c474-46f8-87fd-8ddecb38889f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("56869478-f60a-4223-93df-15c46464275f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8f4c292f-325c-4d5c-9173-eaabbe8883ee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("97bd9a12-edc8-4be1-b9f3-3a5f798d7196"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Name", "Pages" },
                values: new object[,]
                {
                    { new Guid("97bd9a12-edc8-4be1-b9f3-3a5f798d7196"), 450m, "Автор: Стивен Кинг Жанр: мистика, ужасы", "Оно", 1025 },
                    { new Guid("8f4c292f-325c-4d5c-9173-eaabbe8883ee"), 350m, "Автор: Терри Пратчетт Жанр: фэнтези", "Мрачный жнец", 356 },
                    { new Guid("181082ae-c474-46f8-87fd-8ddecb38889f"), 300m, "Автор: Джек Лондон Жанр: роман", "Странник по звездам", 332 },
                    { new Guid("56869478-f60a-4223-93df-15c46464275f"), 350m, "Автор: Дарья Донцова Жанр: детектив", "Крутые наследнички", 425 }
                });
        }
    }
}
