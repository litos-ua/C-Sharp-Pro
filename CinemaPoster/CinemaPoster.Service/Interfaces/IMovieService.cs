using CinemaPoster.Domain.Models;
using CinemaPoster.VM.ViewModels;

namespace CinemaPoster.Service.Interfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllAsync();
        Task<List<MovieViewModel>> GetMovieViewModelsAsync();
        Task<MovieViewModel?> GetByIdAsync(int id);
        Task<Movie> AddAsync(Movie movie);
        Task<Movie?> EditAsync(Movie movie);
        Task DeleteAsync(int id);
        Task<List<MovieViewModel>> SearchMoviesAsync(string? title, string? director, string? genre, string? description);

    }
}

