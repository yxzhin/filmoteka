using filmotekaAPI.Data;
using filmotekaAPI.Interfaces.ZanrInterfaces;
using filmotekaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace filmotekaAPI.Repositories
{
    public class ZanrRepository(AppDbContext dbContext) : IZanrRepository
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<Zanr?> GetById(int id)
        {
            return await _dbContext.Zanrovi
                .Where(z => z.Id == id)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Zanr>> GetMany(int offset = 0, int limit = 10)
        {
            return await _dbContext.Zanrovi
                .OrderBy(z => z.Id)
                .Skip(offset)
                .Take(limit)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Zanr?> GetByName(string name)
        {
            return await _dbContext.Zanrovi
                .Where(z => z.Naziv == name)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task Save(Zanr entity)
        {
            if (await GetById(entity.Id) is not null)
            {
                _ = _dbContext.Zanrovi.Update(entity);
                _ = await _dbContext.SaveChangesAsync();
                return;
            }
            _ = _dbContext.Zanrovi.Add(entity);
            _ = await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Zanr entity)
        {
            if (await GetById(entity.Id) is null)
            {
                return;
            }

            _ = await _dbContext.Zanrovi
                .Where(z => z.Id == entity.Id)
                .ExecuteDeleteAsync();
        }
    }
}
