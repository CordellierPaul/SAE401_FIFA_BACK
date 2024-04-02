using FIFA_API.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FIFA_API.Models.Repository
{
    public interface IArticleRepository : IDataRepository<Article>
    {
        Task<ActionResult<IEnumerable<Commentaire>>> GetCommentairesByArticleId(int idBlog);
    }
}
