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
    public class BlogControllerTests
    {
        private FifaDbContext _context;
        private BlogController _controller;
        private IBlogRepository _dataRepository;

        public BlogControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new BlogManager(_context);
            _controller = new BlogController(_dataRepository);
        }


        [TestMethod()]
        public void BlogControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetBlogsTest_OK()
        {
            var expected = _context.Blog.ToList();

            var results = _controller.GetBlog().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetBlogByIdTest_OK()
        {
            Blog expected = _context.Blog.Where(u => u.BlogId == 1).First();

            var result = _controller.GetBlogById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Blogs");
        }



        [TestMethod()]
        public void GetBlogByIdTest_NONOK()
        {
            var result = _controller.GetBlogById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutBlogTest_OK()
        {
            Blog expected = _context.Blog.Where(u => u.BlogId == 1).First();
            expected.BlogTitre = "Test";

            var result = _controller.PutBlog(1, expected).Result;
            Blog resultBlog = _controller.GetBlogById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultBlog, "Pas les mêmes Blogs");
        }*/
        /*
                [TestMethod]
                public void PostBlogTest_OK()
                {
                    // Arrange
                    Blog blgAtester = new Blog()
                    {
                        BlogTitre = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostBlog(blgAtester).Result;

                    // Assert
                    Blog? blgRecupere = _context.Blog.Where(u => u.BlogTitre.ToUpper() == blgAtester.BlogTitre.ToUpper()).FirstOrDefault();

                    blgAtester.BlogId = blgRecupere.BlogId;

                    Assert.AreEqual(blgRecupere, blgAtester, "Blogs pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteBlogTest_OK()
                {
                    Blog blg = new Blog()
                    {
                        BlogTitre = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Blog.Add(blg);
                    _context.SaveChanges();

                    int id = _context.Blog.Where(u => u.BlogTitre == blg.BlogTitre).First().BlogId;

                    var resultDelete = _controller.DeleteBlog(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Blog.Where(u => u.BlogId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostBlog_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IBlogRepository>();
            var blgController = new BlogController(mockRepository.Object);
            Blog blg = new Blog
            {
                BlogTitre = "Test"
            };
            // Act
            var actionResult = blgController.PostBlog(blg).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Blog>), "Pas un ActionResult<Blog>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Blog), "Pas un Blog");
            blg.BlogId = ((Blog)result.Value).BlogId;
            Assert.AreEqual(blg, (Blog)result.Value, "Blogs pas identiques");
        }

        [TestMethod]
        public void DeleteBlog_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Blog blg = new Blog
            {
                BlogId = 1,
                BlogTitre = "Test"
            };
            var mockRepository = new Mock<IBlogRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(blg);
            var blgController = new BlogController(mockRepository.Object);
            // Act
            var actionResult = blgController.DeleteBlog(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutBlogTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Blog blg = new Blog
            {
                BlogId = 1,
                BlogTitre = "Test"
            };
            Blog blgModif = new Blog
            {
                BlogId = 1,
                BlogTitre = "Update"
            };

            var mockRepository = new Mock<IBlogRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(blg);
            var blgController = new BlogController(mockRepository.Object);

            // Act
            var actionResult = blgController.PutBlog(1, blgModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetBlogById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Blog blg = new Blog
            {
                BlogId = 1,
                BlogTitre = "Testgetidmoq"
            };

            var mockRepository = new Mock<IBlogRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(blg);
            var blgController = new BlogController(mockRepository.Object);

            // Act
            var actionResult = blgController.GetBlogById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(blg, actionResult.Value as Blog);
        }

        [TestMethod]
        public void GetBlogById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IBlogRepository>();
            var blgController = new BlogController(mockRepository.Object);
            // Act
            var actionResult = blgController.GetBlogById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }

        [TestMethod()]
        public void GetCommantaireByBlogIdTest_ReturnsRightsItems_AvecMoq()
        {
            // Arrange
            List<Commentaire> lesCommentaires = new List<Commentaire>();
            Commentaire Commentaire = new Commentaire
            {
                CommentaireId = 1,
            };
            lesCommentaires.Add(Commentaire);

            Blog CommentaireTheme = new Blog
            {
                BlogId = 1,
                BlogDescription = "Blog de test",
                CommentairesBlog = lesCommentaires
            };


            var mockRepository = new Mock<IBlogRepository>();
            mockRepository.Setup(x => x.GetCommentaireByBlogId(1).Result).Returns(lesCommentaires);
            var blgController = new BlogController(mockRepository.Object);

            // Act
            var actionResult = blgController.GetCommentaireById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(lesCommentaires, actionResult.Value as IEnumerable<Commentaire>);
        }


        #endregion
    }
}