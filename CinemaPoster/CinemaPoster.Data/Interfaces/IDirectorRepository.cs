using CinemaPoster.Domain.Models;

public interface IDirectorRepository
{
    Task<List<Director>> GetAllAsync();
    Task<Director?> GetByIdAsync(int id);
    Task<Director> AddAsync(Director director);
    Task<Director?> EditAsync(Director director);
    Task DeleteAsync(int id);
}


