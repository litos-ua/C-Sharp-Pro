using CinemaPoster.Domain.Models;


namespace CinemaPoster.Service.Interfaces
{
    public interface ISessionService
    {
        Task<List<Session>> GetAllAsync();
        Task<Session?> GetByIdAsync(int id);
        Task AddAsync(Session session);
        Task EditAsync(Session session);
        Task DeleteAsync(int id);
    }
}
