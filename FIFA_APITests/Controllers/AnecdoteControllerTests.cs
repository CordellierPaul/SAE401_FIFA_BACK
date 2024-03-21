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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FIFA_API.Controllers.Tests
{
    [TestClass()]
    public class AnecdoteControllerTests
    {
        private FifaDbContext _context;
        private AnecdoteController _controller;
        private IDataRepository<Anecdote> _dataRepository;

        public AnecdoteControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new AnecdoteManager(_context);
            _controller = new AnecdoteController(_dataRepository);
        }


        [TestMethod()]
        public void AnecdoteControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetAnecdotesTest_OK()
        {
            var expected = _context.Anecdote.ToList();

            var results = _controller.GetAnecdote().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetAnecdoteByIdTest_OK()
        {
            Anecdote expected = _context.Anecdote.Where(u => u.AnecdoteId == 1).First();

            var result = _controller.GetAnecdoteById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Anecdotes");
        }



        [TestMethod()]
        public void GetAnecdoteByIdTest_NONOK()
        {
            var result = _controller.GetAnecdoteById(0).Result;

            Assert.IsNull(result.Value);
        }

        [TestMethod()]
        public void PutAnecdoteTest_OK()
        {
            Anecdote expected = _context.Anecdote.Where(u => u.AnecdoteId == 1).First();
            expected.AnecdoteReponse = "Test";

            var result = _controller.PutAnecdote(1, expected).Result;
            Anecdote resultUser = _controller.GetAnecdoteById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultUser, "Pas les mêmes Anecdotes");
        }
        /*
                [TestMethod]
                public void PostAnecdoteTest_OK()
                {
                    // Arrange
                    Anecdote albAtester = new Anecdote()
                    {
                        AnecdoteReponse = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostAnecdote(albAtester).Result;

                    // Assert
                    Anecdote? albRecupere = _context.Anecdote.Where(u => u.AnecdoteReponse.ToUpper() == albAtester.AnecdoteReponse.ToUpper()).FirstOrDefault();

                    albAtester.AnecdoteId = albRecupere.AnecdoteId;

                    Assert.AreEqual(albRecupere, albAtester, "Anecdotes pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteAnecdoteTest_OK()
                {
                    Anecdote user = new Anecdote()
                    {
                        AnecdoteReponse = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Anecdote.Add(user);
                    _context.SaveChanges();

                    int id = _context.Anecdote.Where(u => u.AnecdoteReponse == user.AnecdoteReponse).First().AnecdoteId;

                    var resultDelete = _controller.DeleteAnecdote(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Anecdote.Where(u => u.AnecdoteId == id).First();
                }*/


        #region Test moq

        [TestMethod]
        public void PostAnecdote_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Anecdote>>();
            var albController = new AnecdoteController(mockRepository.Object);
            Anecdote alb = new Anecdote
            {
                AnecdoteReponse = "Test"
            };
            // Act
            var actionResult = albController.PostAnecdote(alb).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Anecdote>), "Pas un ActionResult<Anecdote>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Anecdote), "Pas un Anecdote");
            alb.AnecdoteId = ((Anecdote)result.Value).AnecdoteId;
            Assert.AreEqual(alb, (Anecdote)result.Value, "Anecdotes pas identiques");
        }

        [TestMethod]
        public void DeleteAnecdote_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Anecdote alb = new Anecdote
            {
                AnecdoteId = 1,
                AnecdoteReponse = "Test"
            };
            var mockRepository = new Mock<IDataRepository<Anecdote>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(alb);
            var albController = new AnecdoteController(mockRepository.Object);
            // Act
            var actionResult = albController.DeleteAnecdote(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutAnecdoteTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Anecdote alb = new Anecdote
            {
                AnecdoteId = 1,
                AnecdoteReponse = "Test"
            };
            Anecdote albModif = new Anecdote
            {
                AnecdoteId = 1,
                AnecdoteReponse = "Update"
            };

            var mockRepository = new Mock<IDataRepository<Anecdote>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(alb);
            var albController = new AnecdoteController(mockRepository.Object);

            // Act
            var actionResult = albController.PutAnecdote(1, albModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetAnecdoteById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Anecdote alb = new Anecdote
            {
                AnecdoteId = 1,
                AnecdoteReponse = "Testgetidmoq"
            };

            var mockRepository = new Mock<IDataRepository<Anecdote>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(alb);
            var albController = new AnecdoteController(mockRepository.Object);

            // Act
            var actionResult = albController.GetAnecdoteById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(alb, actionResult.Value as Anecdote);
        }

        [TestMethod]
        public void GetAnecdoteById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Anecdote>>();
            var albController = new AnecdoteController(mockRepository.Object);
            // Act
            var actionResult = albController.GetAnecdoteById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}