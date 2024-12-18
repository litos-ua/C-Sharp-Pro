namespace CinemaPoster.VM.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DirectorName { get; set; }
        public string Genre { get; set; }
        public List<SessionViewModel> Sessions { get; set; }
    }
}
