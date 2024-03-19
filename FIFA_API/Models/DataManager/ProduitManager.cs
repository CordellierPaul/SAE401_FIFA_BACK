using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;

namespace FIFA_API.Models.DataManager
{
    public class ProduitManager : IDataRepository<Produit>
    {
        readonly FifaDbContext? fifaDbContext;

        public ProduitManager() { }
        public ProduitManager(FifaDbContext? context)
        {
            fifaDbContext = context;
        }
    }
}
