using FIFA_API.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FIFA_API.Models.Repository
{
    public interface IThemeRepository : IDataRepository<Theme>
    {
        Task<ActionResult<IEnumerable<Joueur>>> GetJoueursByThemeId(int idTheme);
    }
}
