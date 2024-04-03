using FIFA_API.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FIFA_API.Models.Repository
{
    public interface ICommentaireRepository : IDataRepositoryWithoutStr<Commentaire>
    {
        Task<ActionResult<Commentaire>> GetResponseOfCommentaire(int idCom);
    }
}
