using filmotekaAPI.Data;
using filmotekaAPI.Interfaces.ReziserInterfaces;
using filmotekaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace filmotekaAPI.Repositories
{
    public class ReziserRepository(AppDbContext dbContext) : IReziserRepository
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<Reziser?> GetById(int id)
        {
            return await _dbContext.Reziseri
                .Where(r => r.Id == id)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Reziser>> GetMany(int offset = 0, int limit = 10)
        {
            return await _dbContext.Reziseri
                .OrderBy(r => r.Id)
                .Skip(offset)
                .Take(limit)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Reziser?> GetByName(string name)
        {
            return await _dbContext.Reziseri
                .Where(r => r.Naziv == name)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task Save(Reziser entity)
        {
            if (await GetById(entity.Id) is not null)
            {
                _ = _dbContext.Reziseri.Update(entity);
                _ = await _dbContext.SaveChangesAsync();
                return;
            }
            _ = _dbContext.Reziseri.Add(entity);
            _ = await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Reziser entity)
        {
            if (await GetById(entity.Id) is null)
            {
                return;
            }

            _ = await _dbContext.Reziseri
                .Where(r => r.Id == entity.Id)
                .ExecuteDeleteAsync();
        }
    }
}
