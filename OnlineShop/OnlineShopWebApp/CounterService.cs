namespace OnlineShopWebApp
{
    public class CounterService
    {
        public RandomCounter Counter { get; }
        public CounterService(RandomCounter counter)
        {
            Counter = counter;
        }
    }
}
