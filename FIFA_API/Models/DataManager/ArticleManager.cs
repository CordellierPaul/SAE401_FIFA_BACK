using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class ArticleManager : IDataRepository<Article>
    {

        private readonly FifaDbContext fifaDbContext;

        public ArticleManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Article>>> GetAllAsync()
        {
            return await fifaDbContext.Article.ToListAsync();
        }

        public async Task AddAsync(Article entity)
        {
            await fifaDbContext.Article.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Article entity)
        {
            fifaDbContext.Article.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Article>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Article.FirstOrDefaultAsync(u => u.ArticleId == id);

        }

        public async Task<ActionResult<Article>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Article.FirstOrDefaultAsync(u => u.ArticleTitre.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Article entityToUpdate, Article entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.ArticleId = entity.ArticleId;
            entityToUpdate.ArticleDateHeure = entity.ArticleDateHeure;
            entityToUpdate.ArticleTitre = entity.ArticleTitre;
            entityToUpdate.ArticleResume = entity.ArticleResume;
            entityToUpdate.ArticleTexte = entity.ArticleTexte;
            entityToUpdate.LiensJoueur = entity.LiensJoueur;
            entityToUpdate.LiensMedias = entity.LiensMedias;
            entityToUpdate.LikesArticles = entity.LikesArticles;
            entityToUpdate.CommentairesArticle = entity.CommentairesArticle;
            entityToUpdate.BlogsArticle = entity.BlogsArticle;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
