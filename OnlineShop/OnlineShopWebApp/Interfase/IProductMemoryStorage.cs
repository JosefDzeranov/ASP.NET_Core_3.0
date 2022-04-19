﻿using System.Collections.Generic;
using OnlineDesignBureauWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IProductMemoryStorage
    {
        List<Product> Products { get; set; }
        string WriteToStorage();
        void ReadToStorage();
        Product FindProduct(int productId, List<Product> products);
        string ReadDataProducts();
    }
}
