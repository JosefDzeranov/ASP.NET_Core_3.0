using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public static class MyConstant
    {
        public const string NameOrganization = "ООО \"Капремонтпроект\"";

        public static readonly List<string> RosterStatus = new List<string>()
        {
            "Создан",
            "Обработан",
            "В пути",
            "Отменён",
            "Доставлен"
        };
    }
}
