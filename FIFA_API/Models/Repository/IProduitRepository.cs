using Microsoft.AspNetCore.Mvc;
using FIFA_API.Models.EntityFramework;

namespace FIFA_API.Models.Repository
{
    public interface IProduitRepository : IDataRepository<Produit>
    {
        Task<ActionResult<IEnumerable<Produit>>> GetSearchResult(string searchInput);
        Task<ActionResult<string>> GetAnImagePathOfProduitById(int id);
    }
}
