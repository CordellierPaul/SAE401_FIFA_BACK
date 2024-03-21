using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class LikeArticleManager : IDataRepository2clues<LikeArticle>
    {

        readonly FifaDbContext? fifaDbContext;

        public LikeArticleManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<LikeArticle>>> GetAllAsync()
        {
            return await fifaDbContext.LikeArticle.ToListAsync();
        }

        public async Task AddAsync(LikeArticle entity)
        {
            await fifaDbContext.LikeArticle.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(LikeArticle entity)
        {
            fifaDbContext.LikeArticle.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<LikeArticle>> GetByIdAsync(int uid, int tid)
        {
            return await fifaDbContext.LikeArticle.FirstOrDefaultAsync(u => u.ArticleId == uid && u.UtilisateurId == tid);
        }


        public async Task UpdateAsync(LikeArticle entityToUpdate, LikeArticle entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.ArticleId = entity.ArticleId;
            entityToUpdate.UtilisateurId = entity.UtilisateurId;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
