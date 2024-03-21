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
    public class MediaControllerTests
    {
        private FifaDbContext _context;
        private MediaController _controller;
        private IDataRepositoryWithoutStr<Media> _dataRepository;

        public MediaControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new MediaManager(_context);
            _controller = new MediaController(_dataRepository);
        }


        [TestMethod()]
        public void MediaControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetMediasTest_OK()
        {
            var expected = _context.Media.ToList();

            var results = _controller.GetMedia().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetMediaByIdTest_OK()
        {
            Media expected = _context.Media.Where(u => u.MediaId == 1).First();

            var result = _controller.GetMediaById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Medias");
        }



        [TestMethod()]
        public void GetMediaByIdTest_NONOK()
        {
            var result = _controller.GetMediaById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutMediaTest_OK()
        {
            Media expected = _context.Media.Where(u => u.MediaId == 1).First();
            expected.MediaUrl = "Test";

            var result = _controller.PutMedia(1, expected).Result;
            Media resultMedia = _controller.GetMediaById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultMedia, "Pas les mêmes Medias");
        }*/
        /*
                [TestMethod]
                public void PostMediaTest_OK()
                {
                    // Arrange
                    Media medAtester = new Media()
                    {
                        MediaUrl = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostMedia(medAtester).Result;

                    // Assert
                    Media? medRecupere = _context.Media.Where(u => u.MediaUrl.ToUpper() == medAtester.MediaUrl.ToUpper()).FirstOrDefault();

                    medAtester.MediaId = medRecupere.MediaId;

                    Assert.AreEqual(medRecupere, medAtester, "Medias pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteMediaTest_OK()
                {
                    Media med = new Media()
                    {
                        MediaUrl = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Media.Add(med);
                    _context.SaveChanges();

                    int id = _context.Media.Where(u => u.MediaUrl == med.MediaUrl).First().MediaId;

                    var resultDelete = _controller.DeleteMedia(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Media.Where(u => u.MediaId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostMedia_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepositoryWithoutStr<Media>>();
            var medController = new MediaController(mockRepository.Object);
            Media med = new Media
            {
                MediaUrl = "Test"
            };
            // Act
            var actionResult = medController.PostMedia(med).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Media>), "Pas un ActionResult<Media>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Media), "Pas un Media");
            med.MediaId = ((Media)result.Value).MediaId;
            Assert.AreEqual(med, (Media)result.Value, "Medias pas identiques");
        }

        [TestMethod]
        public void DeleteMedia_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Media med = new Media
            {
                MediaId = 1,
                MediaUrl = "Test"
            };
            var mockRepository = new Mock<IDataRepositoryWithoutStr<Media>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(med);
            var medController = new MediaController(mockRepository.Object);
            // Act
            var actionResult = medController.DeleteMedia(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutMediaTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Media med = new Media
            {
                MediaId = 1,
                MediaUrl = "Test"
            };
            Media medModif = new Media
            {
                MediaId = 1,
                MediaUrl = "Update"
            };

            var mockRepository = new Mock<IDataRepositoryWithoutStr<Media>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(med);
            var medController = new MediaController(mockRepository.Object);

            // Act
            var actionResult = medController.PutMedia(1, medModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetMediaById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Media med = new Media
            {
                MediaId = 1,
                MediaUrl = "Testgetidmoq"
            };

            var mockRepository = new Mock<IDataRepositoryWithoutStr<Media>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(med);
            var medController = new MediaController(mockRepository.Object);

            // Act
            var actionResult = medController.GetMediaById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(med, actionResult.Value as Media);
        }

        [TestMethod]
        public void GetMediaById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepositoryWithoutStr<Media>>();
            var medController = new MediaController(mockRepository.Object);
            // Act
            var actionResult = medController.GetMediaById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}