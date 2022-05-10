using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        [Required(ErrorMessage = "Please enter Firstname.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Firstname should have length between 2 and 20 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter SecondName.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Secondname should have length between 2 and 20 characters.")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Please enter Phone Number.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Phone Number should have only digits.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter E-mail.")]
        [EmailAddress(ErrorMessage = "Please enter vald E-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Address: Street and House Number.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Address should have length between 2 and 20 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter City.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "City should have length between 2 and 20 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter Country.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Country should have length between 2 and 20 characters.")]
        public string Country { get; set; }

        public Guid Id { get; set; }
        public List<CartItem> Items { get; set; }

        public OrderStatus Status { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
            Status = OrderStatus.Created;
            CreatedDateTime = DateTime.Now;
        }

        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }
    }
}
