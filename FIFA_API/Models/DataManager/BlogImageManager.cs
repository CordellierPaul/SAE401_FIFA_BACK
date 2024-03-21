using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class BlogImageManager : IDataRepository2clues<BlogImage>
    {

        readonly FifaDbContext? fifaDbContext;

        public BlogImageManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<BlogImage>>> GetAllAsync()
        {
            return await fifaDbContext.BlogImage.ToListAsync();
        }

        public async Task AddAsync(BlogImage entity)
        {
            await fifaDbContext.BlogImage.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(BlogImage entity)
        {
            fifaDbContext.BlogImage.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<BlogImage>> GetByIdAsync(int uid, int tid)
        {
            return await fifaDbContext.BlogImage.FirstOrDefaultAsync(u => u.BlogId == uid && u.ImageId == tid);
        }


        public async Task UpdateAsync(BlogImage entityToUpdate, BlogImage entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.BlogId = entity.BlogId;
            entityToUpdate.ImageId = entity.ImageId;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
