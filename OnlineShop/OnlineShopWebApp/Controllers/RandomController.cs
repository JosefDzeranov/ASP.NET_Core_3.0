using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class RandomController
    {
        private readonly RandomCounter randomCounter;
        private readonly CounterService counterService;

        public RandomController(RandomCounter randomCounter, CounterService counterService)
        {
            this.randomCounter = randomCounter;
            this.counterService = counterService;
        }

        public string Index() 
        {
            return $"RandomCounter = {randomCounter.Value}, counterService = {counterService.Counter.Value}";
        }
    }
}
