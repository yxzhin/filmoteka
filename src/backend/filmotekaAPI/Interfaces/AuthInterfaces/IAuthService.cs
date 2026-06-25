using filmotekaAPI.Models;

namespace filmotekaAPI.Interfaces.AuthInterfaces
{
    public interface IAuthService
    {
        string GenerateToken(Korisnik korisnik);
    }
}
