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
    public class JoueurControllerTests
    {
        private FifaDbContext _context;
        private JoueurController _controller;
        private IJoueurRepository _dataRepository;

        public JoueurControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new JoueurManager(_context);
            _controller = new JoueurController(_dataRepository);
        }


        [TestMethod()]
        public void JoueurControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetJoueursTest_OK()
        {
            var expected = _context.Joueur.ToList();

            var results = _controller.GetJoueur().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetJoueurByIdTest_OK()
        {
            Joueur expected = _context.Joueur.Where(u => u.JoueurId == 1).First();

            var result = _controller.GetJoueurById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Joueurs");
        }



        [TestMethod()]
        public void GetJoueurByIdTest_NONOK()
        {
            var result = _controller.GetJoueurById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutJoueurTest_OK()
        {
            Joueur expected = _context.Joueur.Where(u => u.JoueurId == 1).First();
            expected.JoueurDescription = "Test";

            var result = _controller.PutJoueur(1, expected).Result;
            Joueur resultJoueur = _controller.GetJoueurById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultJoueur, "Pas les mêmes Joueurs");
        }*/
        /*
                [TestMethod]
                public void PostJoueurTest_OK()
                {
                    // Arrange
                    Joueur jouAtester = new Joueur()
                    {
                        JoueurDescription = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostJoueur(jouAtester).Result;

                    // Assert
                    Joueur? jouRecupere = _context.Joueur.Where(u => u.JoueurDescription.ToUpper() == jouAtester.JoueurDescription.ToUpper()).FirstOrDefault();

                    jouAtester.JoueurId = jouRecupere.JoueurId;

                    Assert.AreEqual(jouRecupere, jouAtester, "Joueurs pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteJoueurTest_OK()
                {
                    Joueur jou = new Joueur()
                    {
                        JoueurDescription = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Joueur.Add(jou);
                    _context.SaveChanges();

                    int id = _context.Joueur.Where(u => u.JoueurDescription == jou.JoueurDescription).First().JoueurId;

                    var resultDelete = _controller.DeleteJoueur(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Joueur.Where(u => u.JoueurId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostJoueur_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IJoueurRepository>();
            var jouController = new JoueurController(mockRepository.Object);
            Joueur jou = new Joueur
            {
                JoueurDescription = "Test"
            };
            // Act
            var actionResult = jouController.PostJoueur(jou).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Joueur>), "Pas un ActionResult<Joueur>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Joueur), "Pas un Joueur");
            jou.JoueurId = ((Joueur)result.Value).JoueurId;
            Assert.AreEqual(jou, (Joueur)result.Value, "Joueurs pas identiques");
        }

        [TestMethod]
        public void DeleteJoueur_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Joueur jou = new Joueur
            {
                JoueurId = 1,
                JoueurDescription = "Test"
            };
            var mockRepository = new Mock<IJoueurRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(jou);
            var jouController = new JoueurController(mockRepository.Object);
            // Act
            var actionResult = jouController.DeleteJoueur(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutJoueurTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Joueur jou = new Joueur
            {
                JoueurId = 1,
                JoueurDescription = "Test"
            };
            Joueur jouModif = new Joueur
            {
                JoueurId = 1,
                JoueurDescription = "Update"
            };

            var mockRepository = new Mock<IJoueurRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(jou);
            var jouController = new JoueurController(mockRepository.Object);

            // Act
            var actionResult = jouController.PutJoueur(1, jouModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetJoueurById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Joueur jou = new Joueur
            {
                JoueurId = 1,
                JoueurDescription = "Testgetidmoq"
            };

            var mockRepository = new Mock<IJoueurRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(jou);
            var jouController = new JoueurController(mockRepository.Object);

            // Act
            var actionResult = jouController.GetJoueurById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(jou, actionResult.Value as Joueur);
        }

        [TestMethod]
        public void GetJoueurById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IJoueurRepository>();
            var jouController = new JoueurController(mockRepository.Object);
            // Act
            var actionResult = jouController.GetJoueurById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}