using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    interface IDeliveryRepository
    {
        List<DeliveryInformarion> GetAll();
        DeliveryInformarion TryGetByName(string name);
        void Add(DeliveryInformarion newDeliveryInformarion); 
        void Delete(string name);
    }
}
