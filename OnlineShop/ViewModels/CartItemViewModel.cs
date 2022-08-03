using System;

namespace ViewModels
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }
        public ProductViewModel ProductViewModel { get; set; }
        public int Amount { get; set; }
        public CartViewModel Cart { get; set; }


        public decimal Cost
        {
            get { return ProductViewModel.Cost * Amount; }
        }
    }
}
