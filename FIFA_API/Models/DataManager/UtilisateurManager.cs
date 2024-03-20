using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FIFA_API.Models.DataManager
{
    public class UtilisateurManager : IDataRepository<Utilisateur>
    {
        readonly FifaDbContext? fifaDbContext;

        public UtilisateurManager() { }
        public UtilisateurManager(FifaDbContext? context)
        {
            fifaDbContext = context;
        }

        public Task AddAsync(Utilisateur entity)
        {
            throw new NotImplementedException();
            //return await fifaDbContext.Utilisateurs.ToListAsync();
        }

        public Task DeleteAsync(Utilisateur entity)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<Utilisateur>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Utilisateur?>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Utilisateur?>> GetByStringAsync(string str)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Utilisateur entityToUpdate, Utilisateur entity)
        {
            throw new NotImplementedException();
        }
    }
}
