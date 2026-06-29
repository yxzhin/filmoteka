using filmotekaAPI.DTOs;
using filmotekaAPI.DTOs.ReziserDTOs;
using filmotekaAPI.Interfaces.ReziserInterfaces;
using filmotekaAPI.Models;

namespace filmotekaAPI.Services
{
    public class ReziserService(
        IReziserRepository repository
    ) : IReziserService
    {
        private readonly IReziserRepository _repository = repository;

        public async Task<ReziserGetOneResponseDTO> GetById(int id)
        {
            Reziser? reziser = await _repository.GetById(id);

            return reziser is null
                ? ReziserGetOneResponseDTO.Error("reziser nije pronadjen")
                : ReziserGetOneResponseDTO.Ok(reziser, "reziser je uspesno pronadjen");
        }

        public async Task<ReziserGetManyResponseDTO> GetMany(int offset = 0, int limit = 10)
        {
            List<Reziser> reziseri = await _repository.GetMany(offset, limit);
            return ReziserGetManyResponseDTO.Ok(reziseri, "reziseri su uspesno izlistani");
        }

        public async Task<ReziserGetOneResponseDTO> GetByName(string name)
        {
            Reziser? reziser = await _repository.GetByName(name);

            return reziser is null
                ? ReziserGetOneResponseDTO.Error("reziser nije pronadjen")
                : ReziserGetOneResponseDTO.Ok(reziser, "reziser je uspesno pronadjen");
        }

        public async Task<BaseResponseDTO> Create(ReziserCreateInputDTO reziserCreateInputDTO)
        {
            Reziser? reziser = await _repository.GetByName(reziserCreateInputDTO.Name);

            if (reziser is not null)
            {
                return BaseResponseDTO.Error("reziser sa ovim nazivom vec postoji");
            }

            reziser = new()
            {
                Naziv = reziserCreateInputDTO.Name,
                Uzrast = reziserCreateInputDTO.Age,
            };
            await _repository.Save(reziser);

            return BaseResponseDTO.Ok("reziser je uspesno kreiran");
        }

        public async Task<BaseResponseDTO> Update(ReziserUpdateInputDTO reziserUpdateInputDTO)
        {
            Reziser? reziser = await _repository.GetById(reziserUpdateInputDTO.Id);

            if (reziser is null)
            {
                return BaseResponseDTO.Error("reziser nije pronadjen");
            }

            if (reziserUpdateInputDTO.NewName is not null)
            {
                reziser.Naziv = reziserUpdateInputDTO.NewName;
            }
            if (reziserUpdateInputDTO.NewAge is not null)
            {
                reziser.Uzrast = (int)reziserUpdateInputDTO.NewAge;
            }

            await _repository.Save(reziser);

            return BaseResponseDTO.Ok("reziser je uspesno promenjen");
        }

        public async Task<BaseResponseDTO> Delete(int id)
        {
            Reziser? reziser = await _repository.GetById(id);

            if (reziser is null)
            {
                return BaseResponseDTO.Error("reziser nije pronadjen");
            }

            await _repository.Delete(reziser);

            return BaseResponseDTO.Ok("reziser je uspesno obrisan");
        }
    }
}
