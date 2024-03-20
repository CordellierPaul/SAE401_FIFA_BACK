using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class PosteManager : IDataRepository<Poste>
    {
        private readonly FifaDbContext fifaDbContext;

        public PosteManager(FifaDbContext context)
        { 
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Poste>>> GetAllAsync()
        {
            return await fifaDbContext.Poste.ToListAsync();
        }

        public async Task AddAsync(Poste entity)
        {
            await fifaDbContext.Poste.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Poste entity)
        {
            fifaDbContext.Poste.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Poste>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Poste.FirstOrDefaultAsync(u => u.PosteId == id);

        }

        public async Task<ActionResult<Poste>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Poste.FirstOrDefaultAsync(u => u.PosteLibelle.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Poste entityToUpdate, Poste entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.PosteId = entity.PosteId;
            entityToUpdate.PosteLibelle = entity.PosteLibelle;
            entityToUpdate.JoueursPoste = entity.JoueursPoste;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
