using CinemaPoster.Domain.Enums;
using CinemaPoster.Domain.Models;
using CinemaPoster.Service.Interfaces;
using CinemaPoster.VM.ViewModels;
using Microsoft.AspNetCore.Mvc;

[Route("movies")]
public class MoviesController : Controller
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var movies = await _movieService.GetAllAsync();
        return View(movies); 
    }

    // Полный список с подробной информацией
    [HttpGet("details")]
    public async Task<IActionResult> DetailsList()
    {
        var movies = await _movieService.GetMovieViewModelsAsync();
        return View(movies); 
    }

    [HttpGet("details/{id}")]
    public async Task<IActionResult> GetMovieDetails(int id)
    {
        var movie = await _movieService.GetByIdAsync(id);
        if (movie == null)
        {
            return NotFound();
        }

        return PartialView("_MovieDetails", movie); 
    }



    [HttpGet("create")] 
    public IActionResult Create()
    {
        var model = new MovieViewModel(); 
        return View("~/Views/Admin/Movies/Create.cshtml", model);
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

    //[HttpGet("edit/{id}")]
    //public async Task<IActionResult> Edit(int id)
    //{
    //    var movie = await _movieService.GetByIdAsync(id);
    //    if (movie == null)
    //    {
    //        return NotFound();
    //    }

    //    return View("~/Views/Admin/Movies/Edit.cshtml", movie);
    //}



    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var movieViewModel = await _movieService.GetByIdAsync(id); // Получаем ViewModel
        if (movieViewModel == null)
        {
            return NotFound();
        }

        if (!Enum.TryParse<Genre>(movieViewModel.Genre, true, out var genre))
        {
            return BadRequest("Invalid genre value.");
        }

        // Маппим ViewModel в Model
        var movie = new Movie
        {
            Id = movieViewModel.Id,
            Title = movieViewModel.Title,
            Description = movieViewModel.Description,
            Genre = genre, 
            Director = new Director { Name = movieViewModel.DirectorName }
        };

        return View("~/Views/Admin/Movies/Edit.cshtml", movie);
    }




    [HttpPost("edit/{id}")]
    public async Task<IActionResult> Edit(Movie movie)
    {
        if (ModelState.IsValid)
        {
            await _movieService.EditAsync(movie);
            return RedirectToAction("Index");
        }
        return View("~/Views/Admin/Movies/Edit.cshtml", movie);
    }

    [HttpPost("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _movieService.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}






