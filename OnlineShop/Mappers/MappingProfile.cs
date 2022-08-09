using AutoMapper;
using Domains;
using Entities;
using System.Linq;
using ViewModels;

namespace Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CartItemViewModel , CartItem> ().ReverseMap();
            CreateMap<DeliveryInfo, DeliveryInfoModelView>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<Cart, CartViewModel>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusViewModel>().ReverseMap();

            CreateMap<CartItem, CartItemEntity>().ReverseMap();
            CreateMap<DeliveryInfo, DeliveryInfoEntity>().ReverseMap();
            CreateMap<Product, ProductEntity>().ReverseMap();
            CreateMap<Order, OrderEntity>().ReverseMap();
            CreateMap<Cart, CartEntity>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusEntity>().ReverseMap();






        }
    }
}
