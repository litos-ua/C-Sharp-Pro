using CinemaPoster.Data.Context;
using CinemaPoster.Domain.Models;
using Microsoft.EntityFrameworkCore;

public class DirectorRepository : IDirectorRepository
{
    private readonly CinemaDbContext _context;

    public DirectorRepository(CinemaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Director>> GetAllAsync()
    {
        return await _context.Directors
            .Include(d => d.Movies)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Director?> GetByIdAsync(int id)
    {
        return await _context.Directors
            .Include(d => d.Movies)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<int?> GetDirectorIdByNameAsync(string name)
    {
        var director = await _context.Directors
            .FirstOrDefaultAsync(d => d.Name == name);
        return director?.Id;
    }

    public async Task<Director> AddAsync(Director director)
    {
        _context.Directors.Add(director);
        await _context.SaveChangesAsync();
        return director;
    }

    public async Task<Director?> EditAsync(Director director)
    {
        var existingDirector = await _context.Directors.FindAsync(director.Id);
        if (existingDirector != null)
        {
            existingDirector.Name = director.Name;
            await _context.SaveChangesAsync();
        }
        return existingDirector;
    }

    public async Task DeleteAsync(int id)
    {
        var director = await _context.Directors.FindAsync(id);
        if (director != null)
        {
            _context.Directors.Remove(director);
            await _context.SaveChangesAsync();
        }
    }
}


