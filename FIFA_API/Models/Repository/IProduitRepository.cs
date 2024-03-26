using Microsoft.AspNetCore.Mvc;
using FIFA_API.Models.EntityFramework;

namespace FIFA_API.Models.Repository
{
    public interface IProduitRepository : IDataRepository<Produit>
    {
        Task<ActionResult<IEnumerable<Produit>>> GetSearchResults(string searchInput);
        Task<ActionResult<IEnumerable<Produit>>> GetByFilter(int? catId, int? taiId, int?[] colId, int? genreId, int? paysId);
        Task<ActionResult<string>> GetAnImagePathOfProduitById(int id);
        Task<IEnumerable<Produit>> GetProduitsByIdsAsync(int[] ids);


    }
}
