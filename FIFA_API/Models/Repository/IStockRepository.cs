using FIFA_API.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FIFA_API.Models.Repository
{
    public interface IStockRepository : IDataRepositoryWithoutStr<Stock>
    {
        Task<ActionResult<IEnumerable<Stock>>> GetStockByVarianteIds(int[] varianteId);
    }
}
