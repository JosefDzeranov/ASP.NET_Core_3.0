namespace OnlineShopWebApp.Models.Users.Buyer
{
    public class AdditionalOptions
    {
        public decimal opcion1 = 1;

        public decimal TotalCost()
        {
            decimal summ = this.opcion1;
            return summ;
        }
    }
}
