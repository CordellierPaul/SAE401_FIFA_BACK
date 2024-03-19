using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class ProduitManager : IDataRepository<Produit>
    {
        readonly FifaDbContext? fifaDbContext;

        public ProduitManager() { }
        public ProduitManager(FifaDbContext? context)
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


        public async Task<ActionResult<Produit>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Produit.FirstOrDefaultAsync(u => u.ProduitId == id);
        }

        public async Task<ActionResult<Produit>> GetByStringAsync(string str)
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
