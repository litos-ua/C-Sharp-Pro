using CinemaPoster.VM.ViewModels;
using CinemaPoster.Data.Context;
using CinemaPoster.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaPoster.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly CinemaDbContext _context;
        public AdminController(CinemaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public IActionResult Edit(int? id)
        {
            var directors = _context.Directors.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();

            var genres = Enum.GetValues(typeof(Genre)).Cast<Genre>().Select(g => new SelectListItem
            {
                Value = g.ToString(),
                Text = g.ToString()
            }).ToList();

            if (id == null)
            {
                return View(new AdminMovieViewModel
                {
                    Directors = directors,
                    Genres = genres
                });
            }

            var movie = _context.Movies.Find(id);
            if (movie == null) return NotFound();

            return View(new AdminMovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                DirectorId = movie.DirectorId,
                Genre = movie.Genre,
                Directors = directors,
                Genres = genres
            });
        }
    }
}
