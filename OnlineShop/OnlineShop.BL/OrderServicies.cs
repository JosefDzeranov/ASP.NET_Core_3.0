using AutoMapper;
using Domains;
using Entities;
using OnlineShop.DB;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.BL
{
    public class OrderServicies : IOrderServicies
    {
        private readonly IOrderBase _orderBase;
        private readonly IMapper _mapper;

        public OrderServicies(IOrderBase productBase, IMapper mapper)
        {
            _orderBase = productBase;
            _mapper = mapper;
        }

        public void Add(Order order)
        {
            _orderBase.Add(_mapper.Map<OrderEntity>(order));
        }

        public List<Order> AllOrders()
        {
            return _orderBase.AllOrders().Select(x => _mapper.Map<Order>(x)).ToList();
        }

        public void UpdateOrderStatus(int orderId, OrderStatus status)
        {
            _orderBase.UpdateOrderStatus(orderId, _mapper.Map<OrderStatusEntity>(status));
        }
    }
}
