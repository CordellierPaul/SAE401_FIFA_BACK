using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class FilmManager : IDataRepositoryWithoutStr<Film>
    {
        private readonly FifaDbContext fifaDbContext;

        public FilmManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Film>>> GetAllAsync()
        {
            return await fifaDbContext.Film.ToListAsync();
        }

        public async Task AddAsync(Film entity)
        {
            await fifaDbContext.Film.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Film entity)
        {
            fifaDbContext.Film.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Film>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Film.FirstOrDefaultAsync(u => u.FilmId == id);

        }


        public async Task UpdateAsync(Film entityToUpdate, Film entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.FilmId = entity.FilmId;
            entityToUpdate.MediaId = entity.MediaId;
            await fifaDbContext.SaveChangesAsync();
        }

    }
}
