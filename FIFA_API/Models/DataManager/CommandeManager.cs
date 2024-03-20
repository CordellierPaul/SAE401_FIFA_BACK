using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class CommandeManager : IDataRepositoryWithoutStr<Commande>
    {
        private readonly FifaDbContext fifaDbContext;

        public CommandeManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Commande>>> GetAllAsync()
        {
            return await fifaDbContext.Commande.ToListAsync();
        }

        public async Task AddAsync(Commande entity)
        {
            await fifaDbContext.Commande.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Commande entity)
        {
            fifaDbContext.Commande.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Commande?>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Commande.FirstOrDefaultAsync(u => u.CommandeId == id);

        }

        public async Task UpdateAsync(Commande entityToUpdate, Commande entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.CommandeId = entity.CommandeId;
            entityToUpdate.UtilisateurId = entity.UtilisateurId;
            entityToUpdate.AdresseId = entity.AdresseId;
            entityToUpdate.LivraisonId = entity.LivraisonId;
            entityToUpdate.CommandePrix = entity.CommandePrix;
            entityToUpdate.CommandeDateCommande = entity.CommandeDateCommande;
            entityToUpdate.CommandeEtatCommande = entity.CommandeEtatCommande;
            entityToUpdate.CommandeDomicile = entity.CommandeDomicile;
            entityToUpdate.CommandeDateLivraison = entity.CommandeDateLivraison;
            entityToUpdate.LignesCommandes = entity.LignesCommandes;
            entityToUpdate.ReglementsCommande = entity.ReglementsCommande;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
