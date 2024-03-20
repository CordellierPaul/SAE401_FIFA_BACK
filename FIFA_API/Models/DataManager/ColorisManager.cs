using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class ColorisManager : IDataRepository<Coloris>
    {
        private readonly FifaDbContext fifaDbContext;

        public ColorisManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Coloris>>> GetAllAsync()
        {
            return await fifaDbContext.Coloris.ToListAsync();
        }

        public async Task AddAsync(Coloris entity)
        {
            await fifaDbContext.Coloris.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Coloris entity)
        {
            fifaDbContext.Coloris.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Coloris?>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Coloris.FirstOrDefaultAsync(u => u.ColorisId == id);

        }

        public async Task<ActionResult<Coloris?>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Coloris.FirstOrDefaultAsync(u => u.ColorisNom.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Coloris entityToUpdate, Coloris entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.ColorisId = entity.ColorisId;
            entityToUpdate.ColorisNom = entity.ColorisNom;
            entityToUpdate.VariantesColorises = entity.VariantesColorises;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
