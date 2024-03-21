using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class LikeDocumentManager : IDataRepository2clues<LikeDocument>
    {

        readonly FifaDbContext? fifaDbContext;

        public LikeDocumentManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<LikeDocument>>> GetAllAsync()
        {
            return await fifaDbContext.LikeDocument.ToListAsync();
        }

        public async Task AddAsync(LikeDocument entity)
        {
            await fifaDbContext.LikeDocument.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(LikeDocument entity)
        {
            fifaDbContext.LikeDocument.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<LikeDocument>> GetByIdAsync(int uid, int tid)
        {
            return await fifaDbContext.LikeDocument.FirstOrDefaultAsync(u => u.DocumentId == uid && u.UtilisateurId == tid);
        }


        public async Task UpdateAsync(LikeDocument entityToUpdate, LikeDocument entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.DocumentId = entity.DocumentId;
            entityToUpdate.UtilisateurId = entity.UtilisateurId;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
