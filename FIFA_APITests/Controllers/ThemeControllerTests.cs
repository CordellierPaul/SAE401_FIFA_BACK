using Microsoft.VisualStudio.TestTools.UnitTesting;
using FIFA_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using FIFA_API.Models.DataManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FIFA_API.Controllers.Tests
{
    [TestClass()]
    public class ThemeControllerTests
    {
        private FifaDbContext _context;
        private ThemeController _controller;
        private IThemeRepository _dataRepository;

        public ThemeControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new ThemeManager(_context);
            _controller = new ThemeController(_dataRepository);
        }


        [TestMethod()]
        public void ThemeControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetThemesTest_OK()
        {
            var expected = _context.Theme.ToList();

            var results = _controller.GetTheme().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetThemeByIdTest_OK()
        {
            Theme expected = _context.Theme.Where(u => u.ThemeId == 1).First();

            var result = _controller.GetThemeById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Themes");
        }



        [TestMethod()]
        public void GetThemeByIdTest_NONOK()
        {
            var result = _controller.GetThemeById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test moq

        [TestMethod]
        public void PostTheme_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IThemeRepository>();
            var posController = new ThemeController(mockRepository.Object);
            Theme pos = new Theme
            {
                ThemeLibelle = "Test"
            };
            // Act
            var actionResult = posController.PostTheme(pos).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Theme>), "Pas un ActionResult<Theme>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Theme), "Pas un Theme");
            pos.ThemeId = ((Theme)result.Value).ThemeId;
            Assert.AreEqual(pos, (Theme)result.Value, "Themes pas identiques");
        }

        [TestMethod]
        public void DeleteTheme_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Theme pos = new Theme
            {
                ThemeId = 1,
                ThemeLibelle = "Test"
            };
            var mockRepository = new Mock<IThemeRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(pos);
            var posController = new ThemeController(mockRepository.Object);
            // Act
            var actionResult = posController.DeleteTheme(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutThemeTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Theme pos = new Theme
            {
                ThemeId = 1,
                ThemeLibelle = "Test"
            };
            Theme posModif = new Theme
            {
                ThemeId = 1,
                ThemeLibelle = "Update"
            };

            var mockRepository = new Mock<IThemeRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(pos);
            var posController = new ThemeController(mockRepository.Object);

            // Act
            var actionResult = posController.PutTheme(1, posModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetThemeById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Theme pos = new Theme
            {
                ThemeId = 1,
                ThemeLibelle = "Testgetidmoq"
            };

            var mockRepository = new Mock<IThemeRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(pos);
            var posController = new ThemeController(mockRepository.Object);

            // Act
            var actionResult = posController.GetThemeById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(pos, actionResult.Value as Theme);
        }

        [TestMethod]
        public void GetThemeById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IThemeRepository>();
            var posController = new ThemeController(mockRepository.Object);
            // Act
            var actionResult = posController.GetThemeById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }

        [TestMethod()]
        public void GetJoueursByThemeIdTest_ReturnsRightsItems_AvecMoq()
        {
            // Arrange
            List<Joueur> lesJoueurs = new List<Joueur>();
            Joueur joueur = new Joueur
            {
                JoueurId = 1,
                JoueurDateNaissance = DateTime.Now,
                JoueurDescription = "Joueur test",
                JoueurNom = "TestMoq"
            };
            lesJoueurs.Add(joueur);

            JoueurTheme joueurTheme = new JoueurTheme
            {
                JoueurId = 1,
                ThemeId = 1,
                JoueurNavigation = joueur
            };
            Theme theme = new Theme
            {
                ThemeId = 1,
                LienJoueur = new JoueurTheme[] { joueurTheme }
            };


            var mockRepository = new Mock<IThemeRepository>();
            mockRepository.Setup(x => x.GetJoueursByThemeId(1).Result).Returns(lesJoueurs);
            var stkController = new ThemeController(mockRepository.Object);

            // Act
            var actionResult = stkController.GetJoueursByThemeId(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(lesJoueurs, actionResult.Value as IEnumerable<Joueur>);
        }


        #endregion
    }
}