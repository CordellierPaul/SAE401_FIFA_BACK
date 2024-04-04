using FIFA_API.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FIFA_API.Models.Repository
{
    public interface ICompteRepository : IDataRepository<Compte>
    {
        Task<Compte?> GetCompteByCompte(Compte compte);
    }
}
