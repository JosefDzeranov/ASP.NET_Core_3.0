namespace OnlineShopWebApp.Services
{
    public class InMemoryCustomerProfile : ICustomerProfile
    {
        public InMemoryCustomerProfile()
        {
        }


        public InMemoryCustomerProfile(string name, string surname, int id, string email, string adress, string phone, ICustomerProfile customerProfile)
        {
            Name = name;
            Surname = surname;
            Id = id;
            Email = email;
            Adress = adress;
            Phone = phone;
        
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
    }
}
