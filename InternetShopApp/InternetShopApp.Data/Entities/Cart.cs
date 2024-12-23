using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopApp.Data.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; } 

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 

        [Required]
        public bool IsActive { get; set; } = true; // Активна ли корзина (может быть завершена при оформлении заказа)

        public User? User { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>(); 
    }

}
