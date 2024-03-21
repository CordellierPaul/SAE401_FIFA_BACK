using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class ProduitSimilaireManager : IDataRepository2clues<ProduitSimilaire>
    {

        readonly FifaDbContext? fifaDbContext;

        public ProduitSimilaireManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<ProduitSimilaire>>> GetAllAsync()
        {
            return await fifaDbContext.ProduitSimilaire.ToListAsync();
        }

        public async Task AddAsync(ProduitSimilaire entity)
        {
            await fifaDbContext.ProduitSimilaire.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProduitSimilaire entity)
        {
            fifaDbContext.ProduitSimilaire.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<ProduitSimilaire>> GetByIdAsync(int uid, int tid)
        {
            return await fifaDbContext.ProduitSimilaire.FirstOrDefaultAsync(u => u.ProduitUnId == uid && u.ProduitDeuxId == tid);
        }


        public async Task UpdateAsync(ProduitSimilaire entityToUpdate, ProduitSimilaire entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.ProduitUnId = entity.ProduitUnId;
            entityToUpdate.ProduitDeuxId = entity.ProduitDeuxId;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
