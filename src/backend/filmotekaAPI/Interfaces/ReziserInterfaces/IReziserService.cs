using filmotekaAPI.DTOs;
using filmotekaAPI.DTOs.ReziserDTOs;

namespace filmotekaAPI.Interfaces.ReziserInterfaces
{
    public interface IReziserService
    {
        Task<ReziserGetOneResponseDTO> GetById(int id);
        Task<ReziserGetManyResponseDTO> GetMany(int offset = 0, int limit = 10);
        Task<ReziserGetOneResponseDTO> GetByName(string name);
        Task<BaseResponseDTO> Create(string name);
        Task<BaseResponseDTO> Update(ReziserUpdateInputDTO reziserUpdateInputDTO);
        Task<BaseResponseDTO> Delete(int id);
    }
}
