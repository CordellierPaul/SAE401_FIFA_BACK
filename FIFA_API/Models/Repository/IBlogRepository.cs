using FIFA_API.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FIFA_API.Models.Repository
{
    public interface IBlogRepository : IDataRepository<Blog>
    {
        Task<ActionResult<IEnumerable<Commentaire>>> GetCommentaireByBlogId(int idBlog);
    }
}
