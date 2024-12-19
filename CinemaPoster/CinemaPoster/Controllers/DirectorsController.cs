using CinemaPoster.Domain.Models;
using CinemaPoster.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("directors")]
public class DirectorsController : Controller
{
    private readonly IDirectorService _directorService;

    public DirectorsController(IDirectorService directorService)
    {
        _directorService = directorService ?? throw new ArgumentNullException(nameof(directorService));
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var directors = await _directorService.GetAllAsync();
        return View(directors); 
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(Director director)
    {
        if (ModelState.IsValid)
        {
            await _directorService.AddAsync(director);
            return RedirectToAction("Index");
        }
        return View(director);
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var director = await _directorService.GetByIdAsync(id);
        if (director == null)
        {
            return NotFound();
        }
        return View(director);
    }

    [HttpPost("edit/{id}")]
    public async Task<IActionResult> Edit(Director director)
    {
        if (ModelState.IsValid)
        {
            await _directorService.EditAsync(director);
            return RedirectToAction("Index");
        }
        return View(director);
    }

    // Удаление режиссёра
    [HttpPost("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _directorService.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}

