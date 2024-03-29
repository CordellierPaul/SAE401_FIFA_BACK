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
    public class PaysControllerTests
    {
        private FifaDbContext _context;
        private PaysController _controller;
        private IPaysRepository _dataRepository;

        public PaysControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new PaysManager(_context);
            _controller = new PaysController(_dataRepository);
        }


        [TestMethod()]
        public void PaysControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetPayssTest_OK()
        {
            var expected = _context.Pays.ToList();

            var results = _controller.GetPays().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetPaysByIdTest_OK()
        {
            Pays expected = _context.Pays.Where(u => u.PaysId == 1).First();

            var result = _controller.GetPaysById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Payss");
        }



        [TestMethod()]
        public void GetPaysByIdTest_NONOK()
        {
            var result = _controller.GetPaysById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutPaysTest_OK()
        {
            Pays expected = _context.Pays.Where(u => u.PaysId == 1).First();
            expected.PaysNom = "Test";

            var result = _controller.PutPays(1, expected).Result;
            Pays resultPays = _controller.GetPaysById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultPays, "Pas les mêmes Payss");
        }*/
        /*
                [TestMethod]
                public void PostPaysTest_OK()
                {
                    // Arrange
                    Pays paysAtester = new Pays()
                    {
                        PaysNom = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostPays(paysAtester).Result;

                    // Assert
                    Pays? paysRecupere = _context.Pays.Where(u => u.PaysNom.ToUpper() == paysAtester.PaysNom.ToUpper()).FirstOrDefault();

                    paysAtester.PaysId = paysRecupere.PaysId;

                    Assert.AreEqual(paysRecupere, paysAtester, "Payss pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeletePaysTest_OK()
                {
                    Pays pays = new Pays()
                    {
                        PaysNom = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Pays.Add(pays);
                    _context.SaveChanges();

                    int id = _context.Pays.Where(u => u.PaysNom == pays.PaysNom).First().PaysId;

                    var resultDelete = _controller.DeletePays(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Pays.Where(u => u.PaysId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostPays_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IPaysRepository>();
            var paysController = new PaysController(mockRepository.Object);
            Pays pays = new Pays
            {
                PaysNom = "Test"
            };
            // Act
            var actionResult = paysController.PostPays(pays).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Pays>), "Pas un ActionResult<Pays>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Pays), "Pas un Pays");
            pays.PaysId = ((Pays)result.Value).PaysId;
            Assert.AreEqual(pays, (Pays)result.Value, "Payss pas identiques");
        }

        [TestMethod]
        public void DeletePays_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Pays pays = new Pays
            {
                PaysId = 1,
                PaysNom = "Test"
            };
            var mockRepository = new Mock<IPaysRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(pays);
            var paysController = new PaysController(mockRepository.Object);
            // Act
            var actionResult = paysController.DeletePays(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutPaysTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Pays pays = new Pays
            {
                PaysId = 1,
                PaysNom = "Test"
            };
            Pays paysModif = new Pays
            {
                PaysId = 1,
                PaysNom = "Update"
            };

            var mockRepository = new Mock<IPaysRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(pays);
            var paysController = new PaysController(mockRepository.Object);

            // Act
            var actionResult = paysController.PutPays(1, paysModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetPaysById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Pays pays = new Pays
            {
                PaysId = 1,
                PaysNom = "Testgetidmoq"
            };

            var mockRepository = new Mock<IPaysRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(pays);
            var paysController = new PaysController(mockRepository.Object);

            // Act
            var actionResult = paysController.GetPaysById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(pays, actionResult.Value as Pays);
        }

        [TestMethod]
        public void GetPaysById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IPaysRepository>();
            var paysController = new PaysController(mockRepository.Object);
            // Act
            var actionResult = paysController.GetPaysById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }

        [TestMethod]
        public void GetStockByVarianteIds_ExistingIdsPassed_ReturnsRightItems_AvecMoq()
        {
            // Arrange
            List<Pays> lesPays = new List<Pays>();
            Produit p = new Produit
            {
                ProduitId = 1,
                ProduitNom = "ProduitMoq",
                ProduitDescription = "Description du produit moq, utile uniquement dans ce test.",
                PaysId = 1,
            };
            Pays pays = new Pays
            {
                PaysId = 1,
                PaysNom = "TestMoqPays",
                ProduitsPays = new Produit[] { p },
            };
            lesPays.Append(pays);

            var mockRepository = new Mock<IPaysRepository>();
            mockRepository.Setup(x => x.GetPaysWhereProduitExists().Result).Returns(lesPays);
            var stkController = new PaysController(mockRepository.Object);

            // Act
            var actionResult = stkController.GetPaysWhereProduitExists().Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(lesPays, actionResult.Value as IEnumerable<Pays>);
        }


        #endregion
    }
}