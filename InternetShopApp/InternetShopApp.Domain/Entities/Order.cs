using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InternetShopApp.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool DeliveryRequirement { get; set; } = false;

        public bool ReceivedStatus { get; set; } = false;

        public string TypeOfPayment { get; set; } = "card";

        public string PaymentStatus { get; set; } = "not paid";

        public User? User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
