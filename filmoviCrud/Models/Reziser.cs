namespace filmoviCrud.Models
{
    public class Reziser
    {
        public int Id { get; set; }
        public required string Naziv { get; set; }
        public required int Uzrast { get; set; }
        public ICollection<Film> Filmovi { get; set; } = [];
    }
}
