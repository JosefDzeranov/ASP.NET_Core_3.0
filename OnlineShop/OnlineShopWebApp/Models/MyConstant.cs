using System;
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

        public static Guid buyerIdDefault = Guid.Parse("0c4de82b-a3be-4592-84d6-8b0d63a46aa0");

        public static Guid ValidNullBuyerId(Guid buyerId)
        {
            
            if (buyerId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                return buyerIdDefault;
            }
            return buyerId;
        }
    }
}
