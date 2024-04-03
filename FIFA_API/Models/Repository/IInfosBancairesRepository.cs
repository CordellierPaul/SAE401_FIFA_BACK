using FIFA_API.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FIFA_API.Models.Repository
{
    public interface IInfosBancairesRepository : IDataRepository<InfosBancaires>
    {
        Task<ActionResult<IEnumerable<InfosBancaires>>> GetInfosBancairesOfCompte(int id);
    }
}
