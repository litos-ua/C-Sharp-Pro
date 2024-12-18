//using CinemaPoster.Domain.Models;
//using CinemaPoster.VM.ViewModels;

//namespace CinemaPoster.Service.Interfaces
//{
//    public interface IMovieService
//    {
//        public List<Movie> GetAll();
//        public List<MovieViewModel> GetMovieViewModels();
//        public Movie GetById(int id);

//        public Movie AddCategory(Movie category);
//        public Movie Edit(Movie category);
//        public void Delete(int id);
//    }
//}

using CinemaPoster.Domain.Models;
using CinemaPoster.VM.ViewModels;

namespace CinemaPoster.Service.Interfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllAsync();
        Task<List<MovieViewModel>> GetMovieViewModelsAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task<Movie> AddAsync(Movie movie);
        Task<Movie?> EditAsync(Movie movie);
        Task DeleteAsync(int id);
    }
}

