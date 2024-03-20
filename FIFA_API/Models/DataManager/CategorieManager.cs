using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class CategorieManager : IDataRepository<Categorie>
    {
        readonly FifaDbContext? fifaDbContext;

        public CategorieManager() { }
        public CategorieManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task AddAsync(Categorie entity)
        {
            await fifaDbContext.Categorie.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Categorie entity)
        {
            fifaDbContext.Categorie.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Categorie>>> GetAllAsync()
        {
            return await fifaDbContext.Categorie.ToListAsync();
        }

        public async Task<ActionResult<Categorie>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Categorie.FirstOrDefaultAsync(u => u.CategorieId == id);
        }

        public async Task<ActionResult<Categorie>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Categorie.FirstOrDefaultAsync(u => u.CategorieNom.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Categorie entityToUpdate, Categorie entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.CategorieId = entity.CategorieId;
            entityToUpdate.CategorieNom = entity.CategorieNom;
            entityToUpdate.EnfantsCategorie = entity.EnfantsCategorie;
            entityToUpdate.ParentsCategorie = entity.ParentsCategorie;
            entityToUpdate.ProduitsCategorie = entity.ProduitsCategorie;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
