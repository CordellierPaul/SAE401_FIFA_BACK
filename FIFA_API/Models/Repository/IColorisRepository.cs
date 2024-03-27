using FIFA_API.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FIFA_API.Models.Repository
{
    public interface IColorisRepository : IDataRepository<Coloris>
    {
        Task<ActionResult<IEnumerable<Coloris>>> GetColorisProduit(int idProduit);
    }
}
