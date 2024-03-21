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
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FIFA_API.Controllers.Tests
{
    [TestClass()]
    public class ActiviteControllerTests
    {
        private FifaDbContext _context;
        private ActiviteController _controller;
        private IDataRepository<Activite> _dataRepository;

        public ActiviteControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=localhost;port=5432;Database=FifaDB; uid=postgres; password=postgres;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new ActiviteManager(_context);
            _controller = new ActiviteController(_dataRepository);
        }


        [TestMethod()]
        public void ActiviteControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetActiviteTest_OK()
        {
            var expected = _context.Activite.ToList();

            var results = _controller.GetActivite().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetActiviteByIdTest_OK()
        {
            Activite expected = _context.Activite.Where(u => u.ActiviteId == 1).First();

            var result = _controller.GetActiviteById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes activites");
        }

        [TestMethod()]
        public void GetActiviteByIdTest_NONOK()
        {
            var result = _controller.GetActiviteById(0).Result;

            Assert.IsNull(result.Value);
        }

        [TestMethod()]
        public void PutActiviteTest_OK()
        {
            Activite expected = _context.Activite.Where(u => u.ActiviteId == 1).First();
            expected.ActiviteNom = "Test";

            var result = _controller.PutActivite(1, expected).Result;
            Activite resultUser = _controller.GetActiviteById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultUser, "Pas les mêmes activites");
        }



        #region Test moq

        [TestMethod]
        public void PostActivite_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Activite>>();
            var catController = new ActiviteController(mockRepository.Object);
            Activite act = new Activite
            {
                ActiviteNom = "Testgetidmoq"
            };
            // Act
            var actionResult = catController.PostActivite(act).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Activite>), "Pas un ActionResult<Activite>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Activite), "Pas un activite");
            act.ActiviteId = ((Activite)result.Value).ActiviteId;
            Assert.AreEqual(act, (Activite)result.Value, "activites pas identiques");
        }

        [TestMethod]
        public void DeleteActivite_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Activite act = new Activite
            {
                ActiviteId = 1,
                ActiviteNom = "Test"
            };
            var mockRepository = new Mock<IDataRepository<Activite>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(act);
            var actController = new ActiviteController(mockRepository.Object);
            // Act
            var actionResult = actController.DeleteActivite(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutActiviteTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Activite act = new Activite
            {
                ActiviteId = 1,
                ActiviteNom = "Testputmoq"
            };
            Activite actModif = new Activite
            {
                ActiviteId = 1,
                ActiviteNom = "Update"
            };

            var mockRepository = new Mock<IDataRepository<Activite>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(act);
            var catController = new ActiviteController(mockRepository.Object);

            // Act
            var actionResult = catController.PutActivite(1, actModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        /*[TestMethod]
        public void GetCategorieByNom_PutOK_AvecMoq()
        {
            // Arrange
            Activite act = new Activite
            {
                ActiviteId = 1,
                ActiviteNom = "Testgputidmoq"
            };

            var mockRepository = new Mock<IDataRepository<Activite>>();
            mockRepository.Setup(x => x.GetByStringAsync("Testputmoq").Result).Returns(act);
            var catController = new ActiviteController(mockRepository.Object);

            // Act
            var actionResult = catController.GetActiviteNom("Testputmoq").Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(act, actionResult.Value as Activite);
        }*/

        [TestMethod]
        public void GetActiviteById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Activite act = new Activite
            {
                ActiviteId = 1,
                ActiviteNom = "Testgetidmoq"
            };

            var mockRepository = new Mock<IDataRepository<Activite>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(act);
            var actController = new ActiviteController(mockRepository.Object);

            // Act
            var actionResult = actController.GetActiviteById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(act, actionResult.Value as Activite);
        }

        [TestMethod]
        public void GetActiviteById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Activite>>();
            var actController = new ActiviteController(mockRepository.Object);
            // Act
            var actionResult = actController.GetActiviteById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}