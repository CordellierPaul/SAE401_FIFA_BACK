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
    public class ColorisControllerTests
    {
        private FifaDbContext _context;
        private ColorisController _controller;
        private IColorisRepository _dataRepository;

        public ColorisControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new ColorisManager(_context);
            _controller = new ColorisController(_dataRepository);
        }


        [TestMethod()]
        public void ColorisControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetColorissTest_OK()
        {
            var expected = _context.Coloris.ToList();

            var results = _controller.GetColoris().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetColorisByIdTest_OK()
        {
            Coloris expected = _context.Coloris.Where(u => u.ColorisId == 1).First();

            var result = _controller.GetColorisById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Coloriss");
        }



        [TestMethod()]
        public void GetColorisByIdTest_NONOK()
        {
            var result = _controller.GetColorisById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutColorisTest_OK()
        {
            Coloris expected = _context.Coloris.Where(u => u.ColorisId == 1).First();
            expected.ColorisNom = "Test";

            var result = _controller.PutColoris(1, expected).Result;
            Coloris resultColoris = _controller.GetColorisById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultColoris, "Pas les mêmes Coloriss");
        }*/
        /*
                [TestMethod]
                public void PostColorisTest_OK()
                {
                    // Arrange
                    Coloris clrAtester = new Coloris()
                    {
                        ColorisNom = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostColoris(clrAtester).Result;

                    // Assert
                    Coloris? clrRecupere = _context.Coloris.Where(u => u.ColorisNom.ToUpper() == clrAtester.ColorisNom.ToUpper()).FirstOrDefault();

                    clrAtester.ColorisId = clrRecupere.ColorisId;

                    Assert.AreEqual(clrRecupere, clrAtester, "Coloriss pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteColorisTest_OK()
                {
                    Coloris clr = new Coloris()
                    {
                        ColorisNom = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Coloris.Add(clr);
                    _context.SaveChanges();

                    int id = _context.Coloris.Where(u => u.ColorisNom == clr.ColorisNom).First().ColorisId;

                    var resultDelete = _controller.DeleteColoris(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Coloris.Where(u => u.ColorisId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostColoris_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IColorisRepository>();
            var clrController = new ColorisController(mockRepository.Object);
            Coloris clr = new Coloris
            {
                ColorisNom = "Test"
            };
            // Act
            var actionResult = clrController.PostColoris(clr).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Coloris>), "Pas un ActionResult<Coloris>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Coloris), "Pas un Coloris");
            clr.ColorisId = ((Coloris)result.Value).ColorisId;
            Assert.AreEqual(clr, (Coloris)result.Value, "Coloriss pas identiques");
        }

        [TestMethod]
        public void DeleteColoris_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Coloris clr = new Coloris
            {
                ColorisId = 1,
                ColorisNom = "Test"
            };
            var mockRepository = new Mock<IColorisRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(clr);
            var clrController = new ColorisController(mockRepository.Object);
            // Act
            var actionResult = clrController.DeleteColoris(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutColorisTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Coloris clr = new Coloris
            {
                ColorisId = 1,
                ColorisNom = "Test"
            };
            Coloris clrModif = new Coloris
            {
                ColorisId = 1,
                ColorisNom = "Update"
            };

            var mockRepository = new Mock<IColorisRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(clr);
            var clrController = new ColorisController(mockRepository.Object);

            // Act
            var actionResult = clrController.PutColoris(1, clrModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetColorisById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Coloris clr = new Coloris
            {
                ColorisId = 1,
                ColorisNom = "Testgetidmoq"
            };

            var mockRepository = new Mock<IColorisRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(clr);
            var clrController = new ColorisController(mockRepository.Object);

            // Act
            var actionResult = clrController.GetColorisById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(clr, actionResult.Value as Coloris);
        }

        [TestMethod]
        public void GetColorisById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IColorisRepository>();
            var clrController = new ColorisController(mockRepository.Object);
            // Act
            var actionResult = clrController.GetColorisById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}