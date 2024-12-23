
using System.ComponentModel.DataAnnotations;

namespace InternetShopApp.Data.Entities
{
    public class Stock
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        public Product? Product { get; set; }
    }

}
