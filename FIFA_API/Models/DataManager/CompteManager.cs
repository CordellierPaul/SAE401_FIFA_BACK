using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NuGet.Protocol;

#nullable disable

namespace FIFA_API.Models.DataManager
{
    public class CompteManager : IDataRepository<Compte>
    {

        readonly FifaDbContext fifaDbContext;

        public CompteManager() { }
        public CompteManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Compte>>> GetAllAsync()
        {
            return await fifaDbContext.Compte.ToListAsync();
        }

        public async Task AddAsync(Compte entity)
        {
            await fifaDbContext.Compte.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Compte entity)
        {
            fifaDbContext.Compte.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Compte>> GetByIdAsync(int id)
        {
            Compte compte = await fifaDbContext.Compte.FirstOrDefaultAsync(u => u.CompteId == id);

            if (compte is null)
                return compte;

            EntityEntry<Compte> compteEntityEntry = fifaDbContext.Entry(compte);

            await compteEntityEntry.Reference(c => c.UtilisateurCompte).LoadAsync();

            return new ActionResult<Compte>(compteEntityEntry.Entity);
        }

        public async Task<ActionResult<Compte>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Compte.FirstOrDefaultAsync(u => u.CompteEmail.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Compte entityToUpdate, Compte entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.CompteId = entity.CompteId;
            entityToUpdate.CompteEmail = entity.CompteEmail;
            entityToUpdate.Comptelogin = entity.Comptelogin;
            entityToUpdate.CompteMdp = entity.CompteMdp;
            entityToUpdate.CompteDateConnexion = entity.CompteDateConnexion;
            entityToUpdate.CompteAnnonces = entity.CompteAnnonces;
            entityToUpdate.TypeCompte = entity.TypeCompte;
            entityToUpdate.UtilisateurCompte = entity.UtilisateurCompte;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
