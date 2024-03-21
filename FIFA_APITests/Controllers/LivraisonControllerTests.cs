using Microsoft.VisualStudio.TestTools.UnitTesting;
using FIFA_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIFA_API.Models.DataManager;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FIFA_API.Controllers.Tests
{
    [TestClass()]
    public class LivraisonControllerTests
    {
        private FifaDbContext _context;
        private LivraisonController _controller;
        private IDataRepository<Livraison> _dataRepository;

        public LivraisonControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new LivraisonManager(_context);
            _controller = new LivraisonController(_dataRepository);
        }


        [TestMethod()]
        public void LivraisonControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetLivraisonsTest_OK()
        {
            var expected = _context.Livraison.ToList();

            var results = _controller.GetLivraison().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetLivraisonByIdTest_OK()
        {
            Livraison expected = _context.Livraison.Where(u => u.LivraisonId == 1).First();

            var result = _controller.GetLivraisonById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Livraisons");
        }



        [TestMethod()]
        public void GetLivraisonByIdTest_NONOK()
        {
            var result = _controller.GetLivraisonById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutLivraisonTest_OK()
        {
            Livraison expected = _context.Livraison.Where(u => u.LivraisonId == 1).First();
            expected.LivraisonType = "Test";

            var result = _controller.PutLivraison(1, expected).Result;
            Livraison resultLivraison = _controller.GetLivraisonById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultLivraison, "Pas les mêmes Livraisons");
        }*/
        /*
                [TestMethod]
                public void PostLivraisonTest_OK()
                {
                    // Arrange
                    Livraison livAtester = new Livraison()
                    {
                        LivraisonType = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostLivraison(livAtester).Result;

                    // Assert
                    Livraison? livRecupere = _context.Livraison.Where(u => u.LivraisonType.ToUpper() == livAtester.LivraisonType.ToUpper()).FirstOrDefault();

                    livAtester.LivraisonId = livRecupere.LivraisonId;

                    Assert.AreEqual(livRecupere, livAtester, "Livraisons pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteLivraisonTest_OK()
                {
                    Livraison liv = new Livraison()
                    {
                        LivraisonType = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Livraison.Add(liv);
                    _context.SaveChanges();

                    int id = _context.Livraison.Where(u => u.LivraisonType == liv.LivraisonType).First().LivraisonId;

                    var resultDelete = _controller.DeleteLivraison(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Livraison.Where(u => u.LivraisonId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostLivraison_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Livraison>>();
            var livController = new LivraisonController(mockRepository.Object);
            Livraison liv = new Livraison
            {
                LivraisonType = "Test"
            };
            // Act
            var actionResult = livController.PostLivraison(liv).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Livraison>), "Pas un ActionResult<Livraison>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Livraison), "Pas un Livraison");
            liv.LivraisonId = ((Livraison)result.Value).LivraisonId;
            Assert.AreEqual(liv, (Livraison)result.Value, "Livraisons pas identiques");
        }

        [TestMethod]
        public void DeleteLivraison_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Livraison liv = new Livraison
            {
                LivraisonId = 1,
                LivraisonType = "Test"
            };
            var mockRepository = new Mock<IDataRepository<Livraison>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(liv);
            var livController = new LivraisonController(mockRepository.Object);
            // Act
            var actionResult = livController.DeleteLivraison(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutLivraisonTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Livraison liv = new Livraison
            {
                LivraisonId = 1,
                LivraisonType = "Test"
            };
            Livraison livModif = new Livraison
            {
                LivraisonId = 1,
                LivraisonType = "Update"
            };

            var mockRepository = new Mock<IDataRepository<Livraison>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(liv);
            var livController = new LivraisonController(mockRepository.Object);

            // Act
            var actionResult = livController.PutLivraison(1, livModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetLivraisonById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Livraison liv = new Livraison
            {
                LivraisonId = 1,
                LivraisonType = "Testgetidmoq"
            };

            var mockRepository = new Mock<IDataRepository<Livraison>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(liv);
            var livController = new LivraisonController(mockRepository.Object);

            // Act
            var actionResult = livController.GetLivraisonById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(liv, actionResult.Value as Livraison);
        }

        [TestMethod]
        public void GetLivraisonById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Livraison>>();
            var livController = new LivraisonController(mockRepository.Object);
            // Act
            var actionResult = livController.GetLivraisonById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}