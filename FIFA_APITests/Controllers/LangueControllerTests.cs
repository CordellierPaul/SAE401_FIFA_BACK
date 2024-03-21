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
    public class LangueControllerTests
    {
        private FifaDbContext _context;
        private LangueController _controller;
        private IDataRepository<Langue> _dataRepository;

        public LangueControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new LangueManager(_context);
            _controller = new LangueController(_dataRepository);
        }


        [TestMethod()]
        public void LangueControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetLanguesTest_OK()
        {
            var expected = _context.Langue.ToList();

            var results = _controller.GetLangue().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetLangueByIdTest_OK()
        {
            Langue expected = _context.Langue.Where(u => u.LangueId == 1).First();

            var result = _controller.GetLangueById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Langues");
        }



        [TestMethod()]
        public void GetLangueByIdTest_NONOK()
        {
            var result = _controller.GetLangueById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutLangueTest_OK()
        {
            Langue expected = _context.Langue.Where(u => u.LangueId == 1).First();
            expected.LangueNom = "Test";

            var result = _controller.PutLangue(1, expected).Result;
            Langue resultLangue = _controller.GetLangueById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultLangue, "Pas les mêmes Langues");
        }*/
        /*
                [TestMethod]
                public void PostLangueTest_OK()
                {
                    // Arrange
                    Langue blgAtester = new Langue()
                    {
                        LangueNom = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostLangue(blgAtester).Result;

                    // Assert
                    Langue? blgRecupere = _context.Langue.Where(u => u.LangueNom.ToUpper() == blgAtester.LangueNom.ToUpper()).FirstOrDefault();

                    blgAtester.LangueId = blgRecupere.LangueId;

                    Assert.AreEqual(blgRecupere, blgAtester, "Langues pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteLangueTest_OK()
                {
                    Langue blg = new Langue()
                    {
                        LangueNom = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Langue.Add(blg);
                    _context.SaveChanges();

                    int id = _context.Langue.Where(u => u.LangueNom == blg.LangueNom).First().LangueId;

                    var resultDelete = _controller.DeleteLangue(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Langue.Where(u => u.LangueId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostLangue_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Langue>>();
            var blgController = new LangueController(mockRepository.Object);
            Langue blg = new Langue
            {
                LangueNom = "Test"
            };
            // Act
            var actionResult = blgController.PostLangue(blg).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Langue>), "Pas un ActionResult<Langue>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Langue), "Pas un Langue");
            blg.LangueId = ((Langue)result.Value).LangueId;
            Assert.AreEqual(blg, (Langue)result.Value, "Langues pas identiques");
        }

        [TestMethod]
        public void DeleteLangue_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Langue blg = new Langue
            {
                LangueId = 1,
                LangueNom = "Test"
            };
            var mockRepository = new Mock<IDataRepository<Langue>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(blg);
            var blgController = new LangueController(mockRepository.Object);
            // Act
            var actionResult = blgController.DeleteLangue(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutLangueTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Langue blg = new Langue
            {
                LangueId = 1,
                LangueNom = "Test"
            };
            Langue blgModif = new Langue
            {
                LangueId = 1,
                LangueNom = "Update"
            };

            var mockRepository = new Mock<IDataRepository<Langue>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(blg);
            var blgController = new LangueController(mockRepository.Object);

            // Act
            var actionResult = blgController.PutLangue(1, blgModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetLangueById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Langue blg = new Langue
            {
                LangueId = 1,
                LangueNom = "Testgetidmoq"
            };

            var mockRepository = new Mock<IDataRepository<Langue>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(blg);
            var blgController = new LangueController(mockRepository.Object);

            // Act
            var actionResult = blgController.GetLangueById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(blg, actionResult.Value as Langue);
        }

        [TestMethod]
        public void GetLangueById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Langue>>();
            var blgController = new LangueController(mockRepository.Object);
            // Act
            var actionResult = blgController.GetLangueById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}