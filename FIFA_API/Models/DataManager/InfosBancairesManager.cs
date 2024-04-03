using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class InfosBancairesManager : IInfosBancairesRepository
    {
        private readonly FifaDbContext fifaDbContext;

        public InfosBancairesManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<InfosBancaires>>> GetAllAsync()
        {
            return await fifaDbContext.InfosBancaires.ToListAsync();
        }

        public async Task AddAsync(InfosBancaires entity)
        {
            await fifaDbContext.InfosBancaires.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(InfosBancaires entity)
        {
            fifaDbContext.InfosBancaires.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<InfosBancaires>> GetByIdAsync(int id)
        {
            return await fifaDbContext.InfosBancaires.FirstOrDefaultAsync(u => u.InfosBancairesId == id);

        }

        public async Task<ActionResult<InfosBancaires>> GetByStringAsync(string str)
        {
            return await fifaDbContext.InfosBancaires.FirstOrDefaultAsync(u => u.InfosBancaireNumCarte.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(InfosBancaires entityToUpdate, InfosBancaires entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.InfosBancairesId = entity.InfosBancairesId;
            entityToUpdate.InfosBancaireNumCarte = entity.InfosBancaireNumCarte;
            entityToUpdate.InfosBancaireNomCarte = entity.InfosBancaireNomCarte;
            entityToUpdate.InfosBancaireMoisExpiration = entity.InfosBancaireMoisExpiration;
            entityToUpdate.AnneeExpiration = entity.AnneeExpiration;
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<InfosBancaires>>> GetInfosBancairesOfCompte(int idUtilisateur)
        {
            return await fifaDbContext.InfosBancaires.ToListAsync();    // TODO améliorer ça
        }
    }
}
