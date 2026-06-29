using filmotekaAPI.DTOs;
using filmotekaAPI.DTOs.ZanrDTOs;

namespace filmotekaAPI.Interfaces.ZanrInterfaces
{
    public interface IZanrService
    {
        Task<ZanrGetOneResponseDTO> GetById(int id);
        Task<ZanrGetManyResponseDTO> GetMany(int offset = 0, int limit = 10);
        Task<ZanrGetOneResponseDTO> GetByName(string name);
        Task<BaseResponseDTO> Create(ZanrCreateInputDTO zanrCreateInputDTO);
        Task<BaseResponseDTO> Update(ZanrUpdateInputDTO zanrUpdateInputDTO);
        Task<BaseResponseDTO> Delete(int id);
    }
}
