using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class AlbumImageManager : IDataRepository2clues<AlbumImage>
    {

        readonly FifaDbContext? fifaDbContext;

        public AlbumImageManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<AlbumImage>>> GetAllAsync()
        {
            return await fifaDbContext.AlbumImage.ToListAsync();
        }

        public async Task AddAsync(AlbumImage entity)
        {
            await fifaDbContext.AlbumImage.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(AlbumImage entity)
        {
            fifaDbContext.AlbumImage.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<AlbumImage>> GetByIdAsync(int uid, int tid)
        {
            return await fifaDbContext.AlbumImage.FirstOrDefaultAsync(u => u.AlbumId == uid && u.ImageId == tid);
        }


        public async Task UpdateAsync(AlbumImage entityToUpdate, AlbumImage entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.AlbumId = entity.AlbumId;
            entityToUpdate.ImageId = entity.ImageId;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
