using CinemaPoster.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaPoster.UI.Controllers
{
    [Route("Search")]
    public class SearchController : Controller
    {
        private readonly IMovieService _movieService;

        public SearchController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string? title, string? director, string? genre, string? description)
        {
            // Выполняем поиск фильмов
            var movies = await _movieService.SearchMoviesAsync(title, director, genre, description);

            // Возвращаем результаты в то же представление
            return View(movies);
        }
    }
}
