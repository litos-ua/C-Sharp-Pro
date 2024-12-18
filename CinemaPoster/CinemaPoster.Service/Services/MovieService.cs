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
            return movies.Select(m => new MovieViewModel
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                DirectorName = m.Director?.Name,
                Genre = m.Genre.ToString(),
                Sessions = m.Sessions.Select(s => new SessionViewModel
                {
                    Id = s.Id,
                    StartTime = s.StartTime
                }).ToList()
            }).ToList();
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
    }
}

