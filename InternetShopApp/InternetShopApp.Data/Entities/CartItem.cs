
using System.ComponentModel.DataAnnotations;


namespace InternetShopApp.Data.Entities
{
    public class CartItem
    {
        public int Id { get; set; }

        [Required]
        public int CartId { get; set; } 

        [Required]
        public int ProductId { get; set; } 

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; } 

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } // Дата добавления в корзину

        public Cart? Cart { get; set; } 
        public Product? Product { get; set; } 
    }
}
