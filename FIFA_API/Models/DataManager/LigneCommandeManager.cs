using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class LigneCommandeManager : IDataRepository<LigneCommande>
    {
        private readonly FifaDbContext fifaDbContext;

        public LigneCommandeManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<LigneCommande>>> GetAllAsync()
        {
            return await fifaDbContext.LigneCommande.ToListAsync();
        }

        public async Task AddAsync(LigneCommande entity)
        {
            await fifaDbContext.LigneCommande.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(LigneCommande entity)
        {
            fifaDbContext.LigneCommande.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<LigneCommande>> GetByIdAsync(int id)
        {
            return await fifaDbContext.LigneCommande.FirstOrDefaultAsync(u => u.LigneCommandeId == id);

        }

        public async Task<ActionResult<LigneCommande>> GetByStringAsync(string str)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(LigneCommande entityToUpdate, LigneCommande entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.LigneCommandeId = entity.LigneCommandeId;
            entityToUpdate.CommandeId = entity.CommandeId;
            entityToUpdate.NumeroLigneCommande = entity.NumeroLigneCommande;
            entityToUpdate.VarianteProduitId = entity.VarianteProduitId;
            entityToUpdate.TailleId = entity.TailleId;
            entityToUpdate.LigneCommandeQuantite = entity.LigneCommandeQuantite;
            entityToUpdate.LigneCommandePrix = entity.LigneCommandePrix;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
