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
    public class GenreControllerTests
    {
        private FifaDbContext _context;
        private GenreController _controller;
        private IDataRepository<Genre> _dataRepository;

        public GenreControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new GenreManager(_context);
            _controller = new GenreController(_dataRepository);
        }


        [TestMethod()]
        public void GenreControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetGenresTest_OK()
        {
            var expected = _context.Genre.ToList();

            var results = _controller.GetGenre().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetGenreByIdTest_OK()
        {
            Genre expected = _context.Genre.Where(u => u.GenreId == 1).First();

            var result = _controller.GetGenreById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Genres");
        }



        [TestMethod()]
        public void GetGenreByIdTest_NONOK()
        {
            var result = _controller.GetGenreById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutGenreTest_OK()
        {
            Genre expected = _context.Genre.Where(u => u.GenreId == 1).First();
            expected.GenreNom = "Test";

            var result = _controller.PutGenre(1, expected).Result;
            Genre resultGenre = _controller.GetGenreById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultGenre, "Pas les mêmes Genres");
        }*/
        /*
                [TestMethod]
                public void PostGenreTest_OK()
                {
                    // Arrange
                    Genre genAtester = new Genre()
                    {
                        GenreNom = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostGenre(genAtester).Result;

                    // Assert
                    Genre? genRecupere = _context.Genre.Where(u => u.GenreNom.ToUpper() == genAtester.GenreNom.ToUpper()).FirstOrDefault();

                    genAtester.GenreId = genRecupere.GenreId;

                    Assert.AreEqual(genRecupere, genAtester, "Genres pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteGenreTest_OK()
                {
                    Genre gen = new Genre()
                    {
                        GenreNom = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Genre.Add(gen);
                    _context.SaveChanges();

                    int id = _context.Genre.Where(u => u.GenreNom == gen.GenreNom).First().GenreId;

                    var resultDelete = _controller.DeleteGenre(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Genre.Where(u => u.GenreId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostGenre_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Genre>>();
            var genController = new GenreController(mockRepository.Object);
            Genre gen = new Genre
            {
                GenreNom = "Test"
            };
            // Act
            var actionResult = genController.PostGenre(gen).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Genre>), "Pas un ActionResult<Genre>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Genre), "Pas un Genre");
            gen.GenreId = ((Genre)result.Value).GenreId;
            Assert.AreEqual(gen, (Genre)result.Value, "Genres pas identiques");
        }

        [TestMethod]
        public void DeleteGenre_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Genre gen = new Genre
            {
                GenreId = 1,
                GenreNom = "Test"
            };
            var mockRepository = new Mock<IDataRepository<Genre>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(gen);
            var genController = new GenreController(mockRepository.Object);
            // Act
            var actionResult = genController.DeleteGenre(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutGenreTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Genre gen = new Genre
            {
                GenreId = 1,
                GenreNom = "Test"
            };
            Genre genModif = new Genre
            {
                GenreId = 1,
                GenreNom = "Update"
            };

            var mockRepository = new Mock<IDataRepository<Genre>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(gen);
            var genController = new GenreController(mockRepository.Object);

            // Act
            var actionResult = genController.PutGenre(1, genModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetGenreById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Genre gen = new Genre
            {
                GenreId = 1,
                GenreNom = "Testgetidmoq"
            };

            var mockRepository = new Mock<IDataRepository<Genre>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(gen);
            var genController = new GenreController(mockRepository.Object);

            // Act
            var actionResult = genController.GetGenreById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(gen, actionResult.Value as Genre);
        }

        [TestMethod]
        public void GetGenreById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Genre>>();
            var genController = new GenreController(mockRepository.Object);
            // Act
            var actionResult = genController.GetGenreById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}