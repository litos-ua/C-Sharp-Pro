using CinemaPoster.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("admin")]
public class AdminController : Controller
{
    private readonly IMovieService _movieService;
    private readonly IDirectorService _directorService;
    private readonly ISessionService _sessionService;

    public AdminController(IMovieService movieService, IDirectorService directorService, ISessionService sessionService)
    {
        _movieService = movieService;
        _directorService = directorService;
        _sessionService = sessionService;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View("AdminPanel"); // Отображает базовую страницу с боковым меню
    }

    [HttpGet("movies")]
    public async Task<IActionResult> Movies()
    {
        var movies = await _movieService.GetMovieViewModelsAsync(); 
        //var movies = await _movieService.GetAllAsync();
        return View(movies); // Передаем List<MovieViewModel> в представление Movies.cshtml
    }

    [HttpGet("directors")]
    public async Task<IActionResult> Directors()
    {
        var directors = await _directorService.GetAllAsync();
        return View("Directors", directors); // Отображает Directors.cshtml
    }

    [HttpGet("sessions")]
    public async Task<IActionResult> Sessions()
    {
        var sessions = await _sessionService.GetAllAsync();
        return View("Sessions", sessions); // Отображает Sessions.cshtml
    }
}

