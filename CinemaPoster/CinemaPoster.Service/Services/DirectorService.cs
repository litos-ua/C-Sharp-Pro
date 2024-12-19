using CinemaPoster.Domain.Models;
using CinemaPoster.Service.Interfaces;

namespace CinemaPoster.Service.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public async Task<List<Director>> GetAllAsync()
        {
            return await _directorRepository.GetAllAsync();
        }

        public async Task<Director?> GetByIdAsync(int id)
        {
            return await _directorRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Director director)
        {
            await _directorRepository.AddAsync(director);
        }

        public async Task EditAsync(Director director)
        {
            await _directorRepository.EditAsync(director);
        }

        public async Task DeleteAsync(int id)
        {
            await _directorRepository.DeleteAsync(id);
        }
    }
}
