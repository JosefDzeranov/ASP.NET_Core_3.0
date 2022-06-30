using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class CorrectProductLanguageResources : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Descriptions_Languages_LanguageId",
                table: "Descriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Names_Languages_LanguageId",
                table: "Names");

            migrationBuilder.DropIndex(
                name: "IX_Names_LanguageId",
                table: "Names");

            migrationBuilder.DropIndex(
                name: "IX_Descriptions_LanguageId",
                table: "Descriptions");

            migrationBuilder.CreateTable(
                name: "LanguageProductDescResource",
                columns: table => new
                {
                    DescriptionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageProductDescResource", x => new { x.DescriptionsId, x.LanguagesId });
                    table.ForeignKey(
                        name: "FK_LanguageProductDescResource_Descriptions_DescriptionsId",
                        column: x => x.DescriptionsId,
                        principalTable: "Descriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageProductDescResource_Languages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageProductNameResource",
                columns: table => new
                {
                    LanguagesId = table.Column<int>(type: "int", nullable: false),
                    NamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageProductNameResource", x => new { x.LanguagesId, x.NamesId });
                    table.ForeignKey(
                        name: "FK_LanguageProductNameResource_Languages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageProductNameResource_Names_NamesId",
                        column: x => x.NamesId,
                        principalTable: "Names",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageProductDescResource_LanguagesId",
                table: "LanguageProductDescResource",
                column: "LanguagesId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageProductNameResource_NamesId",
                table: "LanguageProductNameResource",
                column: "NamesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageProductDescResource");

            migrationBuilder.DropTable(
                name: "LanguageProductNameResource");

            migrationBuilder.CreateIndex(
                name: "IX_Names_LanguageId",
                table: "Names",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_LanguageId",
                table: "Descriptions",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Descriptions_Languages_LanguageId",
                table: "Descriptions",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Names_Languages_LanguageId",
                table: "Names",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
