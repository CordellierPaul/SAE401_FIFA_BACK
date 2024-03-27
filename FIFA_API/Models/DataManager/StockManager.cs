using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FIFA_API.Models.DataManager
{
    public class StockManager : IStockRepository
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

        public async Task UpdateAsync(Stock entityToUpdate, Stock entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.StockId = entity.StockId;
            entityToUpdate.TailleId = entity.TailleId;
            entityToUpdate.VarianteProduitId = entity.VarianteProduitId;
            entityToUpdate.QuantiteStockee = entity.QuantiteStockee;
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Stock>>> GetStockByVarianteIds(int[] varianteId)
        {
            IEnumerable < Stock > stocks = await fifaDbContext.Stock.Where(u => varianteId.Contains(u.VarianteProduitId)).ToListAsync();


            foreach (var stock in stocks)
            {
                EntityEntry<Stock> produitEntityEntry = fifaDbContext.Entry(stock);

                await produitEntityEntry.Reference(p => p.TailleStockee).LoadAsync();
            }

            return stocks.ToList();
        }
    }
}
