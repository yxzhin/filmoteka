using filmotekaAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace filmotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthcheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            BaseResponseDTO response = BaseResponseDTO.Ok("it works!! :tada:");
            return Ok(response);
        }
    }
}
