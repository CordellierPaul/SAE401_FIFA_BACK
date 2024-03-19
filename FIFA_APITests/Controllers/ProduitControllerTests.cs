using Microsoft.VisualStudio.TestTools.UnitTesting;
using FIFA_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.EntityFrameworkCore;
using FIFA_API.Models.DataManager;

namespace FIFA_API.Controllers.Tests
{
    [TestClass()]
    public class ProduitControllerTests
    {
        private FifaDbContext _context;
        private ProduitController _controller;
        private IDataRepository<Utilisateur> _dataRepository;

        public ProduitControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=localhost;port=5432;Database=FifaDB; uid=postgres; password=postgres;");
            _context = new FifaDbContext(builder.Options);
            //_dataRepository = new ProduitManager(_context);
            //_controller = new ProduitController(_dataRepository);
        }

        /*[TestMethod()]
        public void GetAllProduitTest_Ok()
        {
            Assert.Fail();
        }*/



        [TestMethod()]
        public void GetProduitByIdTest_OK()
        {
            Produit expected = _context.Produit.Where(u => u.ProduitId == 1).First();

            var result = _controller.GetProduit(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes produits");
        }
    }
}