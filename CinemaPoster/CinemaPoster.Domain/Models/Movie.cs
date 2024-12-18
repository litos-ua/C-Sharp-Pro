using CinemaPoster.Domain.Enums;

namespace CinemaPoster.Domain.Models
{
    public class Movie
    {
        //public int Id { get; set; } // Уникальный идентификатор
        //public string Title { get; set; } = string.Empty; // Название фильма
        //public string Director { get; set; } = string.Empty; // Режиссер (связь с таблицей Director, если потребуется)
        //public Genre Genre { get; set; } // Жанр (перечисление)
        //public string Description { get; set; } = string.Empty; // Краткое описание
        //public ICollection<Session> Sessions { get; set; } = new List<Session>(); // Сеансы фильма
        public int Id { get; set; } // Уникальный идентификатор
        public string Title { get; set; } = string.Empty; // Название фильма
        public string Description { get; set; } = string.Empty; // Описание фильма
        public Genre Genre { get; set; } // Жанр (перечисление)
        public int DirectorId { get; set; } // Внешний ключ к режиссёру
        public Director Director { get; set; } = null!; // Навигационное свойство (не null)
        public ICollection<Session> Sessions { get; set; } = new List<Session>(); // Сеансы фильма
    }
}

