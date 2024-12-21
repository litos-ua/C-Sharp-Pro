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
            // Поиск фильмов
            var movies = await _movieService.SearchMoviesAsync(title, director, genre, description);

            return View(movies);
        }
    }
}
