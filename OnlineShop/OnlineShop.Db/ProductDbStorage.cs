using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Db
{
    public class ProductDbStorage : IProductStorage
    {
        private readonly DatabaseContext _databaseContext;

        public ProductDbStorage(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Product> GetAll()
        {
            return _databaseContext.Products.Include(p => p.Images).ToList();
        }

        public List<Product> GetAllAvailable()
        {
            return _databaseContext.Products.Where(p => p.Available == true).ToList();
        }

        public Product TryGetProduct(Guid id)
        {
            var product = _databaseContext.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public IEnumerable<Product> SearchByName(string name)
        {
            var products = _databaseContext.Products.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            return products;
        }
        public void Add(Product product)
        {
            _databaseContext.Products.Add(product);
            _databaseContext.SaveChanges();
        }

        public void Edit(Product product)
        {
            var editProduct = _databaseContext.Products.FirstOrDefault(p => p.Id == product.Id);

            if (editProduct == null)
            {
                return;
            }

            editProduct.Name = product.Name;
            editProduct.Cost = product.Cost;
            editProduct.Description = product.Description;
            editProduct.Available = product.Available;

            _databaseContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var product = _databaseContext.Products.FirstOrDefault(p => p.Id == id);

            var orderWithProduct = _databaseContext.Orders.Include(order => order.Items)
                                                 .ThenInclude(item => item.Product)
                                                 .FirstOrDefault(p => p.Id == product.Id);

            var basketItemWithProduct = _databaseContext.BasketItems.FirstOrDefault(bi => bi.Product.Id == product.Id);

            if (orderWithProduct != null || basketItemWithProduct != null)
            {
                product.Available = false;
            }
            else
            {
                _databaseContext.Products.Remove(product);
            }
            _databaseContext.SaveChanges();
        }
    }
}
