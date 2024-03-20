using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class VarianteProduitManager : IDataRepository<VarianteProduit>
    {
        private readonly FifaDbContext fifaDbContext;

        public VarianteProduitManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<VarianteProduit>>> GetAllAsync()
        {
            return await fifaDbContext.VarianteProduit.ToListAsync();
        }

        public async Task AddAsync(VarianteProduit entity)
        {
            await fifaDbContext.VarianteProduit.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(VarianteProduit entity)
        {
            fifaDbContext.VarianteProduit.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<VarianteProduit>> GetByIdAsync(int id)
        {
            return await fifaDbContext.VarianteProduit.FirstOrDefaultAsync(u => u.VarianteProduitId == id);

        }

        public async Task<ActionResult<VarianteProduit>> GetByStringAsync(string str)
        {
          throw new NotImplementedException();
        }

        public async Task UpdateAsync(VarianteProduit entityToUpdate, VarianteProduit entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.VarianteProduitId = entity.VarianteProduitId;
            entityToUpdate.ProduitId = entity.ProduitId;
            entityToUpdate.ColorisId = entity.ColorisId;
            entityToUpdate.VarianteProduitPrix = entity.VarianteProduitPrix;
            entityToUpdate.VarianteProduitPromo = entity.VarianteProduitPromo;
            entityToUpdate.LignesCommandesVariante = entity.LignesCommandesVariante;
            entityToUpdate.LienImages = entity.LienImages;
            entityToUpdate.StocksVariante = entity.StocksVariante;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
