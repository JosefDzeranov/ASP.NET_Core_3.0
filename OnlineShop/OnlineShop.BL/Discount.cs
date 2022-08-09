namespace OnlineShop.BL
{
    public class Discount
    {
        public Discount(decimal val)
        {
            _value = val;
        }
        private decimal _value = 0;
        public decimal Value { get { return _value; } }
        public decimal GetDiscountedPrice(decimal sum)
        {
            return sum - sum * _value;
        }
    }
}
