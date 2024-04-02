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
    public class ArticleControllerTests
    {
        private FifaDbContext _context;
        private ArticleController _controller;
        private IArticleRepository _dataRepository;

        public ArticleControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new ArticleManager(_context);
            _controller = new ArticleController(_dataRepository);
        }


        [TestMethod()]
        public void ArticleControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetArticlesTest_OK()
        {
            var expected = _context.Article.ToList();

            var results = _controller.GetArticle().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetArticleByIdTest_OK()
        {
            Article expected = _context.Article.Where(u => u.ArticleId == 1).First();

            var result = _controller.GetArticleById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Articles");
        }



        [TestMethod()]
        public void GetArticleByIdTest_NONOK()
        {
            var result = _controller.GetArticleById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutArticleTest_OK()
        {
            Article expected = _context.Article.Where(u => u.ArticleId == 1).First();
            expected.ArticleTitre = "Test";

            var result = _controller.PutArticle(1, expected).Result;
            Article resultArticle = _controller.GetArticleById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultArticle, "Pas les mêmes Articles");
        }*/
        /*
                [TestMethod]
                public void PostArticleTest_OK()
                {
                    // Arrange
                    Article artAtester = new Article()
                    {
                        ArticleTitre = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostArticle(artAtester).Result;

                    // Assert
                    Article? artRecupere = _context.Article.Where(u => u.ArticleTitre.ToUpper() == artAtester.ArticleTitre.ToUpper()).FirstOrDefault();

                    artAtester.ArticleId = artRecupere.ArticleId;

                    Assert.AreEqual(artRecupere, artAtester, "Articles pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteArticleTest_OK()
                {
                    Article art = new Article()
                    {
                        ArticleTitre = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Article.Add(art);
                    _context.SaveChanges();

                    int id = _context.Article.Where(u => u.ArticleTitre == art.ArticleTitre).First().ArticleId;

                    var resultDelete = _controller.DeleteArticle(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Article.Where(u => u.ArticleId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostArticle_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IArticleRepository>();
            var artController = new ArticleController(mockRepository.Object);
            Article art = new Article
            {
                ArticleTitre = "Test"
            };
            // Act
            var actionResult = artController.PostArticle(art).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Article>), "Pas un ActionResult<Article>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Article), "Pas un Article");
            art.ArticleId = ((Article)result.Value).ArticleId;
            Assert.AreEqual(art, (Article)result.Value, "Articles pas identiques");
        }

        [TestMethod]
        public void DeleteArticle_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Article art = new Article
            {
                ArticleId = 1,
                ArticleTitre = "Test"
            };
            var mockRepository = new Mock<IArticleRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(art);
            var artController = new ArticleController(mockRepository.Object);
            // Act
            var actionResult = artController.DeleteArticle(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutArticleTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Article art = new Article
            {
                ArticleId = 1,
                ArticleTitre = "Test"
            };
            Article artModif = new Article
            {
                ArticleId = 1,
                ArticleTitre = "Update"
            };

            var mockRepository = new Mock<IArticleRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(art);
            var artController = new ArticleController(mockRepository.Object);

            // Act
            var actionResult = artController.PutArticle(1, artModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetArticleById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Article art = new Article
            {
                ArticleId = 1,
                ArticleTitre = "Testgetidmoq"
            };

            var mockRepository = new Mock<IArticleRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(art);
            var artController = new ArticleController(mockRepository.Object);

            // Act
            var actionResult = artController.GetArticleById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(art, actionResult.Value as Article);
        }

        [TestMethod]
        public void GetArticleById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IArticleRepository>();
            var artController = new ArticleController(mockRepository.Object);
            // Act
            var actionResult = artController.GetArticleById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }

        [TestMethod()]
        public void GetCommantaireByArticleIdTest_ReturnsRightsItems_AvecMoq()
        {
            // Arrange
            List<Commentaire> lesCommentaires = new List<Commentaire>();
            Commentaire Commentaire = new Commentaire
            {
                CommentaireId = 1,
            };
            lesCommentaires.Add(Commentaire);

            Article CommentaireTheme = new Article
            {
                ArticleId = 1,
                ArticleResume = "Article de test",
                CommentairesArticle = lesCommentaires
            };


            var mockRepository = new Mock<IArticleRepository>();
            mockRepository.Setup(x => x.GetCommentairesByArticleId(1).Result).Returns(lesCommentaires);
            var artController = new ArticleController(mockRepository.Object);

            // Act
            var actionResult = artController.GetCommentaireById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(lesCommentaires, actionResult.Value as IEnumerable<Commentaire>);
        }


        #endregion
    }
}