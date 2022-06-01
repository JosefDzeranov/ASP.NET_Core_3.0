using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class AddedIdentityFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0b7c7566-86a3-40f6-aa7b-ee001e18df26"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0d57e007-c943-4911-8c4c-2dbc0b095d83"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5f198c31-0f4a-4742-9095-66e5fb05ebcd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("671b9da8-5751-4ed2-89d3-754c68d88a2a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bd6ef54d-5327-4871-b8b2-0e3b96f07c42"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("d30cf8d2-9798-42a9-b847-e91a4511e2da"), true, 100m, "Photography, 2000 x 3000 px, 4,5 Mb Tiff", "/img/stilllife.jpg", "Still Life" },
                    { new Guid("5bd4a632-1610-4c6e-9e4b-be3b721e841b"), true, 200m, "Photography, 2000 x 3000 px, 4,8 Mb Tiff", "/img/portret.jpg", "Portret" },
                    { new Guid("1138558b-3acd-475f-aba7-b6fd88606b59"), true, 300m, "Photography, 2000 x 3000 px, 3,5 Mb Tiff", "/img/landscape.jpg", "Landscape" },
                    { new Guid("30245a9c-ee30-4ddc-b53d-8fa3f86f4f78"), true, 400m, "Photography, 2000 x 3000 px, 2,5 Mb Tiff", "/img/abstraction.jpg", "Abstraction" },
                    { new Guid("ad8c79ee-7fc2-4b41-834a-546da971b555"), true, 10m, "Calibration image, 2000 x 3000 px, 2,4 Mb Tiff", "/img/test.jpg", "Test" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1138558b-3acd-475f-aba7-b6fd88606b59"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("30245a9c-ee30-4ddc-b53d-8fa3f86f4f78"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5bd4a632-1610-4c6e-9e4b-be3b721e841b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ad8c79ee-7fc2-4b41-834a-546da971b555"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d30cf8d2-9798-42a9-b847-e91a4511e2da"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("bd6ef54d-5327-4871-b8b2-0e3b96f07c42"), true, 100m, "Photography, 2000 x 3000 px, 4,5 Mb Tiff", "/img/stilllife.jpg", "Still Life" },
                    { new Guid("671b9da8-5751-4ed2-89d3-754c68d88a2a"), true, 200m, "Photography, 2000 x 3000 px, 4,8 Mb Tiff", "/img/portret.jpg", "Portret" },
                    { new Guid("5f198c31-0f4a-4742-9095-66e5fb05ebcd"), true, 300m, "Photography, 2000 x 3000 px, 3,5 Mb Tiff", "/img/landscape.jpg", "Landscape" },
                    { new Guid("0b7c7566-86a3-40f6-aa7b-ee001e18df26"), true, 400m, "Photography, 2000 x 3000 px, 2,5 Mb Tiff", "/img/abstraction.jpg", "Abstraction" },
                    { new Guid("0d57e007-c943-4911-8c4c-2dbc0b095d83"), true, 10m, "Calibration image, 2000 x 3000 px, 2,4 Mb Tiff", "/img/test.jpg", "Test" }
                });
        }
    }
}
