using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class StockManager : IDataRepository<Stock>
    {
        private readonly FifaDbContext fifaDbContext;

        public StockManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Stock>>> GetAllAsync()
        {
            return await fifaDbContext.Stock.ToListAsync();
        }

        public async Task AddAsync(Stock entity)
        {
            await fifaDbContext.Stock.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Stock entity)
        {
            fifaDbContext.Stock.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Stock>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Stock.FirstOrDefaultAsync(u => u.StockId == id);

        }

        public async Task<ActionResult<Stock>> GetByStringAsync(string str)
        {
           throw new NotImplementedException();
        }

        public async Task UpdateAsync(Stock entityToUpdate, Stock entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.StockId = entity.StockId;
            entityToUpdate.TailleId = entity.TailleId;
            entityToUpdate.VarianteProduitId = entity.VarianteProduitId;
            entityToUpdate.QuantiteStockeeId = entity.QuantiteStockeeId;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
