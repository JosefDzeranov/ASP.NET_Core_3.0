//using OnlineShop.db.Models;
//using System.Collections.Generic;
//using System.Linq;

//namespace OnlineShop.Db
//{
//    public class CartsDbRepository : ICartRepository
//    {
//        private readonly DatabaseContext databaseContext;
//        private readonly ProductsDbRepository productsDbRepository;

//        public Dictionary<Product, int> CartItems { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

//        public CartsDbRepository(
//            DatabaseContext databaseContext, 
//            ProductsDbRepository productsDbRepository)
//        {
//            this.databaseContext = databaseContext;
//            this.productsDbRepository = productsDbRepository;
//        }
   
//        public Cart GetCartForUser(string userId)
//        {
//            var cart = databaseContext.Carts.FirstOrDefault(x => x.UserId == userId);
            
//            if (cart == null)
//            {
//                cart = new Cart()
//                {
//                    UserId = userId,
//                };
//                databaseContext.Carts.Add(cart);
//                databaseContext.SaveChanges();
//            }

//            return cart;
//        }

//        public void Add(int id)
//        {
//            var product = productsDbRepository.GetProductById(id);
//            Add(product);
//            //databaseContext.Carts.Add(product);
//            //databaseContext.SaveChanges();
//        }

//        public void Add(Product product /*, string userId*/)
//        {
//            string userId = "??????";
//            var cart = GetCartForUser(userId);
//            var cartItem = new CartItem()
//            {
//                Product = product,
//                Cart = cart,
//                Amount = 1
//            };
//            databaseContext.CartItems.Add(cartItem);
//            databaseContext.SaveChanges();
//        }

//        public void Remove(int id /*,string userId*/)
//        {
//            var product = productsDbRepository.GetProductById(id);
//            Remove(product);
//        }

//        public void Remove(Product product/*, *//*,string userId*/)
//        {
//            string userId = "??????";
//            var cart = GetCartForUser(userId);

//            var cartItem = cart.Items.Where(x => x.Product == product).First();

//            if (cartItem.Amount > 1)
//            {
//                cartItem.Amount -= 1;
//            }
//            else
//            {
//                databaseContext.CartItems.Remove(cartItem);
//            }

//            databaseContext.SaveChanges();
//        }

//        public void RemoveAll()
//        {
//            string userId = "??????";
//            var cart = GetCartForUser(userId);
//            cart.Items.Clear();
//            databaseContext.SaveChanges();
//        }

//        public Cart TryGetByUserId(string userId)
//        {
//            throw new System.NotImplementedException();
//        }

//        public void GetAllProduct()
//        {
//            throw new System.NotImplementedException();
//        }

//        //public Dictionary<Product, int> CartItems { get; set; } = new Dictionary<Product, int>();

//        //public decimal Cost => throw new System.NotImplementedException();

//        //public int Amount => throw new System.NotImplementedException();
//    }
//}
