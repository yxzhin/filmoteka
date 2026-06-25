using filmotekaAPI.DTOs;
using filmotekaAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace filmotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IKorisnikService korisnikService)
        : ControllerBase
    {
        private readonly IKorisnikService _korisnikService = korisnikService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterInputDTO registerInputDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BaseResponseDTO registerResponseDTO = await _korisnikService
                .Register(registerInputDTO.Ime, registerInputDTO.Prezime,
                registerInputDTO.Email, registerInputDTO.Password);
            return new JsonResult(registerResponseDTO);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginInputDTO loginInputDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LoginResponseDTO loginResponseDTO = await _korisnikService
                .Login(loginInputDTO.Email, loginInputDTO.Password);
            return new JsonResult(loginResponseDTO);
        }
    }
}
