using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class CompetitionManager : IDataRepository<Competition>
    {
        private readonly FifaDbContext fifaDbContext;

        public CompetitionManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Competition>>> GetAllAsync()
        {
            return await fifaDbContext.Competition.ToListAsync();
        }

        public async Task AddAsync(Competition entity)
        {
            await fifaDbContext.Competition.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Competition entity)
        {
            fifaDbContext.Competition.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Competition>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Competition.FirstOrDefaultAsync(u => u.CompetitionId == id);

        }

        public async Task<ActionResult<Competition>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Competition.FirstOrDefaultAsync(u => u.CompetitionNom.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Competition entityToUpdate, Competition entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.CompetitionId = entity.CompetitionId;
            entityToUpdate.CompetitionNom = entity.CompetitionNom;
            entityToUpdate.ProduitsCompetition = entity.ProduitsCompetition;
            await fifaDbContext.SaveChangesAsync();
        }

    }
}
