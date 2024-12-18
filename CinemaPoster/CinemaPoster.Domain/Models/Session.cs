
//namespace CinemaPoster.Domain.Models
//{
//    public class Session
//    {
//        public int Id { get; set; } // Уникальный идентификатор
//        public DateTime StartTime { get; set; } // Время начала
//        public decimal Price { get; set; } // Цена за билет
//        public int MovieId { get; set; } // FK к фильму
//        public Movie Movie { get; set; } = null!; // Связь с фильмом
//    }
//}

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
        public RoomName RoomName { get; set; } = RoomName.Blue; // вид зала

        // Внешний ключ для Movie
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
    }
}
