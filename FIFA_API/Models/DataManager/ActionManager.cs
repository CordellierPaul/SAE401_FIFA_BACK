using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ActionEntity = FIFA_API.Models.EntityFramework.Action;

namespace FIFA_API.Models.DataManager
{
    public class ActionManager : IDataRepository<ActionEntity>
    {
        readonly FifaDbContext? fifaDbContext;

        public ActionManager() { }
        public ActionManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<ActionEntity>>> GetAllAsync()
        {
            return await fifaDbContext.Action.ToListAsync();
        }

        public async Task AddAsync(ActionEntity entity)
        {
            await fifaDbContext.Action.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ActionEntity entity)
        {
            fifaDbContext.Action.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<ActionEntity>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Action.FirstOrDefaultAsync(u => u.ActionId == id);
        }

        public async Task<ActionResult<ActionEntity>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Action.FirstOrDefaultAsync(u => u.TypeAction.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(ActionEntity entityToUpdate, ActionEntity entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.ActionId = entity.ActionId;
            entityToUpdate.TypeAction = entity.TypeAction;
            entityToUpdate.ActionFormulaireAide = entity.ActionFormulaireAide;
            await fifaDbContext.SaveChangesAsync();
        }

    }
}
