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
    public class AlbumControllerTests
    {
        private FifaDbContext _context;
        private AlbumController _controller;
        private IDataRepository<Album> _dataRepository;

        public AlbumControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=localhost;port=5432;Database=FifaDB; uid=postgres; password=postgres;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new AlbumManager(_context);
            _controller = new AlbumController(_dataRepository);
        }


        [TestMethod()]
        public void AlbumControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetAlbumsTest_OK()
        {
            var expected = _context.Album.ToList();

            var results = _controller.GetAlbum().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetAlbumByIdTest_OK()
        {
            Album expected = _context.Album.Where(u => u.AlbumId == 1).First();

            var result = _controller.GetAlbumById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Albums");
        }



        [TestMethod()]
        public void GetAlbumByIdTest_NONOK()
        {
            var result = _controller.GetAlbumById(0).Result;

            Assert.IsNull(result.Value);
        }

        [TestMethod()]
        public void PutAlbumTest_OK()
        {
            Album expected = _context.Album.Where(u => u.AlbumId == 1).First();
            expected.AlbumTitre = "Test";

            var result = _controller.PutAlbum(1, expected).Result;
            Album resultUser = _controller.GetAlbumById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultUser, "Pas les mêmes Albums");
        }
        /*
                [TestMethod]
                public void PostAlbumTest_OK()
                {
                    // Arrange
                    Album albAtester = new Album()
                    {
                        AlbumTitre = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostAlbum(albAtester).Result;

                    // Assert
                    Album? albRecupere = _context.Album.Where(u => u.AlbumTitre.ToUpper() == albAtester.AlbumTitre.ToUpper()).FirstOrDefault();

                    albAtester.AlbumId = albRecupere.AlbumId;

                    Assert.AreEqual(albRecupere, albAtester, "Albums pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteAlbumTest_OK()
                {
                    Album user = new Album()
                    {
                        AlbumTitre = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Album.Add(user);
                    _context.SaveChanges();

                    int id = _context.Album.Where(u => u.AlbumTitre == user.AlbumTitre).First().AlbumId;

                    var resultDelete = _controller.DeleteAlbum(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Album.Where(u => u.AlbumId == id).First();
                }*/


        #region Test moq

        [TestMethod]
        public void PostAlbum_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Album>>();
            var albController = new AlbumController(mockRepository.Object);
            Album alb = new Album
            {
                AlbumTitre = "Test"
            };
            // Act
            var actionResult = albController.PostAlbum(alb).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Album>), "Pas un ActionResult<Album>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Album), "Pas un Album");
            alb.AlbumId = ((Album)result.Value).AlbumId;
            Assert.AreEqual(alb, (Album)result.Value, "Albums pas identiques");
        }

        [TestMethod]
        public void DeleteAlbum_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Album alb = new Album
            {
                AlbumId = 1,
                AlbumTitre = "Test"
            };
            var mockRepository = new Mock<IDataRepository<Album>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(alb);
            var albController = new AlbumController(mockRepository.Object);
            // Act
            var actionResult = albController.DeleteAlbum(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutAlbumTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Album alb = new Album
            {
                AlbumId = 1,
                AlbumTitre = "Test"
            };
            Album albModif = new Album
            {
                AlbumId = 1,
                AlbumTitre = "Update"
            };

            var mockRepository = new Mock<IDataRepository<Album>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(alb);
            var albController = new AlbumController(mockRepository.Object);

            // Act
            var actionResult = albController.PutAlbum(1, albModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetAlbumById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Album alb = new Album
            {
                AlbumId = 1,
                AlbumTitre = "Testgetidmoq"
            };

            var mockRepository = new Mock<IDataRepository<Album>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(alb);
            var albController = new AlbumController(mockRepository.Object);

            // Act
            var actionResult = albController.GetAlbumById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(alb, actionResult.Value as Album);
        }

        [TestMethod]
        public void GetAlbumById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Album>>();
            var albController = new AlbumController(mockRepository.Object);
            // Act
            var actionResult = albController.GetAlbumById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}