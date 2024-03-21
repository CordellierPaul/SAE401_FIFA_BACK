using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class SousCategorieManager : IDataRepository2clues<SousCategorie>
    {

        readonly FifaDbContext? fifaDbContext;

        public SousCategorieManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<SousCategorie>>> GetAllAsync()
        {
            return await fifaDbContext.SousCategorie.ToListAsync();
        }

        public async Task AddAsync(SousCategorie entity)
        {
            await fifaDbContext.SousCategorie.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(SousCategorie entity)
        {
            fifaDbContext.SousCategorie.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<SousCategorie>> GetByIdAsync(int uid, int tid)
        {
            return await fifaDbContext.SousCategorie.FirstOrDefaultAsync(u => u.CategorieParentId == uid && u.CategorieEnfantId == tid);
        }


        public async Task UpdateAsync(SousCategorie entityToUpdate, SousCategorie entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.CategorieEnfantId = entity.CategorieEnfantId;
            entityToUpdate.CategorieParentId = entity.CategorieParentId;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
