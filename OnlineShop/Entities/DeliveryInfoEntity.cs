using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class DeliveryInfoEntity
    {
        public int Id { get; set; }
        public string AdressToDelivery { get; set; }
        public string NameOfClient { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
