using CinemaPoster.Domain.Models;

namespace CinemaPoster.Service.Interfaces
{
    public interface IDirectorService
    {
        Task<List<Director>> GetAllAsync();
        Task<Director?> GetByIdAsync(int id);
        Task AddAsync(Director director);
        Task EditAsync(Director director);
        Task DeleteAsync(int id);
    }
}
