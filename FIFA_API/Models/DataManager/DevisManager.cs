using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class DevisManager : IDataRepository<Devis>
    {

        private readonly FifaDbContext fifaDbContext;

        public DevisManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Devis>>> GetAllAsync()
        {
            return await fifaDbContext.Devis.ToListAsync();
        }

        public async Task AddAsync(Devis entity)
        {
            await fifaDbContext.Devis.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Devis entity)
        {
            fifaDbContext.Devis.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Devis>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Devis.FirstOrDefaultAsync(u => u.DevisId == id);

        }

        public async Task<ActionResult<Devis>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Devis.FirstOrDefaultAsync(u => u.Sujet.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Devis entityToUpdate, Devis entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.DevisId = entity.DevisId;
            entityToUpdate.UtilisateurId = entity.UtilisateurId;
            entityToUpdate.ProduitId = entity.ProduitId;
            entityToUpdate.Sujet = entity.Sujet;
            entityToUpdate.Message = entity.Message;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
