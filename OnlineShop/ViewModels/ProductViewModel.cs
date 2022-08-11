using System.ComponentModel.DataAnnotations;
using ViewModels.Attributes;

namespace ViewModels
{
    [DesriptionLengthName]
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите название продукта")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите стоимость продукта")]
        public decimal Cost { get; set; }
        [Required(ErrorMessage = "Введите описание продукта")]
        public string? Description { get; set; }
        public string? ImgPath { get; set; }
        public int AmountInDb { get; set; }
        public ProductViewModel(int id, string name, decimal cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }

        public ProductViewModel(int id, string name, decimal cost, string description)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
        }

        public ProductViewModel() { }

    }
}
