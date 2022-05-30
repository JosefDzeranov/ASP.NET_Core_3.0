using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class AddAvailableProductProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1826232c-3c58-4038-b3ff-1f3644f70ca8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7aa1e5a0-be29-4729-afe9-8de3badb1c49"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a7980ad9-1c03-42bc-9a62-8e29fc7ad31b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b7d9ae2d-891b-496c-ba1d-b2910601c780"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("be440a3a-3164-4645-b3fd-251150fb7914"));

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("722ddc6b-4934-4492-bd01-f49449a0913b"), true, 100m, "Photography, 2000 x 3000 px, 4,5 Mb Tiff", "/img/stilllife.jpg", "Still Life" },
                    { new Guid("dc3a8dbb-d780-470e-a3c0-63fc0df4a90f"), true, 200m, "Photography, 2000 x 3000 px, 4,8 Mb Tiff", "/img/portret.jpg", "Portret" },
                    { new Guid("71661c63-e0e9-47cd-b34a-4587f35d474b"), true, 300m, "Photography, 2000 x 3000 px, 3,5 Mb Tiff", "/img/landscape.jpg", "Landscape" },
                    { new Guid("c7b82fe1-c764-402c-a085-b558b4ea2489"), true, 400m, "Photography, 2000 x 3000 px, 2,5 Mb Tiff", "/img/abstraction.jpg", "Abstraction" },
                    { new Guid("2726ea01-d4b2-4473-a4e0-179ab82ce686"), true, 10m, "Calibration image, 2000 x 3000 px, 2,4 Mb Tiff", "/img/test.jpg", "Test" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2726ea01-d4b2-4473-a4e0-179ab82ce686"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("71661c63-e0e9-47cd-b34a-4587f35d474b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("722ddc6b-4934-4492-bd01-f49449a0913b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c7b82fe1-c764-402c-a085-b558b4ea2489"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dc3a8dbb-d780-470e-a3c0-63fc0df4a90f"));

            migrationBuilder.DropColumn(
                name: "Available",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("a7980ad9-1c03-42bc-9a62-8e29fc7ad31b"), 100m, "Photography, 2000 x 3000 px, 4,5 Mb Tiff", "/img/stilllife.jpg", "Still Life" },
                    { new Guid("be440a3a-3164-4645-b3fd-251150fb7914"), 200m, "Photography, 2000 x 3000 px, 4,8 Mb Tiff", "/img/portret.jpg", "Portret" },
                    { new Guid("1826232c-3c58-4038-b3ff-1f3644f70ca8"), 300m, "Photography, 2000 x 3000 px, 3,5 Mb Tiff", "/img/landscape.jpg", "Landscape" },
                    { new Guid("7aa1e5a0-be29-4729-afe9-8de3badb1c49"), 400m, "Photography, 2000 x 3000 px, 2,5 Mb Tiff", "/img/abstraction.jpg", "Abstraction" },
                    { new Guid("b7d9ae2d-891b-496c-ba1d-b2910601c780"), 10m, "Calibration image, 2000 x 3000 px, 2,4 Mb Tiff", "/img/test.jpg", "Test" }
                });
        }
    }
}
