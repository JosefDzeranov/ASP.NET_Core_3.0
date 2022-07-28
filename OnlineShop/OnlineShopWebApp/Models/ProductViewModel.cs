using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Не указано название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана цена")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Не указано описание")]
        public string Description { get; set; }

        public string imagePath { get; set; }
        
       

    }
}
