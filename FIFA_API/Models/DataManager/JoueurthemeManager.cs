using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class JoueurThemeManager : IDataRepository2clues<JoueurTheme>
    {

        readonly FifaDbContext? fifaDbContext;

        public JoueurThemeManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<JoueurTheme>>> GetAllAsync()
        {
            return await fifaDbContext.JoueurTheme.ToListAsync();
        }

        public async Task AddAsync(JoueurTheme entity)
        {
            await fifaDbContext.JoueurTheme.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(JoueurTheme entity)
        {
            fifaDbContext.JoueurTheme.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<JoueurTheme>> GetByIdAsync(int uid, int tid)
        {
            return await fifaDbContext.JoueurTheme.FirstOrDefaultAsync(u => u.JoueurId == uid && u.ThemeId == tid);
        }


        public async Task UpdateAsync(JoueurTheme entityToUpdate, JoueurTheme entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.JoueurId = entity.JoueurId;
            entityToUpdate.ThemeId = entity.ThemeId;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
