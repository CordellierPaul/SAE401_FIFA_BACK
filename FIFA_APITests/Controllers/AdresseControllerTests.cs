using Microsoft.VisualStudio.TestTools.UnitTesting;
using FIFA_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using FIFA_API.Models.DataManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace FIFA_API.Controllers.Tests
{
    [TestClass()]
    public class AdresseControllerTests
    {
        private FifaDbContext _context;
        private AdresseController _controller;
        private IDataRepository<Adresse> _dataRepository;

        public AdresseControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=localhost;port=5432;Database=FifaDB; uid=postgres; password=postgres;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new AdresseManager(_context);
            _controller = new AdresseController(_dataRepository);
        }


        [TestMethod()]
        public void AdresseControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetAdresseTest_OK()
        {
            var expected = _context.Adresse.ToList();

            var results = _controller.GetAdresse().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetAdresseByIdTest_OK()
        {
            Adresse expected = _context.Adresse.Where(u => u.AdresseId == 1).First();

            var result = _controller.GetAdresseById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Adresses");
        }



        [TestMethod()]
        public void GetAdresseByIdTest_NONOK()
        {
            var result = _controller.GetAdresseById(0).Result;

            Assert.IsNull(result.Value);
        }

        [TestMethod()]
        public void PutAdresseTest_OK()
        {
            Adresse expected = _context.Adresse.Where(u => u.AdresseId == 1).First();
            expected.AdresseRue = "Test";

            var result = _controller.PutAdresse(1, expected).Result;
            Adresse resultUser = _controller.GetAdresseById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultUser, "Pas les mêmes Adresses");
        }

        #region Test moq

        [TestMethod]
        public void PostAdresse_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Adresse>>();
            var catController = new AdresseController(mockRepository.Object);
            Adresse cat = new Adresse
            {
                AdresseRue = "Test"
            };
            // Act
            var actionResult = catController.PostAdresse(cat).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Adresse>), "Pas un ActionResult<Adresse>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Adresse), "Pas un Adresse");
            cat.AdresseId = ((Adresse)result.Value).AdresseId;
            Assert.AreEqual(cat, (Adresse)result.Value, "Adresses pas identiques");
        }

        [TestMethod]
        public void DeleteAdresse_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Adresse cat = new Adresse
            {
                AdresseId = 1,
                AdresseRue = "Test"
            };
            var mockRepository = new Mock<IDataRepository<Adresse>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(cat);
            var catController = new AdresseController(mockRepository.Object);
            // Act
            var actionResult = catController.DeleteAdresse(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutAdresseTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Adresse cat = new Adresse
            {
                AdresseId = 1,
                AdresseRue = "Test"
            };
            Adresse catModif = new Adresse
            {
                AdresseId = 1,
                AdresseRue = "Update"
            };

            var mockRepository = new Mock<IDataRepository<Adresse>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(cat);
            var catController = new AdresseController(mockRepository.Object);

            // Act
            var actionResult = catController.PutAdresse(1, catModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetAdresseById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Adresse cat = new Adresse
            {
                AdresseId = 1,
                AdresseRue = "Testgetidmoq"
            };

            var mockRepository = new Mock<IDataRepository<Adresse>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(cat);
            var catController = new AdresseController(mockRepository.Object);

            // Act
            var actionResult = catController.GetAdresseById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(cat, actionResult.Value as Adresse);
        }

        [TestMethod]
        public void GetAdresseById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Adresse>>();
            var catController = new AdresseController(mockRepository.Object);
            // Act
            var actionResult = catController.GetAdresseById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}