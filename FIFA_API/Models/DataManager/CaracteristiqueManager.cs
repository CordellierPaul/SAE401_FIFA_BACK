using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class CaracteristiqueManager : IDataRepository<Caracteristique>
    {
        private readonly FifaDbContext fifaDbContext;

        public CaracteristiqueManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Caracteristique>>> GetAllAsync()
        {
            return await fifaDbContext.Caracteristique.ToListAsync();
        }

        public async Task AddAsync(Caracteristique entity)
        {
            await fifaDbContext.Caracteristique.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Caracteristique entity)
        {
            fifaDbContext.Caracteristique.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Caracteristique?>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Caracteristique.FirstOrDefaultAsync(u => u.CaracteristiqueId == id);

        }

        public async Task<ActionResult<Caracteristique?>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Caracteristique.FirstOrDefaultAsync(u => u.CaracteristiqueNom.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Caracteristique entityToUpdate, Caracteristique entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.CaracteristiqueId = entity.CaracteristiqueId;
            entityToUpdate.CaracteristiqueNom = entity.CaracteristiqueNom;
            entityToUpdate.LienProduits = entity.LienProduits;
            await fifaDbContext.SaveChangesAsync();
        }

    }
}
