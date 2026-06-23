namespace filmoviCrud.Models
{
    public class Film
    {
        public int Id { get; set; }

        public required string Naziv { get; set; }
        public required int ZanrId { get; set; }
        public required Zanr Zanr { get; set; }
        public required ICollection<Reziser> Reziseri { get; set; }
        public required int GodinaIzdanja { get; set; }
    }
}
