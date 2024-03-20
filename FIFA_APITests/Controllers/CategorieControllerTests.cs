using Microsoft.VisualStudio.TestTools.UnitTesting;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using FIFA_API.Models.DataManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

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
/*
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
        }*/


        #region Test moq

        [TestMethod]
        public void PostCategorie_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Categorie>>();
            var catController = new CategorieController(mockRepository.Object);
            Categorie cat = new Categorie
            {
                CategorieNom = "Test"
            };
            // Act
            var actionResult = catController.PostCategorie(cat).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Categorie>), "Pas un ActionResult<Categorie>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Categorie), "Pas un Categorie");
            cat.CategorieId = ((Categorie)result.Value).CategorieId;
            Assert.AreEqual(cat, (Categorie)result.Value, "Categories pas identiques");
        }



        [TestMethod]
        public void DeleteCategorie_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Categorie cat = new Categorie
            {
                CategorieId = 1,
                CategorieNom = "Test"
            };
            var mockRepository = new Mock<IDataRepository<Categorie>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(cat);
            var catController = new CategorieController(mockRepository.Object);
            // Act
            var actionResult = catController.DeleteCategorie(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutCategorieTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Categorie cat = new Categorie
            {
                CategorieId = 1,
                CategorieNom = "Test"
            };
            Categorie catModif = new Categorie
            {
                CategorieId = 1,
                CategorieNom = "Update"
            };

            var mockRepository = new Mock<IDataRepository<Categorie>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(cat);
            var catController = new CategorieController(mockRepository.Object);

            // Act
            var actionResult = catController.PutCategorie(1, catModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetCategorieByNom_PutOK_AvecMoq()
        {
            // Arrange
            Categorie cat = new Categorie
            {
                CategorieId = 1,
                CategorieNom = "Testputmoq"
            };

            var mockRepository = new Mock<IDataRepository<Categorie>>();
            mockRepository.Setup(x => x.GetByStringAsync("Testputmoq").Result).Returns(cat);
            var catController = new CategorieController(mockRepository.Object);

            // Act
            var actionResult = catController.GetCategorieByNom("Testputmoq").Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(cat, actionResult.Value as Categorie);
        }

        [TestMethod]
        public void GetUtilisateurById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Categorie cat = new Categorie
            {
                CategorieId = 1,
                CategorieNom = "Testgetidmoq"
            };

            var mockRepository = new Mock<IDataRepository<Categorie>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(cat);
            var catController = new CategorieController(mockRepository.Object);

            // Act
            var actionResult = catController.GetCategorieById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(cat, actionResult.Value as Categorie);
        }

        [TestMethod]
        public void GetCategorieById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Categorie>>();
            var catController = new CategorieController(mockRepository.Object);
            // Act
            var actionResult = catController.GetCategorieById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }

        [TestMethod]
        public void Postcategorie_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Categorie>>();
            var catController = new CategorieController(mockRepository.Object);

            Categorie cat = new Categorie
            {
                CategorieId = 1,
                CategorieNom = "Testputmoq"
            };

            // Act
            var actionResult = catController.PostCategorie(cat).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Categorie>), "Pas un ActionResult<Utilisateur>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Categorie), "Pas une Categorie");
            cat.CategorieId = ((Categorie)result.Value).CategorieId;
            Assert.AreEqual(cat, (Categorie)result.Value, "Categories pas identiques");
        }


        #endregion

    }
}