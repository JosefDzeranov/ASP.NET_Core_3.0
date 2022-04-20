using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class ComparisonInMemoryRepository : IComparisonRepository
    {
        private List<Compare> compares = new List<Compare>();

        public void Add(Product product, string userId)
        {
            var existingCompare = TryGetByUserId(userId);
            if (existingCompare == null)
            {
                var newFavorite = new Compare();
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Products = new List<Product>()
                    {
                        product
                    }
                };
                compares.Add(newFavorite);
            }
            else
            {
                var existingProduct = existingCompare.Products.FirstOrDefault(x => x.Id == product.Id);

                if (existingProduct == null)
                {
                    existingCompare.Products.Add(product);
                }
            }

            private object TryGetByUserId(string userId)
            {
                throw new NotImplementedException();
            }
        }
    }
