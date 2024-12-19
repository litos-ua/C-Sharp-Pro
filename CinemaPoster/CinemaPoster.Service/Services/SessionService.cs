using CinemaPoster.Domain.Models;
using CinemaPoster.Service.Interfaces;


namespace CinemaPoster.Service.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<List<Session>> GetAllAsync()
        {
            return await _sessionRepository.GetAllAsync();
        }

        public async Task<Session?> GetByIdAsync(int id)
        {
            return await _sessionRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Session session)
        {
            await _sessionRepository.AddAsync(session);
        }

        public async Task EditAsync(Session session)
        {
            await _sessionRepository.EditAsync(session);
        }

        public async Task DeleteAsync(int id)
        {
            await _sessionRepository.DeleteAsync(id);
        }
    }
}
