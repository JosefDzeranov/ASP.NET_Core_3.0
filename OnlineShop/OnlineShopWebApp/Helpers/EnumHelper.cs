using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;


namespace OnlineShopWebApp.Helpers
{
    public class EnumHelper
    {
        public static string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType()
                             .GetMember(enumValue.ToString())
                             .First()
                             .GetCustomAttribute<DisplayAttribute>()
                             .GetName();
        }
    }
}
