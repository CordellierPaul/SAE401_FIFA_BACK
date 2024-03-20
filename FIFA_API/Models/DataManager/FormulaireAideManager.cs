using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class FormulaireAideManager : IDataRepository<FormulaireAide>
    {
        private readonly FifaDbContext fifaDbContext;

        public FormulaireAideManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<FormulaireAide>>> GetAllAsync()
        {
            return await fifaDbContext.FormulaireAide.ToListAsync();
        }

        public async Task AddAsync(FormulaireAide entity)
        {
            await fifaDbContext.FormulaireAide.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(FormulaireAide entity)
        {
            fifaDbContext.FormulaireAide.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<FormulaireAide>> GetByIdAsync(int id)
        {
            return await fifaDbContext.FormulaireAide.FirstOrDefaultAsync(u => u.FormulaireAideId == id);

        }

        public async Task<ActionResult<FormulaireAide>> GetByStringAsync(string str)
        {
            return await fifaDbContext.FormulaireAide.FirstOrDefaultAsync(u => u.Question.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(FormulaireAide entityToUpdate, FormulaireAide entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.FormulaireAideId = entity.FormulaireAideId;
            entityToUpdate.ActionId = entity.ActionId;
            entityToUpdate.UtilisateurId = entity.UtilisateurId;
            entityToUpdate.UtilisateurNom = entity.UtilisateurNom;
            entityToUpdate.FormulaireAideTelephone = entity.FormulaireAideTelephone;
            entityToUpdate.Question = entity.Question;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
