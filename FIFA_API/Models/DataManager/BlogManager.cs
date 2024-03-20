using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class BlogManager : IDataRepository<Blog>
    {
        private readonly FifaDbContext fifaDbContext;

        public BlogManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Blog>>> GetAllAsync()
        {
            return await fifaDbContext.Blog.ToListAsync();
        }

        public async Task AddAsync(Blog entity)
        {
            await fifaDbContext.Blog.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Blog entity)
        {
            fifaDbContext.Blog.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Blog?>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Blog.FirstOrDefaultAsync(u => u.BlogId == id);

        }

        public async Task<ActionResult<Blog?>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Blog.FirstOrDefaultAsync(u => u.BlogTitre.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Blog entityToUpdate, Blog entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.BlogId = entity.BlogId;
            entityToUpdate.ArticleId = entity.ArticleId;
            entityToUpdate.BlogDateHeure = entity.BlogDateHeure;
            entityToUpdate.BlogTitre = entity.BlogTitre;
            entityToUpdate.BlogResume = entity.BlogResume;
            entityToUpdate.BlogDescription = entity.BlogDescription;
            entityToUpdate.CommentairesBlog = entity.CommentairesBlog;
            entityToUpdate.LikesBlogs = entity.LikesBlogs;
            entityToUpdate.LiensImages = entity.LiensImages;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
