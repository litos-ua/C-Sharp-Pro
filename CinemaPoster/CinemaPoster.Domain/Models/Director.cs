namespace CinemaPoster.Domain.Models
{
    public class Director
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty; 
        public ICollection<Movie> Movies { get; set; } = new List<Movie>(); // Фильмы режиссера
    }
}
