using FIFA_API.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;


namespace FIFA_API.Models.Repository
{
    public interface ICommandeRepository : IDataRepositoryWithoutStr<Commande>
    {
        Task<ActionResult<IEnumerable<Commande>>> GetByUserIdAsync(int id);
    }
}
