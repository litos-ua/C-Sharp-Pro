using CinemaPoster.Data.Context;
using CinemaPoster.Domain.Models;
using Microsoft.EntityFrameworkCore;

public class SessionRepository : ISessionRepository
{
    private readonly CinemaDbContext _context;

    public SessionRepository(CinemaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Session>> GetAllAsync()
    {
        return await _context.Sessions
            .Include(s => s.Movie)
            .ToListAsync();
    }

    public async Task<Session?> GetByIdAsync(int id)
    {
        return await _context.Sessions
            .Include(s => s.Movie)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Session> AddAsync(Session session)
    {
        _context.Sessions.Add(session);
        await _context.SaveChangesAsync();
        return session;
    }

    public async Task<Session?> EditAsync(Session session)
    {
        var existingSession = await _context.Sessions.FindAsync(session.Id);
        if (existingSession != null)
        {
            existingSession.StartTime = session.StartTime;
            existingSession.Price = session.Price;
            existingSession.RoomName = session.RoomName;
            existingSession.MovieId = session.MovieId;

            await _context.SaveChangesAsync();
        }
        return existingSession;
    }

    public async Task DeleteAsync(int id)
    {
        var session = await _context.Sessions.FindAsync(id);
        if (session != null)
        {
            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
        }
    }
}

