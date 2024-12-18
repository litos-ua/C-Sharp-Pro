namespace CinemaPoster.Domain.Models
{
    public class Director
    {
        public int Id { get; set; } // Уникальный идентификатор
        public string Name { get; set; } = string.Empty; // Имя режиссера
        public ICollection<Movie> Movies { get; set; } = new List<Movie>(); // Список фильмов режиссера
    }
}
