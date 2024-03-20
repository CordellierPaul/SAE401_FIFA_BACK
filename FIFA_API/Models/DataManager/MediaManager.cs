using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class MediaManager : IDataRepository<Media>
    {
        private readonly FifaDbContext fifaDbContext;

        public MediaManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Media>>> GetAllAsync()
        {
            return await fifaDbContext.Media.ToListAsync();
        }

        public async Task AddAsync(Media entity)
        {
            await fifaDbContext.Media.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Media entity)
        {
            fifaDbContext.Media.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Media>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Media.FirstOrDefaultAsync(u => u.MediaId == id);

        }

        public async Task<ActionResult<Media>> GetByStringAsync(string str)
        {
            throw new NotImplementedException(); // a changer le répository
        }

        public async Task UpdateAsync(Media entityToUpdate, Media entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.MediaId = entity.MediaId;
            entityToUpdate.MediaUrl = entity.MediaUrl;
            entityToUpdate.LiensArticles = entity.LiensArticles;
            entityToUpdate.MediaFilm = entity.MediaFilm;
            entityToUpdate.ImagesMedia = entity.ImagesMedia;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
