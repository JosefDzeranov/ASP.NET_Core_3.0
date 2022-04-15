using System;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class DeliveryStorage : IDeliveryStorage
    {
        public Delivery GetDeliveryData()
        {
            var delivery = new Delivery()
            {
                Id = Guid.NewGuid(),
                UserId = Constants.UserId,
                Address = new Address()
                {
                    ZipCode = "123456",
                    Country = "Russia",
                    City = "Moscow",
                    Street = "Ordynka",
                    House = "5",
                    Apartment = "25"
                },
                PhoneNumber = "+71112345678",
                Email = "abc@efg.com"
            };

            return delivery;
        }
    }
}
