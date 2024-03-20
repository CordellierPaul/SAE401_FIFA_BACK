using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class LangueManager : IDataRepository<Langue>
    {
        private readonly FifaDbContext fifaDbContext;

        public LangueManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Langue>>> GetAllAsync()
        {
            return await fifaDbContext.Langue.ToListAsync();
        }

        public async Task AddAsync(Langue entity)
        {
            await fifaDbContext.Langue.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Langue entity)
        {
            fifaDbContext.Langue.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Langue>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Langue.FirstOrDefaultAsync(u => u.LangueId == id);

        }

        public async Task<ActionResult<Langue>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Langue.FirstOrDefaultAsync(u => u.LangueNom.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Langue entityToUpdate, Langue entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.LangueId = entity.LangueId;
            entityToUpdate.LangueNom = entity.LangueNom;
            entityToUpdate.UtilisateursLangue = entity.UtilisateursLangue;
        }
    }
}
