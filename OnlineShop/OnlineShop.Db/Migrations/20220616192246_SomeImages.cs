using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class SomeImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Image_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name", "Pages" },
                values: new object[,]
                {
                    { new Guid("484c735f-2b49-47da-a864-16a7235453ee"), 450m, "Автор: Стивен Кинг Жанр: мистика, ужасы", null, "Оно", 1025 },
                    { new Guid("4b440c91-6c7d-4269-8654-5fe34b4089ae"), 350m, "Автор: Терри Пратчетт Жанр: фэнтези", null, "Мрачный жнец", 356 },
                    { new Guid("c6fe4bbe-d224-4b64-98fd-570fa48fa26c"), 300m, "Автор: Джек Лондон Жанр: роман", null, "Странник по звездам", 332 },
                    { new Guid("bebef8e9-20ef-4a84-8f48-6d5cbaecdf3e"), 350m, "Автор: Дарья Донцова Жанр: детектив", null, "Крутые наследнички", 425 }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "ImageId", "ProductId", "Url" },
                values: new object[,]
                {
                    { new Guid("484c735f-2b49-47da-a864-16a7235453eb"), new Guid("484c735f-2b49-47da-a864-16a7235453ee"), "/images/products/king.jpg" },
                    { new Guid("4b440c91-6c7d-4269-8654-5fe34b4089ab"), new Guid("4b440c91-6c7d-4269-8654-5fe34b4089ae"), "/images/products/terri.jpg" },
                    { new Guid("c6fe4bbe-d224-4b64-98fd-570fa48fa26b"), new Guid("c6fe4bbe-d224-4b64-98fd-570fa48fa26c"), "/images/products/london.jpg" },
                    { new Guid("bebef8e9-20ef-4a84-8f48-6d5cbaecdf3b"), new Guid("bebef8e9-20ef-4a84-8f48-6d5cbaecdf3e"), "/images/products/don.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductId",
                table: "Image",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("484c735f-2b49-47da-a864-16a7235453ee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4b440c91-6c7d-4269-8654-5fe34b4089ae"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bebef8e9-20ef-4a84-8f48-6d5cbaecdf3e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c6fe4bbe-d224-4b64-98fd-570fa48fa26c"));

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
    }
}
