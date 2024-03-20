using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class DocumentManager : IDataRepository<Document>
    {
        private readonly FifaDbContext fifaDbContext;

        public DocumentManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Document>>> GetAllAsync()
        {
            return await fifaDbContext.Document.ToListAsync();
        }

        public async Task AddAsync(Document entity)
        {
            await fifaDbContext.Document.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Document entity)
        {
            fifaDbContext.Document.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Document>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Document.FirstOrDefaultAsync(u => u.DocumentId == id);

        }

        public async Task<ActionResult<Document>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Document.FirstOrDefaultAsync(u => u.DocumentTitre.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Document entityToUpdate, Document entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.DocumentId = entity.DocumentId;
            entityToUpdate.DocumentDateHeure = entity.DocumentDateHeure;
            entityToUpdate.DocumentTitre = entity.DocumentTitre;
            entityToUpdate.DocumentResume = entity.DocumentResume;
            entityToUpdate.DocumentLienPdf = entity.DocumentLienPdf;
            entityToUpdate.CommentairesDocument = entity.CommentairesDocument;
            entityToUpdate.LikesDocuments = entity.LikesDocuments;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
