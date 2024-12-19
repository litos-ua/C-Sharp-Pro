using CinemaPoster.Domain.Models;

public interface ISessionRepository
{
    Task<List<Session>> GetAllAsync();
    Task<Session?> GetByIdAsync(int id);
    Task<Session> AddAsync(Session session);
    Task<Session?> EditAsync(Session session);
    Task DeleteAsync(int id);
}

