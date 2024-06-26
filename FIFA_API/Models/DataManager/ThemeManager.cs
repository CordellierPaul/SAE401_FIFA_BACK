﻿using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FIFA_API.Models.DataManager
{
    public class ThemeManager : IThemeRepository
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

        public async Task<ActionResult<IEnumerable<Joueur>>> GetJoueursByThemeId(int idTheme)
        {
            Theme? leTheme = await fifaDbContext.Theme.FirstOrDefaultAsync(x => x.ThemeId == idTheme);

            if (leTheme is null)
                return null;

            EntityEntry<Theme> themeEntityEntry = fifaDbContext.Entry(leTheme);

            return new ActionResult<IEnumerable<Joueur>>(themeEntityEntry
                .Collection(p => p.LienJoueur)
                .Query()
                .Select(x => x.JoueurNavigation)
                .AsEnumerable());


        }
    }
}
