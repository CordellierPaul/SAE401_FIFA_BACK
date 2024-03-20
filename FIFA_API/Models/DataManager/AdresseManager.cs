using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.DataManager
{
    public class AdresseManager : IDataRepository<Adresse>
    {

        readonly FifaDbContext? fifaDbContext;

        public AdresseManager() { }
        public AdresseManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Adresse>>> GetAllAsync()
        {
            return await fifaDbContext.Adresse.ToListAsync();
        }

        public async Task AddAsync(Adresse entity)
        {
            await fifaDbContext.Adresse.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Adresse entity)
        {
            fifaDbContext.Adresse.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Adresse>> GetByIdAsync(int id)
        {
            return await fifaDbContext.Adresse.FirstOrDefaultAsync(u => u.AdresseId == id);
        }

        public async Task<ActionResult<Adresse>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Adresse.FirstOrDefaultAsync(u => u.AdresseRue.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Adresse entityToUpdate, Adresse entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.AdresseId = entity.AdresseId;
            entityToUpdate.AdresseRue = entity.AdresseRue;
            entityToUpdate.VilleId = entity.VilleId;
            entityToUpdate.CommandesAdresse = entity.CommandesAdresse;
            entityToUpdate.UtilisateursAdresse = entity.UtilisateursAdresse;
            entityToUpdate.LienVille = entity.LienVille;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
