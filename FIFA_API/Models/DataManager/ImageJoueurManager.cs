using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class ImageJoueurManager : IDataRepository2clues<ImageJoueur>
    {

        readonly FifaDbContext? fifaDbContext;

        public ImageJoueurManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<ImageJoueur>>> GetAllAsync()
        {
            return await fifaDbContext.ImageJoueur.ToListAsync();
        }

        public async Task AddAsync(ImageJoueur entity)
        {
            await fifaDbContext.ImageJoueur.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ImageJoueur entity)
        {
            fifaDbContext.ImageJoueur.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<ImageJoueur>> GetByIdAsync(int uid, int tid)
        {
            return await fifaDbContext.ImageJoueur.FirstOrDefaultAsync(u => u.ImageId == uid && u.JoueurId == tid);
        }


        public async Task UpdateAsync(ImageJoueur entityToUpdate, ImageJoueur entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.JoueurId = entity.JoueurId;
            entityToUpdate.ImageId = entity.ImageId;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
