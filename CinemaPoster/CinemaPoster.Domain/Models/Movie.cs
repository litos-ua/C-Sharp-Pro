using CinemaPoster.Domain.Enums;

namespace CinemaPoster.Domain.Models
{
    public class Movie
    {
        public int Id { get; set; } 
        public string Title { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty; 
        public Genre Genre { get; set; } // Enum
        public int DirectorId { get; set; } // FK
        public Director Director { get; set; } = null!; // Техническое свойство
        public ICollection<Session>? Sessions { get; set; } = new List<Session>(); // Сеансы
    }
}

