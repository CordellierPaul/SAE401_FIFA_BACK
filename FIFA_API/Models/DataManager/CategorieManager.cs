using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FIFA_API.Models.DataManager
{
    public class CategorieManager : IDataRepository<Categorie>
    {
        readonly FifaDbContext? fifaDbContext;

        public CategorieManager() { }
        public CategorieManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public Task AddAsync(Categorie entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Categorie entity)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<Categorie>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Categorie>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Categorie>> GetByStringAsync(string str)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Categorie entityToUpdate, Categorie entity)
        {
            throw new NotImplementedException();
        }
    }
}
