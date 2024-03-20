using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class LivraisonManager : IDataRepository<Livraison>
    {
        private readonly FifaDbContext fifaDbContext;

        public LivraisonManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Livraison>>> GetAllAsync()
        {
            return await fifaDbContext.Livraison.ToListAsync();
        }

        public async Task AddAsync(Livraison entity)
        {
            await fifaDbContext.Livraison.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Livraison entity)
        {
            fifaDbContext.Livraison.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Livraison>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Livraison.FirstOrDefaultAsync(u => u.LivraisonId == id);

        }

        public async Task<ActionResult<Livraison>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Livraison.FirstOrDefaultAsync(u => u.LivraisonType.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Livraison entityToUpdate, Livraison entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.LivraisonId = entity.LivraisonId;
            entityToUpdate.LivraisonType = entity.LivraisonType;
            entityToUpdate.LivraisonPrix = entity.LivraisonPrix;
            entityToUpdate.CommandesLivraison = entity.CommandesLivraison;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
