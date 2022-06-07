using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Наименование роли не заполнено")]
        public string Name { get; set; }
    }
}