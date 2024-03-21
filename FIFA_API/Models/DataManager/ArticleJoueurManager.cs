using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class ArticleJoueurManager : IDataRepository2clues<ArticleJoueur>
    {

        readonly FifaDbContext? fifaDbContext;

        public ArticleJoueurManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<ArticleJoueur>>> GetAllAsync()
        {
            return await fifaDbContext.ArticleJoueur.ToListAsync();
        }

        public async Task AddAsync(ArticleJoueur entity)
        {
            await fifaDbContext.ArticleJoueur.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ArticleJoueur entity)
        {
            fifaDbContext.ArticleJoueur.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<ArticleJoueur>> GetByIdAsync(int uid, int tid)
        {
            return await fifaDbContext.ArticleJoueur.FirstOrDefaultAsync(u => u.ArticleId == uid && u.JoueurId == tid);
        }


        public async Task UpdateAsync(ArticleJoueur entityToUpdate, ArticleJoueur entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.ArticleId = entity.ArticleId;
            entityToUpdate.JoueurId = entity.JoueurId;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
