using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FIFA_API.Models.DataManager
{
    public class VarianteProduitManager : IDataRepositoryWithoutStr<VarianteProduit>
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
            var produit = await fifaDbContext.VarianteProduit.FirstOrDefaultAsync(u => u.VarianteProduitId == id);

            if (produit is null)
                return null;

            EntityEntry<VarianteProduit> varianteProduitEntityEntry = fifaDbContext.Entry(produit);

            await varianteProduitEntityEntry
                .Collection(vp => vp.LienImages)
                .Query()
                .Include(i => i.ImageNavigation)
                .LoadAsync();

            return varianteProduitEntityEntry.Entity;
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
