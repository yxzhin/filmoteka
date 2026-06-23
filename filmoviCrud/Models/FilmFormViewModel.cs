namespace filmoviCrud.Models
{
    public class FilmFormViewModel
    {
        public int Id { get; set; }
        public required string Naziv { get; set; }
        public int ZanrId { get; set; }
        public int GodinaIzdanja { get; set; }

        public List<int> ReziserIds { get; set; } = [];
    }
}
