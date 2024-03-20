using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class MatchManager : IDataRepositoryWithoutStr<Match>
    {
        private readonly FifaDbContext fifaDbContext;

        public MatchManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Match>>> GetAllAsync()
        {
            return await fifaDbContext.Match.ToListAsync();
        }

        public async Task AddAsync(Match entity)
        {
            await fifaDbContext.Match.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Match entity)
        {
            fifaDbContext.Match.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Match>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Match.FirstOrDefaultAsync(u => u.MatchId == id);

        }


        public async Task UpdateAsync(Match entityToUpdate, Match entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.MatchId = entity.MatchId;
            entityToUpdate.ClubDomicileId = entity.ClubDomicileId;
            entityToUpdate.ClubExterieurId = entity.ClubExterieurId;
            entityToUpdate.MatchDate = entity.MatchDate;
            entityToUpdate.MatchScoreDomicile = entity.MatchScoreDomicile;
            entityToUpdate.MatchScoreExterieur = entity.MatchScoreExterieur;
            entityToUpdate.Matches_joue = entity.Matches_joue;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
