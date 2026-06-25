using filmotekaAPI.DTOs;
using filmotekaAPI.DTOs.ZanrDTOs;
using filmotekaAPI.Interfaces.ZanrInterfaces;
using filmotekaAPI.Models;

namespace filmotekaAPI.Services
{
    public class ZanrService(
        IZanrRepository repository
    ) : IZanrService
    {
        private readonly IZanrRepository _repository = repository;

        public async Task<ZanrGetOneResponseDTO> GetById(int id)
        {
            Zanr? zanr = await _repository.GetById(id);

            return zanr is null
                ? ZanrGetOneResponseDTO.Error("zanr nije pronadjen")
                : ZanrGetOneResponseDTO.Ok(zanr, "zanr je uspesno pronadjen");
        }

        public async Task<ZanrGetManyResponseDTO> GetMany(int offset = 0, int limit = 10)
        {
            List<Zanr> zanrovi = await _repository.GetMany(offset, limit);
            return ZanrGetManyResponseDTO.Ok(zanrovi, "zanrovi su uspesno izlistani");
        }

        public async Task<ZanrGetOneResponseDTO> GetByName(string name)
        {
            Zanr? zanr = await _repository.GetByName(name);

            return zanr is null
                ? ZanrGetOneResponseDTO.Error("zanr nije pronadjen")
                : ZanrGetOneResponseDTO.Ok(zanr, "zanr je uspesno pronadjen");
        }

        public async Task<BaseResponseDTO> Create(string name)
        {
            Zanr? zanr = await _repository.GetByName(name);

            if (zanr is not null)
            {
                return BaseResponseDTO.Error("zanr sa ovim nazivom vec postoji");
            }

            zanr = new() { Naziv = name };
            await _repository.Save(zanr);

            return BaseResponseDTO.Ok("zanr je uspesno kreiran");
        }

        public async Task<BaseResponseDTO> Update(int id, string newName)
        {
            Zanr? zanr = await _repository.GetById(id);

            if (zanr is null)
            {
                return BaseResponseDTO.Error("zanr nije pronadjen");
            }

            zanr.Naziv = newName;
            await _repository.Save(zanr);

            return BaseResponseDTO.Ok("zanr je uspesno promenjen");
        }

        public async Task<BaseResponseDTO> Delete(int id)
        {
            Zanr? zanr = await _repository.GetById(id);

            if (zanr is null)
            {
                return BaseResponseDTO.Error("zanr nije pronadjen");
            }

            await _repository.Delete(zanr);

            return BaseResponseDTO.Ok("zanr je uspesno obrisan");
        }
    }
}
