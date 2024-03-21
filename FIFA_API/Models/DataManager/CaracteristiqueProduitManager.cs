using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class CaracteristiqueProduitManager : IDataRepository2clues<CaracteristiqueProduit>
    {

        readonly FifaDbContext? fifaDbContext;

        public CaracteristiqueProduitManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<CaracteristiqueProduit>>> GetAllAsync()
        {
            return await fifaDbContext.CaracteristiqueProduit.ToListAsync();
        }

        public async Task AddAsync(CaracteristiqueProduit entity)
        {
            await fifaDbContext.CaracteristiqueProduit.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(CaracteristiqueProduit entity)
        {
            fifaDbContext.CaracteristiqueProduit.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<CaracteristiqueProduit>> GetByIdAsync(int uid, int tid)
        {
            return await fifaDbContext.CaracteristiqueProduit.FirstOrDefaultAsync(u => u.CaracteristiqueId == uid && u.ProduitId == tid);
        }


        public async Task UpdateAsync(CaracteristiqueProduit entityToUpdate, CaracteristiqueProduit entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.CaracteristiqueId = entity.CaracteristiqueId;
            entityToUpdate.ProduitId = entity.ProduitId;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
