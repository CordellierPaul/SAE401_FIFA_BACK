using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class VoteManager : IDataRepository3clues<Vote>
    {
        readonly FifaDbContext? fifaDbContext;

        public VoteManager() { }
        public VoteManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Vote>>> GetAllAsync()
        {
            return await fifaDbContext.Vote.ToListAsync();
        }

        public async Task AddAsync(Vote entity)
        {
            await fifaDbContext.Vote.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Vote entity)
        {
            fifaDbContext.Vote.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Vote>> GetByIdAsync(int uid, int tid, int jid)
        {
            return await fifaDbContext.Vote.FirstOrDefaultAsync(u => u.UtilisateurId == uid && u.ThemeId == tid && u.JoueurId == jid);
        }


        public async Task UpdateAsync(Vote entityToUpdate, Vote entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.UtilisateurId = entity.UtilisateurId;
            entityToUpdate.ThemeId = entity.ThemeId;
            entityToUpdate.JoueurId = entity.JoueurId;
            entityToUpdate.VoteNote = entity.VoteNote;
            await fifaDbContext.SaveChangesAsync();
        }

    }
}
