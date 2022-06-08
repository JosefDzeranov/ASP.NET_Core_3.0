using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class DeleteSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("08d693cf-c709-4c7f-b1f1-9ff167417d43"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("20a82b8b-dcc0-4282-a162-edc898ed6ed1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("47a30d03-3745-4aec-96bd-1adf80db3c51"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e626ea9a-b00c-4547-8fec-233e7d2da34d"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Name", "Pages" },
                values: new object[,]
                {
                    { new Guid("08d693cf-c709-4c7f-b1f1-9ff167417d43"), 450m, "Автор: Стивен Кинг Жанр: мистика, ужасы", "Оно", 1025 },
                    { new Guid("47a30d03-3745-4aec-96bd-1adf80db3c51"), 350m, "Автор: Терри Пратчетт Жанр: фэнтези", "Мрачный жнец", 356 },
                    { new Guid("e626ea9a-b00c-4547-8fec-233e7d2da34d"), 300m, "Автор: Джек Лондон Жанр: роман", "Странник по звездам", 332 },
                    { new Guid("20a82b8b-dcc0-4282-a162-edc898ed6ed1"), 350m, "Автор: Дарья Донцова Жанр: детектив", "Крутые наследнички", 425 }
                });
        }
    }
}
