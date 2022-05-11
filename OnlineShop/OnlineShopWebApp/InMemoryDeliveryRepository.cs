using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class InMemoryDeliveryRepository : IDeliveryRepository
    {
        List<DeliveryInformarion> deliveryInformarion = new List<DeliveryInformarion>();

        public List<DeliveryInformarion> GetAll()
        {
            return deliveryInformarion;
        }

        public DeliveryInformarion TryGetByName(string name)
        {
            return deliveryInformarion.FirstOrDefault(x => x.Name == name);
        }
        public void Add(DeliveryInformarion newDeliveryInformarion)
        {
            deliveryInformarion.Add(newDeliveryInformarion);
        }

        public void Delete(string name)
        {
            deliveryInformarion.RemoveAll(x => x.Name == name);
        }

    }
}
