using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FIFA_API.Models.DataManager
{
    public class PaysManager : IPaysRepository
    {
        private readonly FifaDbContext fifaDbContext;

        public PaysManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Pays>>> GetAllAsync()
        {
            return await fifaDbContext.Pays.ToListAsync();
        }

        public async Task AddAsync(Pays entity)
        {
            await fifaDbContext.Pays.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pays entity)
        {
            fifaDbContext.Pays.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Pays>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Pays.FirstOrDefaultAsync(u => u.PaysId == id);

        }

        public async Task<ActionResult<Pays>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Pays.FirstOrDefaultAsync(u => u.PaysNom.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Pays entityToUpdate, Pays entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.PaysId = entity.PaysId;
            entityToUpdate.PaysNom = entity.PaysNom;
            entityToUpdate.ProduitsPays = entity.ProduitsPays;
            entityToUpdate.UtilisateursFavorisantPays = entity.UtilisateursFavorisantPays;
            entityToUpdate.UtilisateursNesPays = entity.UtilisateursNesPays;
            entityToUpdate.VillesPays = entity.VillesPays;
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Pays>>> GetPaysWhereProduitExists()
        {
            IEnumerable<Pays> lesPays = await fifaDbContext.Pays.ToListAsync();


            foreach (var pays in lesPays)
            {
                EntityEntry<Pays> paysEntityEntry = fifaDbContext.Entry(pays);

                await paysEntityEntry.Collection(x => x.ProduitsPays).LoadAsync();
            }

            lesPays = lesPays.Where(x => x.ProduitsPays.Count != 0);

            return lesPays.ToList();
        }
    }
}
