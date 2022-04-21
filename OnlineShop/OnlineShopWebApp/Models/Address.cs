namespace OnlineShopWebApp.Models
{
    public class Address
    {
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }

        public Address() { } // Empty ctor for XML serializing.
    }
}