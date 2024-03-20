using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class TropheeManager : IDataRepository<Trophee>
    {
        private readonly FifaDbContext fifaDbContext;

        public TropheeManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Trophee>>> GetAllAsync()
        {
            return await fifaDbContext.Trophee.ToListAsync();
        }

        public async Task AddAsync(Trophee entity)
        {
            await fifaDbContext.Trophee.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Trophee entity)
        {
            fifaDbContext.Trophee.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Trophee>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Trophee.FirstOrDefaultAsync(u => u.TropheeId == id);

        }

        public async Task<ActionResult<Trophee>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Trophee.FirstOrDefaultAsync(u => u.TropheeNom.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Trophee entityToUpdate, Trophee entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.TropheeId = entity.TropheeId;
            entityToUpdate.TropheeNom = entity.TropheeNom;
            entityToUpdate.RemportesTrophee = entity.RemportesTrophee;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
