using AutoMapper;
using Domains;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CartItem, CartItemViewModel> ().ReverseMap();
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
