using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class TailleManager : IDataRepository<Taille>
    {
        private readonly FifaDbContext fifaDbContext;

        public TailleManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Taille>>> GetAllAsync()
        {
            return await fifaDbContext.Taille.ToListAsync();
        }

        public async Task AddAsync(Taille entity)
        {
            await fifaDbContext.Taille.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Taille entity)
        {
            fifaDbContext.Taille.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Taille>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Taille.FirstOrDefaultAsync(u => u.TailleId == id);

        }

        public async Task<ActionResult<Taille>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Taille.FirstOrDefaultAsync(u => u.TailleLibelle.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Taille entityToUpdate, Taille entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.TailleId = entity.TailleId;
            entityToUpdate.TailleLibelle = entity.TailleLibelle;
            entityToUpdate.LignesCommandes = entity.LignesCommandes;
            entityToUpdate.StocksTaille = entity.StocksTaille;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
