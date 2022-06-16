using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.db.Migrations
{
    public partial class AddImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { -12, -12, "/images/thailand.jpg" },
                    { -11, -11, "/images/india.jpg" },
                    { -10, -10, "/images/jamaica.jpg" },
                    { -9, -9, "/images/seyshels.jpg" },
                    { -8, -8, "/images/uae.jpg" },
                    { -7, -7, "/images/egypt.jpg" },
                    { -6, -6, "/images/bali.jpg" },
                    { -5, -5, "/images/mexico.jpg" },
                    { -4, -4, "/images/aruba.jpg" },
                    { -3, -3, "/images/bulgary.jpg" },
                    { -2, 2, "/images/greece.jpg" },
                    { -1, 1, "/images/turkey.jpg" }
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

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -12,
                column: "ImagePath",
                value: "/images/thailand.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -11,
                column: "ImagePath",
                value: "/images/india.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -10,
                column: "ImagePath",
                value: "/images/jamaica.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -9,
                column: "ImagePath",
                value: "/images/seyshels.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -8,
                column: "ImagePath",
                value: "/images/uae.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -7,
                column: "ImagePath",
                value: "/images/egypt.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -6,
                column: "ImagePath",
                value: "/images/bali.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -5,
                column: "ImagePath",
                value: "/images/mexico.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -4,
                column: "ImagePath",
                value: "/images/aruba.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -3,
                column: "ImagePath",
                value: "/images/bulgary.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "/images/greece.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "/images/turkey.jpg");
        }
    }
}
