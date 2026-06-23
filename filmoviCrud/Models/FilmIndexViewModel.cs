namespace filmoviCrud.Models
{
    public class FilmIndexViewModel
    {
        public IEnumerable<Film> Filmovi { get; set; } = [];

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }

}
