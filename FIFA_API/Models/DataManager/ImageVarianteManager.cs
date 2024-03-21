using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class ImageVarianteManager : IDataRepository2clues<ImageVariante>
    {

        readonly FifaDbContext? fifaDbContext;

        public ImageVarianteManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<ImageVariante>>> GetAllAsync()
        {
            return await fifaDbContext.ImageVariante.ToListAsync();
        }

        public async Task AddAsync(ImageVariante entity)
        {
            await fifaDbContext.ImageVariante.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ImageVariante entity)
        {
            fifaDbContext.ImageVariante.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<ImageVariante>> GetByIdAsync(int uid, int tid)
        {
            return await fifaDbContext.ImageVariante.FirstOrDefaultAsync(u => u.ImageId == uid && u.VarianteProduitId == tid);
        }


        public async Task UpdateAsync(ImageVariante entityToUpdate, ImageVariante entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.VarianteProduitId = entity.VarianteProduitId;
            entityToUpdate.ImageId = entity.ImageId;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
