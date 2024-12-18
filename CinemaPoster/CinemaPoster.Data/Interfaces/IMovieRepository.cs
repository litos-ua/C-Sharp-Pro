//using CinemaPoster.Domain.Models;

//namespace CinemaPoster.Data.Interfaces
//{
//    public interface IMovieRepository
//    {
//        List<Movie> GetAll();
//        Movie GetById(int id);
//        Movie AddCategory(Movie category);
//        public Movie Edit(Movie category);
//        void Delete(int id);

//    }
//}

using CinemaPoster.Domain.Models;

namespace CinemaPoster.Data.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task<Movie> AddAsync(Movie movie);
        Task<Movie?> EditAsync(Movie movie);
        Task DeleteAsync(int id);
    }
}

