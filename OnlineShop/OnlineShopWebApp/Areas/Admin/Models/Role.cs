using System.ComponentModel.DataAnnotations;
namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
