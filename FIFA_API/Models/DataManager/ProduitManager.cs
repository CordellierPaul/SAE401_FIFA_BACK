using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FIFA_API.Models.DataManager
{
    public class ProduitManager : IDataRepository<Produit>
    {
        private readonly FifaDbContext fifaDbContext;

        public ProduitManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Produit>>> GetAllAsync()
        {
            return await fifaDbContext.Produit.ToListAsync();
        }

        public async Task AddAsync(Produit entity)
        {
            await fifaDbContext.Produit.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Produit entity)
        {
            fifaDbContext.Produit.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Produit?>> GetByIdAsync(int id)
        {
            Produit? produit = await fifaDbContext.Produit.FirstOrDefaultAsync(u => u.ProduitId == id);

            if (produit is null)
                return produit;

            EntityEntry<Produit> produitEntityEntry = fifaDbContext.Entry(produit);

            produitEntityEntry.Reference(p => p.PaysProduit).Load();
            produitEntityEntry.Reference(p => p.CategorieNavigation).Load();

            produitEntityEntry.Collection(p => p.ProduitSimilaireLienUn).Load();
            produitEntityEntry.Collection(p => p.ProduitSimilaireLienDeux).Load();
            produitEntityEntry.Collection(p => p.VariantesProduit).Load();
            produitEntityEntry.Collection(p => p.LienCaracteristiques).Load();
            produitEntityEntry.Collection(p => p.DevisProduit).Load();

            return produit;
        }

        public async Task<ActionResult<Produit?>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Produit.FirstOrDefaultAsync(u => u.ProduitNom.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Produit entityToUpdate, Produit entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.ProduitId = entity.ProduitId;
            entityToUpdate.GenreId = entity.GenreId;
            entityToUpdate.CategorieId = entity.CategorieId;
            entityToUpdate.ProduitNom = entity.ProduitNom;
            entityToUpdate.ProduitDescription = entity.ProduitDescription;
            entityToUpdate.CompetitionId = entity.CompetitionId;
            entityToUpdate.PaysId = entity.PaysId;
            entityToUpdate.ProduitSimilaireLienDeux = entity.ProduitSimilaireLienDeux;
            entityToUpdate.ProduitSimilaireLienUn = entity.ProduitSimilaireLienUn;
            entityToUpdate.DevisProduit = entity.DevisProduit;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
