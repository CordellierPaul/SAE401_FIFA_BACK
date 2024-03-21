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
    public class PosteControllerTests
    {
        private FifaDbContext _context;
        private PosteController _controller;
        private IDataRepository<Poste> _dataRepository;

        public PosteControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new PosteManager(_context);
            _controller = new PosteController(_dataRepository);
        }


        [TestMethod()]
        public void PosteControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetPostesTest_OK()
        {
            var expected = _context.Poste.ToList();

            var results = _controller.GetPoste().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetPosteByIdTest_OK()
        {
            Poste expected = _context.Poste.Where(u => u.PosteId == 1).First();

            var result = _controller.GetPosteById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Postes");
        }



        [TestMethod()]
        public void GetPosteByIdTest_NONOK()
        {
            var result = _controller.GetPosteById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutPosteTest_OK()
        {
            Poste expected = _context.Poste.Where(u => u.PosteId == 1).First();
            expected.PosteLibelle = "Test";

            var result = _controller.PutPoste(1, expected).Result;
            Poste resultPoste = _controller.GetPosteById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultPoste, "Pas les mêmes Postes");
        }*/
        /*
                [TestMethod]
                public void PostPosteTest_OK()
                {
                    // Arrange
                    Poste posAtester = new Poste()
                    {
                        PosteLibelle = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostPoste(posAtester).Result;

                    // Assert
                    Poste? posRecupere = _context.Poste.Where(u => u.PosteLibelle.ToUpper() == posAtester.PosteLibelle.ToUpper()).FirstOrDefault();

                    posAtester.PosteId = posRecupere.PosteId;

                    Assert.AreEqual(posRecupere, posAtester, "Postes pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeletePosteTest_OK()
                {
                    Poste pos = new Poste()
                    {
                        PosteLibelle = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Poste.Add(pos);
                    _context.SaveChanges();

                    int id = _context.Poste.Where(u => u.PosteLibelle == pos.PosteLibelle).First().PosteId;

                    var resultDelete = _controller.DeletePoste(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Poste.Where(u => u.PosteId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostPoste_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Poste>>();
            var posController = new PosteController(mockRepository.Object);
            Poste pos = new Poste
            {
                PosteLibelle = "Test"
            };
            // Act
            var actionResult = posController.PostPoste(pos).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Poste>), "Pas un ActionResult<Poste>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Poste), "Pas un Poste");
            pos.PosteId = ((Poste)result.Value).PosteId;
            Assert.AreEqual(pos, (Poste)result.Value, "Postes pas identiques");
        }

        [TestMethod]
        public void DeletePoste_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Poste pos = new Poste
            {
                PosteId = 1,
                PosteLibelle = "Test"
            };
            var mockRepository = new Mock<IDataRepository<Poste>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(pos);
            var posController = new PosteController(mockRepository.Object);
            // Act
            var actionResult = posController.DeletePoste(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutPosteTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Poste pos = new Poste
            {
                PosteId = 1,
                PosteLibelle = "Test"
            };
            Poste posModif = new Poste
            {
                PosteId = 1,
                PosteLibelle = "Update"
            };

            var mockRepository = new Mock<IDataRepository<Poste>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(pos);
            var posController = new PosteController(mockRepository.Object);

            // Act
            var actionResult = posController.PutPoste(1, posModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetPosteById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Poste pos = new Poste
            {
                PosteId = 1,
                PosteLibelle = "Testgetidmoq"
            };

            var mockRepository = new Mock<IDataRepository<Poste>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(pos);
            var posController = new PosteController(mockRepository.Object);

            // Act
            var actionResult = posController.GetPosteById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(pos, actionResult.Value as Poste);
        }

        [TestMethod]
        public void GetPosteById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Poste>>();
            var posController = new PosteController(mockRepository.Object);
            // Act
            var actionResult = posController.GetPosteById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}