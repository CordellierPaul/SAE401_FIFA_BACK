using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class GenreManager : IDataRepository<Genre>
    {
        private readonly FifaDbContext fifaDbContext;

        public GenreManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Genre>>> GetAllAsync()
        {
            return await fifaDbContext.Genre.ToListAsync();
        }

        public async Task AddAsync(Genre entity)
        {
            await fifaDbContext.Genre.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Genre entity)
        {
            fifaDbContext.Genre.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Genre>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Genre.FirstOrDefaultAsync(u => u.GenreId == id);

        }

        public async Task<ActionResult<Genre>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Genre.FirstOrDefaultAsync(u => u.GenreNom.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Genre entityToUpdate, Genre entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.GenreId = entity.GenreId;
            entityToUpdate.GenreNom = entity.GenreNom;
            entityToUpdate.ProduitsGenre = entity.ProduitsGenre;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
