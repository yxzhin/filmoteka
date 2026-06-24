using filmotekaAPI.Data;
using filmotekaAPI.Interfaces;
using filmotekaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace filmotekaAPI.Repositories
{
    public class KorisnikRepository(AppDbContext dbContext) : IRepository<Korisnik>
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<Korisnik?> GetById(int id)
        {
            return await _dbContext.FindAsync<Korisnik>(id);
        }

        public async Task<List<Korisnik>> GetMany(int offset = 0, int limit = 10)
        {
            return await _dbContext.Korisnici
                .OrderBy(k => k.Id)
                .Skip(offset)
                .Take(limit)
                .AsNoTracking()
                .ToListAsync();
        }

        public async void Create(Korisnik entity)
        {
            if (await GetById(entity.Id) is null)
            {
                return;
            }
            _ = _dbContext.Korisnici.Add(entity);
            _ = await _dbContext.SaveChangesAsync();
        }

        public async void Update(Korisnik entity)
        {
            if (await GetById(entity.Id) is null)
            {
                return;
            }
            _ = _dbContext.Korisnici.Update(entity);
            _ = await _dbContext.SaveChangesAsync();
        }

        public async void Delete(Korisnik entity)
        {
            if (await GetById(entity.Id) is null)
            {
                return;
            }

            _ = await _dbContext.Korisnici.Where(k => k.Id == entity.Id)
                .ExecuteDeleteAsync();
        }
    }
}
