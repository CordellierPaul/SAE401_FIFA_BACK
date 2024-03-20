using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class VilleManager : IDataRepository<Ville>
    {
        private readonly FifaDbContext fifaDbContext;

        public VilleManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Ville>>> GetAllAsync()
        {
            return await fifaDbContext.Ville.ToListAsync();
        }

        public async Task AddAsync(Ville entity)
        {
            await fifaDbContext.Ville.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Ville entity)
        {
            fifaDbContext.Ville.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Ville>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Ville.FirstOrDefaultAsync(u => u.VilleId == id);

        }

        public async Task<ActionResult<Ville>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Ville.FirstOrDefaultAsync(u => u.VilleNom.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Ville entityToUpdate, Ville entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.VilleId = entity.VilleId;
            entityToUpdate.PaysId = entity.PaysId;
            entityToUpdate.VilleNom = entity.VilleNom;
            entityToUpdate.VilleCodePostal = entity.VilleCodePostal;
            entityToUpdate.JoueursVille = entity.JoueursVille;
            entityToUpdate.LiensAdresses = entity.LiensAdresses;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
