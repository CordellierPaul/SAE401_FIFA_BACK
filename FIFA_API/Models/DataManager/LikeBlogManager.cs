using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class LikeBlogManager : IDataRepository2clues<LikeBlog>
    {

        readonly FifaDbContext? fifaDbContext;

        public LikeBlogManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<LikeBlog>>> GetAllAsync()
        {
            return await fifaDbContext.LikeBlog.ToListAsync();
        }

        public async Task AddAsync(LikeBlog entity)
        {
            await fifaDbContext.LikeBlog.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(LikeBlog entity)
        {
            fifaDbContext.LikeBlog.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<LikeBlog>> GetByIdAsync(int uid, int tid)
        {
            return await fifaDbContext.LikeBlog.FirstOrDefaultAsync(u => u.BlogId == uid && u.UtilisateurId == tid);
        }


        public async Task UpdateAsync(LikeBlog entityToUpdate, LikeBlog entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.BlogId = entity.BlogId;
            entityToUpdate.UtilisateurId = entity.UtilisateurId;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
