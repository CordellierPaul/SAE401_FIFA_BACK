using FIFA_API.Models.DataManager;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FIFA_API.Controllers.Tests
{
    [TestClass()]
    public class LoginControllerTests
    {
        private FifaDbContext _context;
        private ProduitController _controller;
        private IDataRepository<Compte> _dataRepository;

        public LoginControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new CompteManager(_context);
            _controller = new LoginController(, _dataRepository);
        }

        [TestMethod()]
        public void LoginControllerTest_200OkResult()
        {

        }

        [TestMethod()]
        public void LoginControllerTest_401Unauthorized()
        {

        }
    }
}
