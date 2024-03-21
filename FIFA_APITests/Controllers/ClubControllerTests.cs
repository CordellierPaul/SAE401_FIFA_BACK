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
    public class ClubControllerTests
    {
        private FifaDbContext _context;
        private ClubController _controller;
        private IDataRepository<Club> _dataRepository;

        public ClubControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new ClubManager(_context);
            _controller = new ClubController(_dataRepository);
        }


        [TestMethod()]
        public void ClubControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetClubsTest_OK()
        {
            var expected = _context.Club.ToList();

            var results = _controller.GetClub().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetClubByIdTest_OK()
        {
            Club expected = _context.Club.Where(u => u.ClubId == 1).First();

            var result = _controller.GetClubById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Clubs");
        }



        [TestMethod()]
        public void GetClubByIdTest_NONOK()
        {
            var result = _controller.GetClubById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutClubTest_OK()
        {
            Club expected = _context.Club.Where(u => u.ClubId == 1).First();
            expected.ClubNom = "Test";

            var result = _controller.PutClub(1, expected).Result;
            Club resultClub = _controller.GetClubById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultClub, "Pas les mêmes Clubs");
        }*/
        /*
                [TestMethod]
                public void PostClubTest_OK()
                {
                    // Arrange
                    Club clubAtester = new Club()
                    {
                        ClubNom = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostClub(clubAtester).Result;

                    // Assert
                    Club? clubRecupere = _context.Club.Where(u => u.ClubNom.ToUpper() == clubAtester.ClubNom.ToUpper()).FirstOrDefault();

                    clubAtester.ClubId = clubRecupere.ClubId;

                    Assert.AreEqual(clubRecupere, clubAtester, "Clubs pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteClubTest_OK()
                {
                    Club club = new Club()
                    {
                        ClubNom = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Club.Add(club);
                    _context.SaveChanges();

                    int id = _context.Club.Where(u => u.ClubNom == club.ClubNom).First().ClubId;

                    var resultDelete = _controller.DeleteClub(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Club.Where(u => u.ClubId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostClub_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Club>>();
            var clubController = new ClubController(mockRepository.Object);
            Club club = new Club
            {
                ClubNom = "Test"
            };
            // Act
            var actionResult = clubController.PostClub(club).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Club>), "Pas un ActionResult<Club>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Club), "Pas un Club");
            club.ClubId = ((Club)result.Value).ClubId;
            Assert.AreEqual(club, (Club)result.Value, "Clubs pas identiques");
        }

        [TestMethod]
        public void DeleteClub_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Club club = new Club
            {
                ClubId = 1,
                ClubNom = "Test"
            };
            var mockRepository = new Mock<IDataRepository<Club>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(club);
            var clubController = new ClubController(mockRepository.Object);
            // Act
            var actionResult = clubController.DeleteClub(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutClubTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Club club = new Club
            {
                ClubId = 1,
                ClubNom = "Test"
            };
            Club clubModif = new Club
            {
                ClubId = 1,
                ClubNom = "Update"
            };

            var mockRepository = new Mock<IDataRepository<Club>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(club);
            var clubController = new ClubController(mockRepository.Object);

            // Act
            var actionResult = clubController.PutClub(1, clubModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetClubById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Club club = new Club
            {
                ClubId = 1,
                ClubNom = "Testgetidmoq"
            };

            var mockRepository = new Mock<IDataRepository<Club>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(club);
            var clubController = new ClubController(mockRepository.Object);

            // Act
            var actionResult = clubController.GetClubById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(club, actionResult.Value as Club);
        }

        [TestMethod]
        public void GetClubById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Club>>();
            var clubController = new ClubController(mockRepository.Object);
            // Act
            var actionResult = clubController.GetClubById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}