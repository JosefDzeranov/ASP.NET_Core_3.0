using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class EditColumnTypeCostProductDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("35a6d82f-4067-47d8-9e04-bfed37734c57"), true, 5000m, "Составление и оформление документов для подачи в суд", "/images/court.jpg", "Составление документов, исков в суд" },
                    { new Guid("bfcbbe93-e64f-4d6f-9334-9f700801537e"), true, 4000m, "Составление документов для регистрации/банкротства ЮЛ", "/images/bankruptcy.jpg", "Составление документов для регистрации/банкротства ЮЛ" },
                    { new Guid("dceb0144-1348-4ab6-b7fe-5ea54c872e4b"), true, 6000m, "Сопровождение и ведение гражданского дела в суде", "/images/civil_case.jpg", "Сопровождение и ведение гражданского дела в суде" },
                    { new Guid("46254821-f4e3-4446-9183-5cdd34961482"), true, 3000m, "Консультация по вопросам", "/images/law_consultation.jpg", "Консультация по вопросам" },
                    { new Guid("d72a90a2-835f-4b6d-969f-9a299bfadc1d"), true, 3000m, "Правовая экспертиза документов и договоров", "/images/examination_documents.jpg", "Анализ документов и договоров" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("35a6d82f-4067-47d8-9e04-bfed37734c57"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46254821-f4e3-4446-9183-5cdd34961482"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bfcbbe93-e64f-4d6f-9334-9f700801537e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d72a90a2-835f-4b6d-969f-9a299bfadc1d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dceb0144-1348-4ab6-b7fe-5ea54c872e4b"));

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
    }
}
