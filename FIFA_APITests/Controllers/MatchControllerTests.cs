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
using Match = FIFA_API.Models.EntityFramework.Match;

namespace FIFA_API.Controllers.Tests
{
    [TestClass()]
    public class MatchControllerTests
    {
        private FifaDbContext _context;
        private MatchController _controller;
        private IDataRepositoryWithoutStr<Match> _dataRepository;

        public MatchControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new MatchManager(_context);
            _controller = new MatchController(_dataRepository);
        }


        [TestMethod()]
        public void MatchControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetMatchsTest_OK()
        {
            var expected = _context.Match.ToList();

            var results = _controller.GetMatch().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetMatchByIdTest_OK()
        {
            Match expected = _context.Match.Where(u => u.MatchId == 1).First();

            var result = _controller.GetMatchById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Matchs");
        }



        [TestMethod()]
        public void GetMatchByIdTest_NONOK()
        {
            var result = _controller.GetMatchById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutMatchTest_OK()
        {
            Match expected = _context.Match.Where(u => u.MatchId == 1).First();
            expected.MatchTitre = "Test";

            var result = _controller.PutMatch(1, expected).Result;
            Match resultMatch = _controller.GetMatchById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultMatch, "Pas les mêmes Matchs");
        }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostMatch_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepositoryWithoutStr<Match>>();
            var matController = new MatchController(mockRepository.Object);
            Match mat = new Match
            {
                MatchScoreDomicile = 1,
                MatchDate = DateTime.Now,
                MatchScoreExterieur = 1,
                ClubDomicileId = 2,
                ClubExterieurId = 1,
            };
            // Act
            var actionResult = matController.PostMatch(mat).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Match>), "Pas un ActionResult<Match>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Match), "Pas un Match");
            mat.MatchId = ((Match)result.Value).MatchId;
            Assert.AreEqual(mat, (Match)result.Value, "Matchs pas identiques");
        }

        [TestMethod]
        public void DeleteMatch_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Match mat = new Match
            {
                MatchId = 1,
                MatchScoreDomicile = 1,
                MatchDate = DateTime.Now,
                MatchScoreExterieur = 1,
                ClubDomicileId = 2,
                ClubExterieurId = 1,
            };
            var mockRepository = new Mock<IDataRepositoryWithoutStr<Match>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(mat);
            var matController = new MatchController(mockRepository.Object);
            // Act
            var actionResult = matController.DeleteMatch(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutMatchTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Match mat = new Match
            {
                MatchId = 1,
                MatchScoreDomicile = 1,
                MatchDate = DateTime.Now,
                MatchScoreExterieur = 1,
                ClubDomicileId = 2,
                ClubExterieurId = 1,
            };
            Match matModif = new Match
            {
                MatchId = 1,
                MatchScoreDomicile = 1,
                MatchDate = DateTime.Now,
                MatchScoreExterieur = 10,
                ClubDomicileId = 2,
                ClubExterieurId = 1,
            };

            var mockRepository = new Mock<IDataRepositoryWithoutStr<Match>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(mat);
            var matController = new MatchController(mockRepository.Object);

            // Act
            var actionResult = matController.PutMatch(1, matModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetMatchById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Match mat = new Match
            {
                MatchId = 1,
                MatchScoreDomicile = 1,
                MatchDate = DateTime.Now,
                MatchScoreExterieur = 1,
                ClubDomicileId = 2,
                ClubExterieurId = 1,
            };

            var mockRepository = new Mock<IDataRepositoryWithoutStr<Match>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(mat);
            var matController = new MatchController(mockRepository.Object);

            // Act
            var actionResult = matController.GetMatchById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(mat, actionResult.Value as Match);
        }

        [TestMethod]
        public void GetMatchById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepositoryWithoutStr<Match>>();
            var matController = new MatchController(mockRepository.Object);
            // Act
            var actionResult = matController.GetMatchById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}