using CinemaPoster.Data.Interfaces;
using CinemaPoster.Data.Context;
using CinemaPoster.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaPoster.Data.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly CinemaDbContext _context;

        public DirectorRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public List<Director> GetAll()
        {
            return _context.Directors
                           .Include(d => d.Movies) // фильмы режиссера
                           .ToList();
        }

        public Director GetById(int id)
        {
            return _context.Directors
                           .Include(d => d.Movies) // фильмы режиссера
                           .FirstOrDefault(d => d.Id == id);
        }

        public Director Add(Director director)
        {
            if (director != null)
            {
                _context.Directors.Add(director);
                _context.SaveChanges();
            }
            return director;
        }

        public Director Edit(Director director)
        {
            var existingDirector = _context.Directors.Find(director.Id);
            if (existingDirector != null)
            {
                existingDirector.Name = director.Name;

                _context.SaveChanges();
            }
            return existingDirector;
        }

        public void Delete(int id)
        {
            var director = _context.Directors.Find(id);
            if (director != null)
            {
                _context.Directors.Remove(director);
                _context.SaveChanges();
            }
        }
    }
}

