using filmotekaAPI.DTOs;
using filmotekaAPI.DTOs.ZanrDTOs;
using filmotekaAPI.Interfaces.ZanrInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace filmotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZanrController(IZanrService zanrService)
        : ControllerBase
    {
        private readonly IZanrService _zanrService = zanrService;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ZanrGetOneResponseDTO zanrGetOneResponseDTO = await _zanrService
                .GetById(id);
            return new JsonResult(zanrGetOneResponseDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetMany([FromQuery] int offset, [FromQuery] int limit)
        {
            ZanrGetManyResponseDTO zanrGetManyResponseDTO = await _zanrService
                .GetMany(offset, limit);
            return new JsonResult(zanrGetManyResponseDTO);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            ZanrGetOneResponseDTO zanrGetOneResponseDTO = await _zanrService
                .GetByName(name);
            return new JsonResult(zanrGetOneResponseDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ZanrCreateInputDTO zanrCreateInputDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BaseResponseDTO zanrCreateResponseDTO = await _zanrService
                .Create(zanrCreateInputDTO.Name);
            return new JsonResult(zanrCreateResponseDTO);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ZanrUpdateInputDTO zanrUpdateInputDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BaseResponseDTO zanrUpdateResponseDTO = await _zanrService
                .Update(zanrUpdateInputDTO);
            return new JsonResult(zanrUpdateResponseDTO);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(ZanrDeleteInputDTO zanrDeleteInputDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BaseResponseDTO zanrDeleteResponseDTO = await _zanrService
                .Delete(zanrDeleteInputDTO.Id);
            return new JsonResult(zanrDeleteResponseDTO);
        }
    }
}
