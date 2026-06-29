using filmotekaAPI.DTOs;
using filmotekaAPI.DTOs.ReziserDTOs;
using filmotekaAPI.Interfaces.ReziserInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace filmotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReziserController(IReziserService reziserService)
        : ControllerBase
    {
        private readonly IReziserService _reziserService = reziserService;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ReziserGetOneResponseDTO reziserGetOneResponseDTO = await _reziserService
                .GetById(id);
            return new JsonResult(reziserGetOneResponseDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetMany([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            ReziserGetManyResponseDTO reziserGetManyResponseDTO = await _reziserService
                .GetMany(offset, limit);
            return new JsonResult(reziserGetManyResponseDTO);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            ReziserGetOneResponseDTO reziserGetOneResponseDTO = await _reziserService
                .GetByName(name);
            return new JsonResult(reziserGetOneResponseDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReziserCreateInputDTO reziserCreateInputDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BaseResponseDTO reziserCreateResponseDTO = await _reziserService
                .Create(reziserCreateInputDTO);
            return new JsonResult(reziserCreateResponseDTO);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ReziserUpdateInputDTO reziserUpdateInputDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BaseResponseDTO reziserUpdateResponseDTO = await _reziserService
                .Update(reziserUpdateInputDTO);
            return new JsonResult(reziserUpdateResponseDTO);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(ReziserDeleteInputDTO reziserDeleteInputDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BaseResponseDTO reziserDeleteResponseDTO = await _reziserService
                .Delete(reziserDeleteInputDTO.Id);
            return new JsonResult(reziserDeleteResponseDTO);
        }
    }
}
