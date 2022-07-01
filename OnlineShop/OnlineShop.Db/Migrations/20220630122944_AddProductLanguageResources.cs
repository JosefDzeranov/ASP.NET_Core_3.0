using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class AddProductLanguageResources : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StringResources");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7228b05f-8fb9-4171-a2e9-ab3aaeaf44cd"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7512a027-6c2b-44ec-9dc1-450dc630a1e0"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7512a027-6c2b-44ec-9dc1-460dc630a1e0"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a604ee7e-aa0e-4ffc-b596-816570a9bc79"));

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

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descriptions_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Descriptions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Names",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Names", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Names_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Names_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_LanguageId",
                table: "Descriptions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_ProductId",
                table: "Descriptions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Names_LanguageId",
                table: "Names",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Names_ProductId",
                table: "Names",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DropTable(
                name: "Names");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StringResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StringResources_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
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
                name: "IX_StringResources_LanguageId",
                table: "StringResources",
                column: "LanguageId");
        }
    }
}
