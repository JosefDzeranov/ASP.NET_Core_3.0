using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.db.Migrations
{
    public partial class AddFirstData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -1,
                column: "IsActive",
                value: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "FavoriteProductId", "ImagePath", "IsActive", "Name" },
                values: new object[,]
                {
                    { -12, 45000m, "Тур в Таиланд за 45000 рублей", null, "/images/thailand.jpg", true, "Тур в Таиланд" },
                    { -11, 60000m, "Тур в Индию за 60000 рублей", null, "/images/india.jpg", true, "Тур в Индию" },
                    { -10, 50000m, "Тур на Мальдивские острова за 50000 рублей", null, "/images/jamaica.jpg", true, "Тур на Ямайку" },
                    { -9, 45000m, "Тур на Сейшельские острова за 45000 рублей", null, "/images/seyshels.jpg", true, "Тур на Сейшельские острова" },
                    { -8, 60000m, "Тур в ОАЭ за 60000 рублей", null, "/images/uae.jpg", true, "Тур в ОАЭ" },
                    { -7, 50000m, "Тур в Еипет за 50000 рублей", null, "/images/egypt.jpg", true, "Тур в Египет" },
                    { -6, 45000m, "Тур на Бали за 45000 рублей", null, "/images/bali.jpg", true, "Тур на Бали" },
                    { -5, 60000m, "Тур в Мексику за 60000 рублей", null, "/images/mexico.jpg", true, "Тур в Мексику" },
                    { -4, 50000m, "Тур на Арубу за 50000 рублей", null, "/images/aruba.jpg", true, "Тур на Арубу" },
                    { -3, 45000m, "Тур в Болгарию за 45000 рублей", null, "/images/bulgary.jpg", true, "Тур в Болгарию" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -2,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -1,
                column: "IsActive",
                value: false);
        }
    }
}
