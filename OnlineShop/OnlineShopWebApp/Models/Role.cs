using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp
{
    public class Role
    {
        [Required(ErrorMessage ="Введите название роли")]
        public string Name { get; set; }
    }
}
