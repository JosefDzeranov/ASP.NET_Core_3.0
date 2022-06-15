using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Название не заполнено")]
        public string Name { get; set; }
    }
}