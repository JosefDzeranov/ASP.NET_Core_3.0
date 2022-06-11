using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class AddDefaultProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDataTime",
                table: "Carts",
                newName: "CreatedDateTime");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("31825d42-7a2c-4245-84a5-32f044df42eb"), 1000m, "Description1", "/images/item1.jpg", "Name1" },
                    { new Guid("99b708a2-dcf2-4614-9a52-6c828bf3ef01"), 2000m, "Description2", "/images/item2.jpg", "Name2" },
                    { new Guid("c6acbc3f-3429-4cb7-8242-c896feb0c8ea"), 3000m, "Description3", "/images/item3.jpg", "Name3" },
                    { new Guid("d93266b2-af1d-4d7b-abcf-7ff41138c8ad"), 4000m, "Description4", "/images/item4.jpg", "Name4" },
                    { new Guid("77e13cf3-2861-4c5f-9dfa-bde3eeb5eaf6"), 5000m, "Description5", "/images/item5.jpg", "Name5" },
                    { new Guid("dc3024e6-a030-4aff-8d2b-8a1b8c35c1d8"), 6000m, "Description6", "/images/item6.jpg", "Name6" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("31825d42-7a2c-4245-84a5-32f044df42eb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("77e13cf3-2861-4c5f-9dfa-bde3eeb5eaf6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("99b708a2-dcf2-4614-9a52-6c828bf3ef01"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c6acbc3f-3429-4cb7-8242-c896feb0c8ea"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d93266b2-af1d-4d7b-abcf-7ff41138c8ad"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dc3024e6-a030-4aff-8d2b-8a1b8c35c1d8"));

            migrationBuilder.RenameColumn(
                name: "CreatedDateTime",
                table: "Carts",
                newName: "CreatedDataTime");
        }
    }
}
