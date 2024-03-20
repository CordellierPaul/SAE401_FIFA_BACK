using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class ReglementManager : IDataRepository<Reglement>
    {
        private readonly FifaDbContext fifaDbContext;

        public ReglementManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Reglement>>> GetAllAsync()
        {
            return await fifaDbContext.Reglement.ToListAsync();
        }

        public async Task AddAsync(Reglement entity)
        {
            await fifaDbContext.Reglement.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Reglement entity)
        {
            fifaDbContext.Reglement.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Reglement>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Reglement.FirstOrDefaultAsync(u => u.TransactionId == id);

        }

        public async Task<ActionResult<Reglement>> GetByStringAsync(string str)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Reglement entityToUpdate, Reglement entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.TransactionId = entity.TransactionId;
            entityToUpdate.CommandeId = entity.CommandeId;
            entityToUpdate.ReglementMontant = entity.ReglementMontant;
            entityToUpdate.ReglementDate = entity.ReglementDate;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
