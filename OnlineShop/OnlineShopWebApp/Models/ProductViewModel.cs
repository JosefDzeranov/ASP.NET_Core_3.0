using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set;}

        [Required]
        public string Name { get; set;}

        [Range(500,10000, ErrorMessage = "Cost should be between 500 and 10000 Rub")]
        [DataType(DataType.Currency, ErrorMessage ="Number")]
        public decimal Cost { get; set;}

        [Required]
        public string Description { get; set;}

        public string[] ImagesPaths { get; set; }

        public string ImagePath => ImagesPaths.Length == 0 ? "/image/Products/item1.png" : ImagesPaths[0];
    }
}
