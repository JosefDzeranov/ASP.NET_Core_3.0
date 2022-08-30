using AutoMapper;
using Domains;
using Entities;
using OnlineShop.Db;
using OnlineShop.DB;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.BL
{
    public class CartServicies : ICartServicies
    {
        private readonly ICartBase _cartBase;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _databaseContext;

        public CartServicies(ICartBase cartBase, IMapper mapper, DatabaseContext databaseContext)
        {
            _cartBase = cartBase;
            _mapper = mapper;
            _databaseContext = databaseContext;
        }

        public void Add(Product product, string userId)
        {
            var transaction = _databaseContext.Database.BeginTransaction();
            if (CheckForAvailability(product, userId))
            {
                _cartBase.Add(_mapper.Map<ProductEntity>(product), userId);
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }
        }

        public IEnumerable<Cart> AllCarts()
        {
            return _cartBase.AllCarts().Select(x => _mapper.Map<Cart>(x));
        }

        public void DecreaseAmount(int productId, string userId)
        {
            _cartBase.DecreaseAmount(productId, userId);
        }

        public void Delete(string userId)
        {
            _cartBase.Delete(userId);
        }

        public Cart TryGetByUserId(string userId)
        {
            return _mapper.Map<Cart>(_cartBase.TryGetByUserId(userId));
        }

        public Cart TryGetByUserName(string userName)
        {
            return _mapper.Map<Cart>(_cartBase.TryGetByUserName(userName));
        }

        public bool CheckForAvailability(Product product, string userId)
        {
            var existingCart = _cartBase.AllCarts().FirstOrDefault(x => x.UserId == userId);
            if (existingCart != null)
            {
                var CartItemsWithNecessaryProduct = existingCart.Items.Where(x => x.Product.Id == product.Id);
                var amountOfProductInCart = CartItemsWithNecessaryProduct.Select(x => x.Amount).Sum();
                if (product.AmountInDb > 0)
                {
                    return amountOfProductInCart < product.AmountInDb ? true : false;
                }
                else return false;

            }
            else
            {
                return product.AmountInDb == 0 ? false : true;
            }
        }
    }
}
