namespace OnlineShopWebApp
{
    public class CounterService
    {
        public ICounter Counter { get; }
        public CounterService(ICounter counter)
        {
            Counter = counter;
        }
    }
}
