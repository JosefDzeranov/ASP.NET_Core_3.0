using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace OnlineShop.DB.Migrations
{
    public partial class InsertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Cost", "Description", "ImgPath" },
                values: new object[] { Guid.NewGuid(), "Овод", "455", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "/images/book.png" }
                );
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Cost", "Description", "ImgPath" },
                values: new object[] { Guid.NewGuid(), "Незнайка на луне", "502", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "/images/book.png" }
                );
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Cost", "Description", "ImgPath" },
                new object[] { Guid.NewGuid(), "Отверженные", "976", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "/images/book.png" }
                );
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Cost", "Description", "ImgPath" },
                new object[] { Guid.NewGuid(), "Что делать?", "654", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "/images/book.png" }
                );
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Cost", "Description", "ImgPath" },
                new object[] { Guid.NewGuid(), "Одисея капитана Блада", "1242", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "/images/book.png" }
                );
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Cost", "Description", "ImgPath" },
                values: new object[] { Guid.NewGuid(), "Богач, бедняк", "1000", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "/images/book.png" }
                );
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Cost", "Description", "ImgPath" },
                values: new object[] { Guid.NewGuid(), "Война и Мир", "1348", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "/images/book.png" }
                );
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Cost", "Description", "ImgPath" },
                values: new object[] { Guid.NewGuid(), "Отцы и дети", "879", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "/images/book.png" }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

       
        }
    }
}
