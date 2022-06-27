using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
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

        public static readonly Guid RoleDefaultId = Guid.Parse("674b2f41-3173-4a0c-8f7e-4043876b8ee3");

        public static readonly Guid defaultBuyerId = Guid.Parse("0c4de82b-a3be-4592-84d6-8b0d63a46aa0");


    }
}
