using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class AddBasketItemsDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_Baskets_BasketId",
                table: "BasketItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_Orders_OrderId",
                table: "BasketItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_Products_ProductId",
                table: "BasketItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketItem",
                table: "BasketItem");

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

            migrationBuilder.RenameTable(
                name: "BasketItem",
                newName: "BasketItems");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItem_ProductId",
                table: "BasketItems",
                newName: "IX_BasketItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItem_OrderId",
                table: "BasketItems",
                newName: "IX_BasketItems_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItem_BasketId",
                table: "BasketItems",
                newName: "IX_BasketItems_BasketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Baskets_BasketId",
                table: "BasketItems",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Orders_OrderId",
                table: "BasketItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Products_ProductId",
                table: "BasketItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Baskets_BasketId",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Orders_OrderId",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Products_ProductId",
                table: "BasketItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems");

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

            migrationBuilder.RenameTable(
                name: "BasketItems",
                newName: "BasketItem");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItem",
                newName: "IX_BasketItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItems_OrderId",
                table: "BasketItem",
                newName: "IX_BasketItem_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItems_BasketId",
                table: "BasketItem",
                newName: "IX_BasketItem_BasketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItem",
                table: "BasketItem",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_Baskets_BasketId",
                table: "BasketItem",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_Orders_OrderId",
                table: "BasketItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_Products_ProductId",
                table: "BasketItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
