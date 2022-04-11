namespace OnlineShopWebApp.Controllers
{
    public class ProductController
    {
        private readonly ProductRepository productRepository;

        public ProductController()
        {
            productRepository = new ProductRepository();
        }

        public string Index(int id)
        {
            var product = productRepository.TryGetByid(id);
            if (product == null)
                return $"Продукта с таким id = {id} не существует!";
            return $"{product}";
        }
    }
}
