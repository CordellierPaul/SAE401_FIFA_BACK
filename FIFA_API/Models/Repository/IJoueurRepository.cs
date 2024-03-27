using FIFA_API.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FIFA_API.Models.Repository
{
    public interface IJoueurRepository : IDataRepository<Joueur>
    {
        Task<IEnumerable<Joueur>> GetJoueursByIdsAsync(int[] ids);

    }
}
