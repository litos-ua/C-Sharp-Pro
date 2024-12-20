using CinemaPoster.Domain.Models;

public interface IDirectorRepository
{
    Task<List<Director>> GetAllAsync();
    Task<Director?> GetByIdAsync(int id);
    Task<int?> GetDirectorIdByNameAsync(string name);
    Task<Director> AddAsync(Director director);
    Task<Director?> EditAsync(Director director);
    Task DeleteAsync(int id);
}


