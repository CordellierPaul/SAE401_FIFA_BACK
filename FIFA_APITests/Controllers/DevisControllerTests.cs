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
    public class DevisControllerTests
    {
        private FifaDbContext _context;
        private DevisController _controller;
        private IDataRepository<Devis> _dataRepository;

        public DevisControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new DevisManager(_context);
            _controller = new DevisController(_dataRepository);
        }


        [TestMethod()]
        public void DevisControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetDevissTest_OK()
        {
            var expected = _context.Devis.ToList();

            var results = _controller.GetDevis().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetDevisByIdTest_OK()
        {
            Devis expected = _context.Devis.Where(u => u.DevisId == 1).First();

            var result = _controller.GetDevisById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Devis");
        }



        [TestMethod()]
        public void GetDevisByIdTest_NONOK()
        {
            var result = _controller.GetDevisById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutDevisTest_OK()
        {
            Devis expected = _context.Devis.Where(u => u.DevisId == 1).First();
            expected.ProduitDevis = new Produit()

            var result = _controller.PutDevis(1, expected).Result;
            Devis resultDevis = _controller.GetDevisById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultDevis, "Pas les mêmes Deviss");
        }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostDevis_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Devis>>();
            var devController = new DevisController(mockRepository.Object);
            Devis dev = new Devis
            {
                ProduitDevis = new Produit(),
                UtilisateurDevis = new Utilisateur()
            };
            // Act
            var actionResult = devController.PostDevis(dev).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Devis>), "Pas un ActionResult<Devis>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Devis), "Pas un Devis");
            dev.DevisId = ((Devis)result.Value).DevisId;
            Assert.AreEqual(dev, (Devis)result.Value, "Deviss pas identiques");
        }

        [TestMethod]
        public void DeleteDevis_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Devis dev = new Devis
            {
                DevisId = 1,
                ProduitDevis = new Produit(),
                UtilisateurDevis = new Utilisateur()
            };
            var mockRepository = new Mock<IDataRepository<Devis>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(dev);
            var devController = new DevisController(mockRepository.Object);
            // Act
            var actionResult = devController.DeleteDevis(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutDevisTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Devis dev = new Devis
            {
                DevisId = 1,
                ProduitDevis = new Produit(),
                UtilisateurDevis = new Utilisateur()
            };
            Devis devModif = new Devis
            {
                DevisId = 1,
                ProduitDevis = new Produit(),
                UtilisateurDevis = new Utilisateur()
            };

            var mockRepository = new Mock<IDataRepository<Devis>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(dev);
            var devController = new DevisController(mockRepository.Object);

            // Act
            var actionResult = devController.PutDevis(1, devModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetDevisById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Devis dev = new Devis
            {
                DevisId = 1,
                ProduitDevis = new Produit(),
                UtilisateurDevis = new Utilisateur()
            };

            var mockRepository = new Mock<IDataRepository<Devis>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(dev);
            var devController = new DevisController(mockRepository.Object);

            // Act
            var actionResult = devController.GetDevisById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(dev, actionResult.Value as Devis);
        }

        [TestMethod]
        public void GetDevisById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Devis>>();
            var devController = new DevisController(mockRepository.Object);
            // Act
            var actionResult = devController.GetDevisById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}