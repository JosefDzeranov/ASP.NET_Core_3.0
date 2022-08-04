using AutoMapper;
using Domains;
using Entities;
using OnlineShop.DB;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.BL
{
    public class CartServicies : ICartServices
    {
        private readonly ICartBase _cartBase;
        private readonly IMapper _mapper;

        public CartServicies(ICartBase cartBase, IMapper mapper)
        {
            _cartBase = cartBase;
            _mapper = mapper;
        }

        public void Add(Product product, string userId)
        {
            _cartBase.Add(_mapper.Map<ProductEntity>(product), userId);
        }

        public List<Cart> AllCarts()
        {
            return _cartBase.AllCarts().Select(x => _mapper.Map<Cart>(x)).ToList();
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
    }
}
