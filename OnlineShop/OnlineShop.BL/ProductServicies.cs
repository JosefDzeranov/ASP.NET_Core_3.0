using AutoMapper;
using Domains;
using Entities;
using OnlineShop.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.BL
{
    public class ProductServicies : IProductServicies
    {
        private readonly IProductBase _productBase;
        private readonly IMapper _mapper;

        public ProductServicies(IProductBase productBase, IMapper mapper)
        {
            _productBase = productBase;
            _mapper = mapper;
        }

        public void Add(Product product)
        {
            _productBase.Add(_mapper.Map<ProductEntity>(product));
        }

        public IEnumerable<Product> AllProducts()
        {
            return _productBase.AllProducts().Select(x => _mapper.Map<Product>(x));
        }

        public void Delete(int productId)
        {
            _productBase.Delete(productId);
        }

        public void Edit(Product product)
        {
            _productBase.Edit(_mapper.Map<ProductEntity>(product));
        }

        public Product TryGetById(int productId)
        {
            return _mapper.Map<Product>(_productBase.TryGetById(productId));
        }
    }
}
