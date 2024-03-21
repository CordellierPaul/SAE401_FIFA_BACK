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
    public class VilleControllerTests
    {
        private FifaDbContext _context;
        private VilleController _controller;
        private IDataRepository<Ville> _dataRepository;

        public VilleControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new VilleManager(_context);
            _controller = new VilleController(_dataRepository);
        }


        [TestMethod()]
        public void VilleControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetVillesTest_OK()
        {
            var expected = _context.Ville.ToList();

            var results = _controller.GetVille().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetVilleByIdTest_OK()
        {
            Ville expected = _context.Ville.Where(u => u.VilleId == 1).First();

            var result = _controller.GetVilleById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Villes");
        }



        [TestMethod()]
        public void GetVilleByIdTest_NONOK()
        {
            var result = _controller.GetVilleById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutVilleTest_OK()
        {
            Ville expected = _context.Ville.Where(u => u.VilleId == 1).First();
            expected.VilleNom = "Test";

            var result = _controller.PutVille(1, expected).Result;
            Ville resultVille = _controller.GetVilleById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultVille, "Pas les mêmes Villes");
        }*/
        /*
                [TestMethod]
                public void PostVilleTest_OK()
                {
                    // Arrange
                    Ville vilAtester = new Ville()
                    {
                        VilleNom = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostVille(vilAtester).Result;

                    // Assert
                    Ville? vilRecupere = _context.Ville.Where(u => u.VilleNom.ToUpper() == vilAtester.VilleNom.ToUpper()).FirstOrDefault();

                    vilAtester.VilleId = vilRecupere.VilleId;

                    Assert.AreEqual(vilRecupere, vilAtester, "Villes pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteVilleTest_OK()
                {
                    Ville vil = new Ville()
                    {
                        VilleNom = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Ville.Add(vil);
                    _context.SaveChanges();

                    int id = _context.Ville.Where(u => u.VilleNom == vil.VilleNom).First().VilleId;

                    var resultDelete = _controller.DeleteVille(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Ville.Where(u => u.VilleId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostVille_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Ville>>();
            var vilController = new VilleController(mockRepository.Object);
            Ville vil = new Ville
            {
                VilleNom = "Test"
            };
            // Act
            var actionResult = vilController.PostVille(vil).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Ville>), "Pas un ActionResult<Ville>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Ville), "Pas un Ville");
            vil.VilleId = ((Ville)result.Value).VilleId;
            Assert.AreEqual(vil, (Ville)result.Value, "Villes pas identiques");
        }

        [TestMethod]
        public void DeleteVille_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Ville vil = new Ville
            {
                VilleId = 1,
                VilleNom = "Test"
            };
            var mockRepository = new Mock<IDataRepository<Ville>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(vil);
            var vilController = new VilleController(mockRepository.Object);
            // Act
            var actionResult = vilController.DeleteVille(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutVilleTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Ville vil = new Ville
            {
                VilleId = 1,
                VilleNom = "Test"
            };
            Ville vilModif = new Ville
            {
                VilleId = 1,
                VilleNom = "Update"
            };

            var mockRepository = new Mock<IDataRepository<Ville>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(vil);
            var vilController = new VilleController(mockRepository.Object);

            // Act
            var actionResult = vilController.PutVille(1, vilModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetVilleById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Ville vil = new Ville
            {
                VilleId = 1,
                VilleNom = "Testgetidmoq"
            };

            var mockRepository = new Mock<IDataRepository<Ville>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(vil);
            var vilController = new VilleController(mockRepository.Object);

            // Act
            var actionResult = vilController.GetVilleById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(vil, actionResult.Value as Ville);
        }

        [TestMethod]
        public void GetVilleById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Ville>>();
            var vilController = new VilleController(mockRepository.Object);
            // Act
            var actionResult = vilController.GetVilleById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}