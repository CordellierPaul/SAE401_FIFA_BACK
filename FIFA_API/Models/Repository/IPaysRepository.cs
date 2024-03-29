using FIFA_API.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FIFA_API.Models.Repository
{
    public interface IPaysRepository : IDataRepository<Pays>
    {
        Task<ActionResult<IEnumerable<Pays>>> GetPaysWhereProduitExists();
    }
}
