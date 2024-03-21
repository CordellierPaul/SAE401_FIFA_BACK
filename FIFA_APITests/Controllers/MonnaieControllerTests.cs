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
    public class MonnaieControllerTests
    {
        private FifaDbContext _context;
        private MonnaieController _controller;
        private IDataRepository<Monnaie> _dataRepository;

        public MonnaieControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new MonnaieManager(_context);
            _controller = new MonnaieController(_dataRepository);
        }


        [TestMethod()]
        public void MonnaieControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetMonnaiesTest_OK()
        {
            var expected = _context.Monnaie.ToList();

            var results = _controller.GetMonnaie().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetMonnaieByIdTest_OK()
        {
            Monnaie expected = _context.Monnaie.Where(u => u.MonnaieId == 1).First();

            var result = _controller.GetMonnaieById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Monnaies");
        }



        [TestMethod()]
        public void GetMonnaieByIdTest_NONOK()
        {
            var result = _controller.GetMonnaieById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutMonnaieTest_OK()
        {
            Monnaie expected = _context.Monnaie.Where(u => u.MonnaieId == 1).First();
            expected.MonnaieNom = "Test";

            var result = _controller.PutMonnaie(1, expected).Result;
            Monnaie resultMonnaie = _controller.GetMonnaieById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultMonnaie, "Pas les mêmes Monnaies");
        }*/
        /*
                [TestMethod]
                public void PostMonnaieTest_OK()
                {
                    // Arrange
                    Monnaie monAtester = new Monnaie()
                    {
                        MonnaieNom = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostMonnaie(monAtester).Result;

                    // Assert
                    Monnaie? monRecupere = _context.Monnaie.Where(u => u.MonnaieNom.ToUpper() == monAtester.MonnaieNom.ToUpper()).FirstOrDefault();

                    monAtester.MonnaieId = monRecupere.MonnaieId;

                    Assert.AreEqual(monRecupere, monAtester, "Monnaies pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteMonnaieTest_OK()
                {
                    Monnaie mon = new Monnaie()
                    {
                        MonnaieNom = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Monnaie.Add(mon);
                    _context.SaveChanges();

                    int id = _context.Monnaie.Where(u => u.MonnaieNom == mon.MonnaieNom).First().MonnaieId;

                    var resultDelete = _controller.DeleteMonnaie(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Monnaie.Where(u => u.MonnaieId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostMonnaie_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Monnaie>>();
            var monController = new MonnaieController(mockRepository.Object);
            Monnaie mon = new Monnaie
            {
                MonnaieNom = "Test"
            };
            // Act
            var actionResult = monController.PostMonnaie(mon).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Monnaie>), "Pas un ActionResult<Monnaie>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Monnaie), "Pas un Monnaie");
            mon.MonnaieId = ((Monnaie)result.Value).MonnaieId;
            Assert.AreEqual(mon, (Monnaie)result.Value, "Monnaies pas identiques");
        }

        [TestMethod]
        public void DeleteMonnaie_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Monnaie mon = new Monnaie
            {
                MonnaieId = 1,
                MonnaieNom = "Test"
            };
            var mockRepository = new Mock<IDataRepository<Monnaie>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(mon);
            var monController = new MonnaieController(mockRepository.Object);
            // Act
            var actionResult = monController.DeleteMonnaie(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutMonnaieTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Monnaie mon = new Monnaie
            {
                MonnaieId = 1,
                MonnaieNom = "Test"
            };
            Monnaie monModif = new Monnaie
            {
                MonnaieId = 1,
                MonnaieNom = "Update"
            };

            var mockRepository = new Mock<IDataRepository<Monnaie>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(mon);
            var monController = new MonnaieController(mockRepository.Object);

            // Act
            var actionResult = monController.PutMonnaie(1, monModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetMonnaieById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Monnaie mon = new Monnaie
            {
                MonnaieId = 1,
                MonnaieNom = "Testgetidmoq"
            };

            var mockRepository = new Mock<IDataRepository<Monnaie>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(mon);
            var monController = new MonnaieController(mockRepository.Object);

            // Act
            var actionResult = monController.GetMonnaieById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(mon, actionResult.Value as Monnaie);
        }

        [TestMethod]
        public void GetMonnaieById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Monnaie>>();
            var monController = new MonnaieController(mockRepository.Object);
            // Act
            var actionResult = monController.GetMonnaieById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}