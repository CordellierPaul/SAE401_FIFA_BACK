using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class LikeAlbumManager : IDataRepository2clues<LikeAlbum>
    {

        readonly FifaDbContext? fifaDbContext;

        public LikeAlbumManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<LikeAlbum>>> GetAllAsync()
        {
            return await fifaDbContext.LikeAlbum.ToListAsync();
        }

        public async Task AddAsync(LikeAlbum entity)
        {
            await fifaDbContext.LikeAlbum.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(LikeAlbum entity)
        {
            fifaDbContext.LikeAlbum.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<LikeAlbum>> GetByIdAsync(int uid, int tid)
        {
            return await fifaDbContext.LikeAlbum.FirstOrDefaultAsync(u => u.AlbumId == uid && u.UtilisateurId == tid);
        }

        //public async Task<ActionResult<IEnumerable<LikeAlbum>>> GetByAlbumIdAsync(int id)
        //{
        //    return await fifaDbContext.LikeAlbum.Where(u => u.AlbumId == id).ToListAsync();
        //}


        public async Task UpdateAsync(LikeAlbum entityToUpdate, LikeAlbum entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.AlbumId = entity.AlbumId;
            entityToUpdate.UtilisateurId = entity.UtilisateurId;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
