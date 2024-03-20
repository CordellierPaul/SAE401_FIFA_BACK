using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class AlbumManager : IDataRepository<Album>
    {
        readonly FifaDbContext? fifaDbContext;

        public AlbumManager() { }
        public AlbumManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Album>>> GetAllAsync(
        {
            return await fifaDbContext.Album.ToListAsync();
        }

        public async Task AddAsync(Album entity)
        {
            await fifaDbContext.Album.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Album entity)
        {
            fifaDbContext.Album.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Album>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Album.FirstOrDefaultAsync(u => u.AlbumId == id);
        }

        public async Task<ActionResult<Album>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Album.FirstOrDefaultAsync(u => u.AlbumTitre.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Album entityToUpdate, Album entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.AlbumId = entity.AlbumId;
            entityToUpdate.DateHeure = entity.DateHeure;
            entityToUpdate.AlbumTitre = entity.AlbumTitre;
            entityToUpdate.AlbumResume = entity.AlbumResume;
            entityToUpdate.LiensImages = entity.LiensImages;
            entityToUpdate.CommentairesAlbum = entity.CommentairesAlbum;
            entityToUpdate.LikesAlbums = entity.LikesAlbums;
            await fifaDbContext.SaveChangesAsync();
        }

    }
}
