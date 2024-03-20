using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class ThemeManager : IDataRepository<Theme>
    {
        private readonly FifaDbContext fifaDbContext;

        public ThemeManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Theme>>> GetAllAsync()
        {
            return await fifaDbContext.Theme.ToListAsync();
        }

        public async Task AddAsync(Theme entity)
        {
            await fifaDbContext.Theme.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Theme entity)
        {
            fifaDbContext.Theme.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Theme>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Theme.FirstOrDefaultAsync(u => u.ThemeId == id);

        }

        public async Task<ActionResult<Theme>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Theme.FirstOrDefaultAsync(u => u.ThemeLibelle.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Theme entityToUpdate, Theme entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.ThemeId = entity.ThemeId;
            entityToUpdate.ThemeLibelle = entity.ThemeLibelle;
            entityToUpdate.VotesTheme = entity.VotesTheme;
            entityToUpdate.LienJoueur = entity.LienJoueur;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
