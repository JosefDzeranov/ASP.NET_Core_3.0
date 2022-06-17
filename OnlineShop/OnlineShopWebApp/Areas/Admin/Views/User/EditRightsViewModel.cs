using System.Collections.Generic;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp.Areas.Admin.Views.User
{
    public class EditRightsViewModel
    {
        public string UserName { get; set; }
        public List<RoleViewModel> UserRoles { get; set; }

        public List<RoleViewModel> AllRoles { get; set; }

    }
}
