using CinemaPoster.Domain.Models;

namespace CinemaPoster.Data.Interfaces
{
    public interface IDirectorRepository
    {
        List<Director> GetAll();
        Director GetById(int id);
        Director Add(Director director);
        Director Edit(Director director);
        void Delete(int id);
    }
}

