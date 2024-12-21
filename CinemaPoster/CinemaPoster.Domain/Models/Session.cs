using System.ComponentModel.DataAnnotations;
using CinemaPoster.Domain.Enums;

namespace CinemaPoster.Domain.Models
{
    public class Session
    {
        public int Id { get; set; } 
        public DateTime StartTime { get; set; } 
        public decimal Price { get; set; } 

        [Required]
        public RoomName RoomName { get; set; } = RoomName.Blue; 

        public int MovieId { get; set; } // FK
        public Movie? Movie { get; set; } = null!;  // Техническое свойство
    }
}
