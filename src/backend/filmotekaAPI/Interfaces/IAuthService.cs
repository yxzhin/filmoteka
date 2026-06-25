using filmotekaAPI.Models;

namespace filmotekaAPI.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(Korisnik korisnik);
    }
}
