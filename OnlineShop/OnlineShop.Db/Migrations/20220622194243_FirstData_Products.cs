using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class FirstData_Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("d680c0a4-6a32-412f-bbaa-6100b42e2fc1"), true, 5000m, "Составление и оформление документов для подачи в суд", "/images/court.jpg", "Составление документов, исков в суд" },
                    { new Guid("ca92038f-0e3a-4c2a-b415-b36475aaa000"), true, 4000m, "Составление документов для регистрации/банкротства ЮЛ", "/images/bankruptcy.jpg", "Составление документов для регистрации/банкротства ЮЛ" },
                    { new Guid("5ebf7bcd-eff5-48ee-b1f4-5b5a00ada4a8"), true, 6000m, "Сопровождение и ведение гражданского дела в суде", "/images/civil_case.jpg", "Сопровождение и ведение гражданского дела в суде" },
                    { new Guid("46aa1f63-32b8-48d5-a313-43a7846e7e09"), true, 3000m, "Консультация по вопросам", "/images/law_consultation.jpg", "Консультация по вопросам" },
                    { new Guid("11197fca-ad64-400d-ac3d-5298da3c4422"), true, 3000m, "Правовая экспертиза документов и договоров", "/images/examination_documents.jpg", "Анализ документов и договоров" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11197fca-ad64-400d-ac3d-5298da3c4422"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46aa1f63-32b8-48d5-a313-43a7846e7e09"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5ebf7bcd-eff5-48ee-b1f4-5b5a00ada4a8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ca92038f-0e3a-4c2a-b415-b36475aaa000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d680c0a4-6a32-412f-bbaa-6100b42e2fc1"));
        }
    }
}
