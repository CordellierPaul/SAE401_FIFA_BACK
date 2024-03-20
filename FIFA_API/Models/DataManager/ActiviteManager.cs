using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class ActiviteManager : IDataRepository<Activite>
    {
        readonly FifaDbContext? fifaDbContext;

        public ActiviteManager() { }
        public ActiviteManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Activite>>> GetAllAsync()
        {
            return await fifaDbContext.Activite.ToListAsync();
        }

        public async Task AddAsync(Activite entity)
        {
            await fifaDbContext.Activite.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Activite entity)
        {
            fifaDbContext.Activite.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Activite?>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Activite.FirstOrDefaultAsync(u => u.ActiviteId == id);
        }

        public async Task<ActionResult<Activite?>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Activite.FirstOrDefaultAsync(u => u.ActiviteNom.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Activite entityToUpdate, Activite entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.ActiviteId = entity.ActiviteId;
            entityToUpdate.ActiviteNom = entity.ActiviteNom;
            entityToUpdate.UtilisateursActivite = entity.UtilisateursActivite;
            await fifaDbContext.SaveChangesAsync();
        }

    }
}
