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
    public class CaracteristiqueControllerTests
    {
        private FifaDbContext _context;
        private CaracteristiqueController _controller;
        private IDataRepository<Caracteristique> _dataRepository;

        public CaracteristiqueControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new CaracteristiqueManager(_context);
            _controller = new CaracteristiqueController(_dataRepository);
        }


        [TestMethod()]
        public void CaracteristiqueControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetCaracteristiquesTest_OK()
        {
            var expected = _context.Caracteristique.ToList();

            var results = _controller.GetCaracteristique().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetCaracteristiqueByIdTest_OK()
        {
            Caracteristique expected = _context.Caracteristique.Where(u => u.CaracteristiqueId == 1).First();

            var result = _controller.GetCaracteristiqueById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Caracteristiques");
        }



        [TestMethod()]
        public void GetCaracteristiqueByIdTest_NONOK()
        {
            var result = _controller.GetCaracteristiqueById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutCaracteristiqueTest_OK()
        {
            Caracteristique expected = _context.Caracteristique.Where(u => u.CaracteristiqueId == 1).First();
            expected.CaracteristiqueNom = "Test";

            var result = _controller.PutCaracteristique(1, expected).Result;
            Caracteristique resultCaracteristique = _controller.GetCaracteristiqueById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultCaracteristique, "Pas les mêmes Caracteristiques");
        }*/
        /*
                [TestMethod]
                public void PostCaracteristiqueTest_OK()
                {
                    // Arrange
                    Caracteristique carAtester = new Caracteristique()
                    {
                        CaracteristiqueNom = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostCaracteristique(carAtester).Result;

                    // Assert
                    Caracteristique? carRecupere = _context.Caracteristique.Where(u => u.CaracteristiqueNom.ToUpper() == carAtester.CaracteristiqueNom.ToUpper()).FirstOrDefault();

                    carAtester.CaracteristiqueId = carRecupere.CaracteristiqueId;

                    Assert.AreEqual(carRecupere, carAtester, "Caracteristiques pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteCaracteristiqueTest_OK()
                {
                    Caracteristique car = new Caracteristique()
                    {
                        CaracteristiqueNom = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Caracteristique.Add(car);
                    _context.SaveChanges();

                    int id = _context.Caracteristique.Where(u => u.CaracteristiqueNom == car.CaracteristiqueNom).First().CaracteristiqueId;

                    var resultDelete = _controller.DeleteCaracteristique(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Caracteristique.Where(u => u.CaracteristiqueId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostCaracteristique_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Caracteristique>>();
            var carController = new CaracteristiqueController(mockRepository.Object);
            Caracteristique car = new Caracteristique
            {
                CaracteristiqueNom = "Test"
            };
            // Act
            var actionResult = carController.PostCaracteristique(car).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Caracteristique>), "Pas un ActionResult<Caracteristique>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Caracteristique), "Pas un Caracteristique");
            car.CaracteristiqueId = ((Caracteristique)result.Value).CaracteristiqueId;
            Assert.AreEqual(car, (Caracteristique)result.Value, "Caracteristiques pas identiques");
        }

        [TestMethod]
        public void DeleteCaracteristique_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Caracteristique car = new Caracteristique
            {
                CaracteristiqueId = 1,
                CaracteristiqueNom = "Test"
            };
            var mockRepository = new Mock<IDataRepository<Caracteristique>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(car);
            var carController = new CaracteristiqueController(mockRepository.Object);
            // Act
            var actionResult = carController.DeleteCaracteristique(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutCaracteristiqueTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Caracteristique car = new Caracteristique
            {
                CaracteristiqueId = 1,
                CaracteristiqueNom = "Test"
            };
            Caracteristique carModif = new Caracteristique
            {
                CaracteristiqueId = 1,
                CaracteristiqueNom = "Update"
            };

            var mockRepository = new Mock<IDataRepository<Caracteristique>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(car);
            var carController = new CaracteristiqueController(mockRepository.Object);

            // Act
            var actionResult = carController.PutCaracteristique(1, carModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetCaracteristiqueById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Caracteristique car = new Caracteristique
            {
                CaracteristiqueId = 1,
                CaracteristiqueNom = "Testgetidmoq"
            };

            var mockRepository = new Mock<IDataRepository<Caracteristique>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(car);
            var carController = new CaracteristiqueController(mockRepository.Object);

            // Act
            var actionResult = carController.GetCaracteristiqueById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(car, actionResult.Value as Caracteristique);
        }

        [TestMethod]
        public void GetCaracteristiqueById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Caracteristique>>();
            var carController = new CaracteristiqueController(mockRepository.Object);
            // Act
            var actionResult = carController.GetCaracteristiqueById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}