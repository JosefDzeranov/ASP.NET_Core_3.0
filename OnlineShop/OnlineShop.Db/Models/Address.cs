using System;

namespace OnlineShop.Db.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
    }
}