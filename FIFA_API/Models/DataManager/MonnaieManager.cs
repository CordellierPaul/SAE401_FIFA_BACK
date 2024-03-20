using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class MonnaieManager : IDataRepository<Monnaie>
    {
        private readonly FifaDbContext fifaDbContext;

        public MonnaieManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Monnaie>>> GetAllAsync()
        {
            return await fifaDbContext.Monnaie.ToListAsync();
        }

        public async Task AddAsync(Monnaie entity)
        {
            await fifaDbContext.Monnaie.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Monnaie entity)
        {
            fifaDbContext.Monnaie.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Monnaie>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Monnaie.FirstOrDefaultAsync(u => u.MonnaieId == id);

        }

        public async Task<ActionResult<Monnaie>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Monnaie.FirstOrDefaultAsync(u => u.MonnaieNom.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Monnaie entityToUpdate, Monnaie entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.MonnaieId = entity.MonnaieId;
            entityToUpdate.MonnaieNom = entity.MonnaieNom;
            entityToUpdate.MonnaieSymbole = entity.MonnaieSymbole;
            entityToUpdate.UtilisateursMonnaie = entity.UtilisateursMonnaie;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
