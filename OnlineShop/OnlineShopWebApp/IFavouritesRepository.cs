﻿using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public interface IFavouritesRepository
    {
        List<Product> GetFavourites();
        void Add(Product product);
        void Clear();
        void Delete(Product product);
    }
}
