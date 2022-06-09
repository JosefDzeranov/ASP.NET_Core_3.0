using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class EditRightsViewModel
    {
        public string UserName { get; set; }
        public IList<string> UserRoles { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
    }
}
