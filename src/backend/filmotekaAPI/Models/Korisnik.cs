namespace filmotekaAPI.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public required string Ime { get; set; }
        public required string Prezime { get; set; }
        public string PunoIme => $"{Ime} {Prezime}";
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required Uloga Uloga { get; set; }
    }

    public enum Uloga
    {
        user,
        admin,
    }
}
