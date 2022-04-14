namespace OnlineShopWebApp.Services
{
    public interface ICustomerProfile
    {
        string Adress { get; set; }
        string Email { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        string Phone { get; set; }
        string Surname { get; set; }
    }
}