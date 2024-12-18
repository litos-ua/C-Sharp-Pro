using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaPoster.Domain.Enums;

namespace CinemaPoster.VM.ViewModels
{
    public class AdminMovieViewModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DirectorId { get; set; }
        public List<SelectListItem> Directors { get; set; }
        public Genre Genre { get; set; }
        public List<SelectListItem> Genres { get; set; }
    }
}

