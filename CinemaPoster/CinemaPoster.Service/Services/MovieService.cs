using CinemaPoster.Data.Interfaces;
using CinemaPoster.Domain.Models;
using CinemaPoster.Service.Interfaces;
using CinemaPoster.VM.ViewModels;

namespace CinemaPoster.Service.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<List<MovieViewModel>> GetMovieViewModelsAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            return movies.Select(MapToMovieViewModel).ToList();
        }

        public async Task<MovieViewModel?> GetByIdViewAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            return movie == null ? null : MapToMovieViewModel(movie);
        }


        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<Movie> AddAsync(Movie movie)
        {
            return await _movieRepository.AddAsync(movie);
        }

        public async Task<Movie?> EditAsync(Movie movie)
        {
            return await _movieRepository.EditAsync(movie);
        }

        public async Task DeleteAsync(int id)
        {
            await _movieRepository.DeleteAsync(id);
        }

        public async Task<List<MovieViewModel>> SearchMoviesAsync(string? title, string? director, string? genre, string? description)
        {
            var movies = await _movieRepository.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(title))
            {
                movies = movies.Where(m => m.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(director))
            {
                movies = movies.Where(m => m.Director?.Name.Contains(director, StringComparison.OrdinalIgnoreCase) == true).ToList();
            }
            if (!string.IsNullOrWhiteSpace(genre))
            {
                movies = movies.Where(m => m.Genre.ToString().Contains(genre, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(description))
            {
                movies = movies.Where(m => m.Description.Contains(description, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return movies.Select(MapToMovieViewModel).ToList();
        }

        // Преобразует Movie в MovieViewModel.
        private static MovieViewModel MapToMovieViewModel(Movie movie)
        {
            return new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                DirectorName = movie.Director?.Name ?? "Unknown",
                Genre = movie.Genre.ToString(),
                Sessions = movie.Sessions.Select(s => new SessionViewModel
                {
                    Id = s.Id,
                    StartTime = s.StartTime
                }).ToList()
            };
        }
    }
}


