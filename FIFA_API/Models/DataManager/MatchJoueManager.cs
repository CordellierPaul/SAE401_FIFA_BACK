using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class MatchJoueManager : IDataRepository2clues<MatchJoue>
    {

        readonly FifaDbContext? fifaDbContext;

        public MatchJoueManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<MatchJoue>>> GetAllAsync()
        {
            return await fifaDbContext.MatchJoue.ToListAsync();
        }

        public async Task AddAsync(MatchJoue entity)
        {
            await fifaDbContext.MatchJoue.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(MatchJoue entity)
        {
            fifaDbContext.MatchJoue.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<MatchJoue>> GetByIdAsync(int uid, int tid)
        {
            return await fifaDbContext.MatchJoue.FirstOrDefaultAsync(u => u.JoueurId == uid && u.MatchId == tid);
        }


        public async Task UpdateAsync(MatchJoue entityToUpdate, MatchJoue entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.JoueurId = entity.JoueurId;
            entityToUpdate.MatchId = entity.MatchId;
            entityToUpdate.MatchJoueNbButs = entity.MatchJoueNbButs;
            entityToUpdate.MatchJoueNbMinutes = entity.MatchJoueNbMinutes;
            entityToUpdate.MatchJoueTitularisation = entity.MatchJoueTitularisation;
            entityToUpdate.MatchJoueSelection = entity.MatchJoueSelection;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
