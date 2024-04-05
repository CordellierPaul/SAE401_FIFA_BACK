using FIFA_API.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FIFA_API.Models.Repository
{
    public interface ILigneCommandeRepository: IDataRepositoryWithoutStr<LigneCommande>
    {
        Task<ActionResult<IEnumerable<LigneCommande>>> GetByCommandeIdAsync(int id);
    }
}
