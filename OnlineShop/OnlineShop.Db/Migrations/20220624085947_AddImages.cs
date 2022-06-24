using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class AddImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "Cost", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("a604ee7e-aa0e-4ffc-b596-816570a9bc79"), true, 100m, "Photography, 2000 x 3000 px, 4,5 Mb Tiff", "Still Life" },
                    { new Guid("7228b05f-8fb9-4171-a2e9-ab3aaeaf44cd"), true, 200m, "Photography, 2000 x 3000 px, 4,8 Mb Tiff", "Portret" },
                    { new Guid("e66f97c7-6414-423b-9589-8c92a964df62"), true, 300m, "Photography, 2000 x 3000 px, 3,5 Mb Tiff", "Landscape" },
                    { new Guid("ba082277-4b6f-4e86-a922-07353ce4ad13"), true, 400m, "Photography, 2000 x 3000 px, 2,5 Mb Tiff", "Abstraction" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { new Guid("7512a027-6c2b-44ec-9dc1-460dc630a1e0"), new Guid("a604ee7e-aa0e-4ffc-b596-816570a9bc79"), "/img/products/stilllife.jpg" },
                    { new Guid("7228b05f-8fb9-4171-a2e9-ab3aaeaf44cd"), new Guid("a604ee7e-aa0e-4ffc-b596-816570a9bc79"), "/img/products/portret.jpg" },
                    { new Guid("7512a027-6c2b-44ec-9dc1-450dc630a1e0"), new Guid("a604ee7e-aa0e-4ffc-b596-816570a9bc79"), "/img/products/landscape.jpg" },
                    { new Guid("a604ee7e-aa0e-4ffc-b596-816570a9bc79"), new Guid("a604ee7e-aa0e-4ffc-b596-816570a9bc79"), "/img/products/abstraction.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7228b05f-8fb9-4171-a2e9-ab3aaeaf44cd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ba082277-4b6f-4e86-a922-07353ce4ad13"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e66f97c7-6414-423b-9589-8c92a964df62"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a604ee7e-aa0e-4ffc-b596-816570a9bc79"));

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
