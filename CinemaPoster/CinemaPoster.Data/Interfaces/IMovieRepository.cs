using CinemaPoster.Domain.Models;

namespace CinemaPoster.Data.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task<Movie> AddAsync(Movie movie);
        Task<Movie?> EditAsync(Movie movie);
        Task DeleteAsync(int id);
    }
}

