using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class ArticleMediaManager : IDataRepository2clues<ArticleMedia>
    {

        readonly FifaDbContext? fifaDbContext;

        public ArticleMediaManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<ArticleMedia>>> GetAllAsync()
        {
            return await fifaDbContext.ArticleMedia.ToListAsync();
        }

        public async Task AddAsync(ArticleMedia entity)
        {
            await fifaDbContext.ArticleMedia.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ArticleMedia entity)
        {
            fifaDbContext.ArticleMedia.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<ArticleMedia>> GetByIdAsync(int uid, int tid)
        {
            return await fifaDbContext.ArticleMedia.FirstOrDefaultAsync(u => u.ArticleId == uid && u.MediaId == tid);
        }


        public async Task UpdateAsync(ArticleMedia entityToUpdate, ArticleMedia entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.ArticleId = entity.ArticleId;
            entityToUpdate.MediaId = entity.MediaId;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
