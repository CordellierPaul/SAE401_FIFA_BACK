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
    public class CommentaireControllerTests
    {
        private FifaDbContext _context;
        private CommentaireController _controller;
        private ICommentaireRepository _dataRepository;

        public CommentaireControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new CommentaireManager(_context);
            _controller = new CommentaireController(_dataRepository);
        }


        [TestMethod()]
        public void CommentaireControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetCommentairesTest_OK()
        {
            var expected = _context.Commentaire.ToList();

            var results = _controller.GetCommentaire().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetCommentaireByIdTest_OK()
        {
            Commentaire expected = _context.Commentaire.Where(u => u.CommentaireId == 1).First();

            var result = _controller.GetCommentaireById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Commentaires");
        }



        [TestMethod()]
        public void GetCommentaireByIdTest_NONOK()
        {
            var result = _controller.GetCommentaireById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutCommentaireTest_OK()
        {
            Commentaire expected = _context.Commentaire.Where(u => u.CommentaireId == 1).First();
            expected.CommentaireTexte = "Test";

            var result = _controller.PutCommentaire(1, expected).Result;
            Commentaire resultCommentaire = _controller.GetCommentaireById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultCommentaire, "Pas les mêmes Commentaires");
        }*/
        /*
                [TestMethod]
                public void PostCommentaireTest_OK()
                {
                    // Arrange
                    Commentaire comAtester = new Commentaire()
                    {
                        CommentaireTexte = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostCommentaire(comAtester).Result;

                    // Assert
                    Commentaire? comRecupere = _context.Commentaire.Where(u => u.CommentaireTexte.ToUpper() == comAtester.CommentaireTexte.ToUpper()).FirstOrDefault();

                    comAtester.CommentaireId = comRecupere.CommentaireId;

                    Assert.AreEqual(comRecupere, comAtester, "Commentaires pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteCommentaireTest_OK()
                {
                    Commentaire com = new Commentaire()
                    {
                        CommentaireTexte = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Commentaire.Add(com);
                    _context.SaveChanges();

                    int id = _context.Commentaire.Where(u => u.CommentaireTexte == com.CommentaireTexte).First().CommentaireId;

                    var resultDelete = _controller.DeleteCommentaire(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Commentaire.Where(u => u.CommentaireId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostCommentaire_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<ICommentaireRepository>();
            var comController = new CommentaireController(mockRepository.Object);
            Commentaire com = new Commentaire
            {
                CommentaireTexte = "Test"
            };
            // Act
            var actionResult = comController.PostCommentaire(com).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Commentaire>), "Pas un ActionResult<Commentaire>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Commentaire), "Pas un Commentaire");
            com.CommentaireId = ((Commentaire)result.Value).CommentaireId;
            Assert.AreEqual(com, (Commentaire)result.Value, "Commentaires pas identiques");
        }

        [TestMethod]
        public void DeleteCommentaire_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Commentaire com = new Commentaire
            {
                CommentaireId = 1,
                CommentaireTexte = "Test"
            };
            var mockRepository = new Mock<ICommentaireRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(com);
            var comController = new CommentaireController(mockRepository.Object);
            // Act
            var actionResult = comController.DeleteCommentaire(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutCommentaireTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Commentaire com = new Commentaire
            {
                CommentaireId = 1,
                CommentaireTexte = "Test"
            };
            Commentaire comModif = new Commentaire
            {
                CommentaireId = 1,
                CommentaireTexte = "Update"
            };

            var mockRepository = new Mock<ICommentaireRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(com);
            var comController = new CommentaireController(mockRepository.Object);

            // Act
            var actionResult = comController.PutCommentaire(1, comModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetCommentaireById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Commentaire com = new Commentaire
            {
                CommentaireId = 1,
                CommentaireTexte = "Testgetidmoq"
            };

            var mockRepository = new Mock<ICommentaireRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(com);
            var comController = new CommentaireController(mockRepository.Object);

            // Act
            var actionResult = comController.GetCommentaireById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(com, actionResult.Value as Commentaire);
        }

        [TestMethod]
        public void GetCommentaireById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<ICommentaireRepository>();
            var comController = new CommentaireController(mockRepository.Object);
            // Act
            var actionResult = comController.GetCommentaireById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }

        [TestMethod()]
        public void GetResponseOfCommentaireTest_ReturnsRightsItem_AvecMoq()
        {
            // Arrange
            Commentaire Commentaire = new Commentaire
            {
                CommentaireId = 1,
            };
            Commentaire CommentaireCommente = new Commentaire
            {
                CommentaireId = 2,
                CommentaireCommente = Commentaire
            };


            var mockRepository = new Mock<ICommentaireRepository>();
            mockRepository.Setup(x => x.GetResponseOfCommentaire(2).Result).Returns(Commentaire);
            var artController = new CommentaireController(mockRepository.Object);

            // Act
            var actionResult = artController.GetResponseOfCommentaire(2).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(Commentaire, actionResult.Value as Commentaire);
        }


        #endregion
    }
}