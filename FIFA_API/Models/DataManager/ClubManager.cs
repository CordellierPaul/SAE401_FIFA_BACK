using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class ClubManager : IDataRepository<Club>
    {
        private readonly FifaDbContext fifaDbContext;

        public ClubManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Club>>> GetAllAsync()
        {
            return await fifaDbContext.Club.ToListAsync();
        }

        public async Task AddAsync(Club entity)
        {
            await fifaDbContext.Club.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Club entity)
        {
            fifaDbContext.Club.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Club?>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Club.FirstOrDefaultAsync(u => u.ClubId == id);

        }

        public async Task<ActionResult<Club?>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Club.FirstOrDefaultAsync(u => u.ClubNom.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Club entityToUpdate, Club entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.ClubId = entity.ClubId;
            entityToUpdate.ClubNom = entity.ClubNom;
            entityToUpdate.ClubInitiales = entity.ClubInitiales;
            entityToUpdate.MatchesDomicile = entity.MatchesDomicile;
            entityToUpdate.MatchesExterieur = entity.MatchesExterieur;
            entityToUpdate.JoueursClub = entity.JoueursClub;
            await fifaDbContext.SaveChangesAsync();
        }

    }
}
