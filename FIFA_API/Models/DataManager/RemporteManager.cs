using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class RemporteManager : IDataRepository3cluesChar<Remporte>
    {

        readonly FifaDbContext? fifaDbContext;

        public RemporteManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Remporte>>> GetAllAsync()
        {
            return await fifaDbContext.Remporte.ToListAsync();
        }

        public async Task AddAsync(Remporte entity)
        {
            await fifaDbContext.Remporte.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Remporte entity)
        {
            fifaDbContext.Remporte.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Remporte>> GetByIdAsync(int jid, int tid, char aid)
        {
            return await fifaDbContext.Remporte.FirstOrDefaultAsync(u => u.JoueurId == jid && u.TropheeId == tid && u.RemporteAnnee == aid);
        }


        public async Task UpdateAsync(Remporte entityToUpdate, Remporte entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.JoueurId = entity.JoueurId;
            entityToUpdate.TropheeId = entity.TropheeId;
            entityToUpdate.RemporteAnnee = entity.RemporteAnnee;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
