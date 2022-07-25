using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Введите название роли")]
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var role = obj as RoleViewModel;
            return Name == role.Name;
        }
    }
}
