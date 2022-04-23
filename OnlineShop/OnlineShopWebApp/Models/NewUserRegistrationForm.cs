namespace OnlineShopWebApp.Models
{
    public class NewUserRegistrationForm
    {
        public NewUserRegistrationForm()
        {
            
        }

        public NewUserRegistrationForm(string userName, string password, string confirmPassword)
        {
            UserName = userName;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public string UserName { get; set; }    
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
