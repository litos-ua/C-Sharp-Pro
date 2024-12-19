using CinemaPoster.Data.Context;
using CinemaPoster.Data.Interfaces;
using CinemaPoster.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaPoster.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaDbContext _context;

        public MovieRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies
                .Include(m => m.Director)
                .Include(m => m.Sessions)
                .ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _context.Movies
                .Include(m => m.Director)
                .Include(m => m.Sessions)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Movie> AddAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie?> EditAsync(Movie movie)
        {
            var existingMovie = await _context.Movies.FindAsync(movie.Id);
            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.Director = movie.Director;
                existingMovie.Genre = movie.Genre;
                existingMovie.Description = movie.Description;

                await _context.SaveChangesAsync();
            }
            return existingMovie;
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
