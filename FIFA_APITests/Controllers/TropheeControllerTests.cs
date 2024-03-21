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
    public class TropheeControllerTests
    {
        private FifaDbContext _context;
        private TropheeController _controller;
        private IDataRepository<Trophee> _dataRepository;

        public TropheeControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new TropheeManager(_context);
            _controller = new TropheeController(_dataRepository);
        }


        [TestMethod()]
        public void TropheeControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetTropheesTest_OK()
        {
            var expected = _context.Trophee.ToList();

            var results = _controller.GetTrophee().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetTropheeByIdTest_OK()
        {
            Trophee expected = _context.Trophee.Where(u => u.TropheeId == 1).First();

            var result = _controller.GetTropheeById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Trophees");
        }



        [TestMethod()]
        public void GetTropheeByIdTest_NONOK()
        {
            var result = _controller.GetTropheeById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutTropheeTest_OK()
        {
            Trophee expected = _context.Trophee.Where(u => u.TropheeId == 1).First();
            expected.TropheeNom = "Test";

            var result = _controller.PutTrophee(1, expected).Result;
            Trophee resultTrophee = _controller.GetTropheeById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultTrophee, "Pas les mêmes Trophees");
        }*/
        /*
                [TestMethod]
                public void PostTropheeTest_OK()
                {
                    // Arrange
                    Trophee troAtester = new Trophee()
                    {
                        TropheeNom = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostTrophee(troAtester).Result;

                    // Assert
                    Trophee? troRecupere = _context.Trophee.Where(u => u.TropheeNom.ToUpper() == troAtester.TropheeNom.ToUpper()).FirstOrDefault();

                    troAtester.TropheeId = troRecupere.TropheeId;

                    Assert.AreEqual(troRecupere, troAtester, "Trophees pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteTropheeTest_OK()
                {
                    Trophee tro = new Trophee()
                    {
                        TropheeNom = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Trophee.Add(tro);
                    _context.SaveChanges();

                    int id = _context.Trophee.Where(u => u.TropheeNom == tro.TropheeNom).First().TropheeId;

                    var resultDelete = _controller.DeleteTrophee(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Trophee.Where(u => u.TropheeId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostTrophee_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Trophee>>();
            var troController = new TropheeController(mockRepository.Object);
            Trophee tro = new Trophee
            {
                TropheeNom = "Test"
            };
            // Act
            var actionResult = troController.PostTrophee(tro).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Trophee>), "Pas un ActionResult<Trophee>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Trophee), "Pas un Trophee");
            tro.TropheeId = ((Trophee)result.Value).TropheeId;
            Assert.AreEqual(tro, (Trophee)result.Value, "Trophees pas identiques");
        }

        [TestMethod]
        public void DeleteTrophee_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Trophee tro = new Trophee
            {
                TropheeId = 1,
                TropheeNom = "Test"
            };
            var mockRepository = new Mock<IDataRepository<Trophee>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(tro);
            var troController = new TropheeController(mockRepository.Object);
            // Act
            var actionResult = troController.DeleteTrophee(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutTropheeTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Trophee tro = new Trophee
            {
                TropheeId = 1,
                TropheeNom = "Test"
            };
            Trophee troModif = new Trophee
            {
                TropheeId = 1,
                TropheeNom = "Update"
            };

            var mockRepository = new Mock<IDataRepository<Trophee>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(tro);
            var troController = new TropheeController(mockRepository.Object);

            // Act
            var actionResult = troController.PutTrophee(1, troModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetTropheeById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Trophee tro = new Trophee
            {
                TropheeId = 1,
                TropheeNom = "Testgetidmoq"
            };

            var mockRepository = new Mock<IDataRepository<Trophee>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(tro);
            var troController = new TropheeController(mockRepository.Object);

            // Act
            var actionResult = troController.GetTropheeById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(tro, actionResult.Value as Trophee);
        }

        [TestMethod]
        public void GetTropheeById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Trophee>>();
            var troController = new TropheeController(mockRepository.Object);
            // Act
            var actionResult = troController.GetTropheeById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}