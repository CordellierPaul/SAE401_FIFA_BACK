using Microsoft.VisualStudio.TestTools.UnitTesting;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using FIFA_API.Models.DataManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIFA_API.Controllers.Tests
{
    [TestClass()]
    public class CategorieControllerTests
    {
        private FifaDbContext _context;
        private CategorieController _controller;
        private IDataRepository<Categorie> _dataRepository;

        public CategorieControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=localhost;port=5432;Database=FifaDB; uid=postgres; password=postgres;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new CategorieManager(_context);
            _controller = new CategorieController(_dataRepository);
        }


        [TestMethod()]
        public void CategorieControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetCategoriesTest_OK()
        {
            var expected = _context.Categorie.ToList();

            var results = _controller.GetCategorie().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetCategorieByIdTest_OK()
        {
            Categorie expected = _context.Categorie.Where(u => u.CategorieId == 1).First();

            var result = _controller.GetCategorieById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes categories");
        }



        [TestMethod()]
        public void GetCategorieByIdTest_NONOK()
        {
            var result = _controller.GetCategorieById(0).Result;

            Assert.IsNull(result.Value);
        }

        [TestMethod()]
        public void GetCategorieByNomTest_OK()
        {
            Categorie expected = _context.Categorie.Where(u => u.CategorieId == 1).First();

            var result = _controller.GetCategorieByNom(expected.CategorieNom).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes categories");
        }

        [TestMethod()]
        public void PutCategorieTest_OK()
        {
            Categorie expected = _context.Categorie.Where(u => u.CategorieId == 1).First();
            expected.CategorieNom = "Test";

            var result = _controller.PutCategorie(1, expected).Result;
            Categorie resultUser = _controller.GetCategorieById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultUser, "Pas les mêmes categories");
        }

        [TestMethod]
        public void PostCategorieTest_OK()
        {
            // Arrange
            Categorie catAtester = new Categorie()
            {
                CategorieNom = "Test" + DateTime.UtcNow.ToString()
            };
            // Act
            var result = _controller.PostCategorie(catAtester).Result;

            // Assert
            Categorie? catRecupere = _context.Categorie.Where(u => u.CategorieNom.ToUpper() == catAtester.CategorieNom.ToUpper()).FirstOrDefault();

            catAtester.CategorieId = catRecupere.CategorieId;

            Assert.AreEqual(catRecupere, catAtester, "Categories pas identiques");
        }


        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeleteCategorieTest_OK()
        {
            Categorie user = new Categorie()
            {
                CategorieNom = "Test" + DateTime.UtcNow.ToString()
            };

            _context.Categorie.Add(user);
            _context.SaveChanges();

            int id = _context.Categorie.Where(u => u.CategorieNom == user.CategorieNom).First().CategorieId;

            var resultDelete = _controller.DeleteCategorie(id).Result;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
            _context.Categorie.Where(u => u.CategorieId == id).First();
        }

    }
}