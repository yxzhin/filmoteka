namespace filmotekaAPI.Models
{
    public class Zanr
    {
        public int Id { get; set; }
        public required string Naziv { get; set; }
        public ICollection<Film> Filmovi { get; set; } = [];
    }
}
