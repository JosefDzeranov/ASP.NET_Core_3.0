using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShopWebApp.Models.Attributes
{
    public class NewRegistrName : ValidationAttribute
    {
        private readonly IUserBase _userBase;

        public NewRegistrName(IUserBase userBase)
        {
            _userBase = userBase;
        }

        public NewRegistrName() {}

        public override bool IsValid(object value)
        {
            Registration data = (Registration)value;
            var allUsers = _userBase.AllUsers();
            if (allUsers.Any(x => x.Name == data.Name))
            {
                ErrorMessage = "Такое имя уже существует. Попробуйте другое";
                return false;
            }
            return true;
        }
    }
}
