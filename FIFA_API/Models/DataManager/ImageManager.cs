using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class ImageManager : IDataRepositoryWithoutStr<Image>
    {
        private readonly FifaDbContext fifaDbContext;

        public ImageManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Image>>> GetAllAsync()
        {
            return await fifaDbContext.Image.ToListAsync();
        }

        public async Task AddAsync(Image entity)
        {
            await fifaDbContext.Image.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Image entity)
        {
            fifaDbContext.Image.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Image>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Image.FirstOrDefaultAsync(u => u.ImageId == id);

        }

        public async Task UpdateAsync(Image entityToUpdate, Image entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.ImageId = entity.ImageId;
            entityToUpdate.ImageUrl = entity.ImageUrl;
            entityToUpdate.LiensAlbums = entity.LiensAlbums;
            entityToUpdate.LiensBlogs = entity.LiensBlogs;
            entityToUpdate.LiensJoueurs = entity.LiensJoueurs;
            entityToUpdate.ImagesVariante = entity.ImagesVariante;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
