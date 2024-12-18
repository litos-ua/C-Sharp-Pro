using CinemaPoster.Domain.Models;
using CinemaPoster.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("movies")]
public class MoviesController : Controller
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
    }

    // Получить список фильмов
    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var movies = await _movieService.GetAllAsync();
        return View(movies); // Представление "Index"
    }

    // Полный список с подробной информацией
    [HttpGet("details")]
    public async Task<IActionResult> DetailsList()
    {
        var movies = await _movieService.GetMovieViewModelsAsync();
        return View(movies); // Представление "DetailsList"
    }


    [HttpGet("create")] // Форма для добавления фильма
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(Movie movie)
    {
        if (ModelState.IsValid)
        {
            await _movieService.AddAsync(movie);
            return RedirectToAction("Index");
        }
        return View(movie);
    }

    [HttpGet("edit/{id}")] // Форма для редактирования фильма
    public async Task<IActionResult> Edit(int id)
    {
        var movie = await _movieService.GetByIdAsync(id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);
    }

    [HttpPost("edit/{id}")]
    public async Task<IActionResult> Edit(Movie movie)
    {
        if (ModelState.IsValid)
        {
            await _movieService.EditAsync(movie);
            return RedirectToAction("Index");
        }
        return View(movie);
    }

    [HttpPost("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _movieService.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}






