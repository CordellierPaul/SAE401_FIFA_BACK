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
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Security.Principal;

namespace FIFA_API.Controllers.Tests
{
    [TestClass()]
    public class CompteControllerTests
    {
        private FifaDbContext _context;
        private CompteController _controller;
        private IDataRepository<Compte> _dataRepository;

        public CompteControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new CompteManager(_context);
            _controller = new CompteController(_dataRepository);
        }


        [TestMethod()]
        public void CompteControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetCompteByIdTest_OK()
        {
            Compte expected = _context.Compte.Where(u => u.CompteId == 1).First();

            var result = _controller.GetCompteById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Comptes");
        }

        [TestMethod()]
        public void GetCompteByEmailTest_OK()
        {
            Compte expected = _context.Compte.Where(u => u.CompteId == 1).First();

            var result = _controller.GetCompteByEmail(expected.CompteEmail).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Compte");
        }



        [TestMethod()]
        public void GetCompteByIdTest_NONOK()
        {
            var result = _controller.GetCompteById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacés par moq

        /*[TestMethod()]
        public void PutCompteTest_OK()
        {
            Compte expected = _context.Compte.Where(u => u.CompteId == 1).First();
            expected.CompteEmail = "testcompte@gmail.com";

            var result = _controller.PutCompte(1, expected).Result;
            Compte resultCompte = _controller.GetCompteById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultCompte, "Pas les mêmes Comptes");
        }*/
        /*
                [TestMethod]
                public void PostCompteTest_OK()
                {
                    // Arrange
                    Compte cpteAtester = new Compte()
                    {
                        CompteEmail = "testcompte" + DateTime.UtcNow.ToString() + "@gmail.com"
                    };
                    // Act
                    var result = _controller.PostCompte(cpteAtester).Result;

                    // Assert
                    Compte? cpteRecupere = _context.Compte.Where(u => u.CompteEmail.ToUpper() == cpteAtester.CompteEmail.ToUpper()).FirstOrDefault();

                    cpteAtester.CompteId = cpteRecupere.CompteId;

                    Assert.AreEqual(cpteRecupere, cpteAtester, "Comptes pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteCompteTest_OK()
                {
                    Compte cpte = new Compte()
                    {
                        CompteEmail = "testcompte" + DateTime.UtcNow.ToString() + "@gmail.com"
                    };

                    _context.Compte.Add(cpte);
                    _context.SaveChanges();

                    int id = _context.Compte.Where(u => u.CompteEmail == cpte.CompteEmail).First().CompteId;

                    var resultDelete = _controller.DeleteCompte(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Compte.Where(u => u.CompteId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostCompte_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Compte>>();
            var cpteController = new CompteController(mockRepository.Object);
            Compte cpte = new Compte
            {
                CompteEmail = "testcompte@gmail.com"
            };
            // Act
            var actionResult = cpteController.PostCompte(cpte).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Compte>), "Pas un ActionResult<Compte>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Compte), "Pas un Compte");
            cpte.CompteId = ((Compte)result.Value).CompteId;
            Assert.AreEqual(cpte, (Compte)result.Value, "Comptes pas identiques");
        }

        [TestMethod]
        public void DeleteCompte_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Utilisateur user = new Utilisateur
            {
                UtilisateurId = 1,
                CompteId = 1,
            };
            Compte cpte = new Compte
            {
                CompteId = 1,
                CompteEmail = "testcompte@gmail.com",
                UtilisateurCompte = user
                
            };
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, cpte.CompteEmail),
                new Claim(ClaimTypes.NameIdentifier, cpte.CompteId.ToString()),
                new Claim("id", cpte.CompteId.ToString()),
            };
            var identity = new ClaimsIdentity(claims, "Test");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.Setup(x => x.Identity).Returns(identity);
            mockPrincipal.Setup(x => x.IsInRole(It.IsAny<string>())).Returns(true);

            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(m => m.User).Returns(claimsPrincipal);

            var mockRepository = new Mock<ICompteRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(cpte);
            var httpContext = new DefaultHttpContext();
            var ctx = new ControllerContext() { HttpContext = new DefaultHttpContext() };
            var cpteController = new CompteController(mockRepository.Object);
            cpteController.ControllerContext = ctx;
            // Act
            var actionResult = cpteController.DeleteCompte(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutCompteTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Compte cpte = new Compte
            {
                CompteId = 1,
                CompteEmail = "testcompte@gmail.com"
            };
            Compte cpteModif = new Compte
            {
                CompteId = 1,
                CompteEmail = "Updatecompte@gmail.com"
            };

            var mockRepository = new Mock<IDataRepository<Compte>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(cpte);
            var cpteController = new CompteController(mockRepository.Object);

            // Act
            var actionResult = cpteController.PutCompte(1, cpteModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetCompteById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Compte cpte = new Compte
            {
                CompteId = 1,
                CompteEmail = "testcompte@gmail.com"
            };

            var mockRepository = new Mock<IDataRepository<Compte>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(cpte);
            var cpteController = new CompteController(mockRepository.Object);

            // Act
            var actionResult = cpteController.GetCompteById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(cpte, actionResult.Value as Compte);
        }

        [TestMethod]
        public void GetCompteById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Compte>>();
            var cpteController = new CompteController(mockRepository.Object);
            // Act
            var actionResult = cpteController.GetCompteById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }

        [TestMethod]
        public void GetCompteByEmail_ExistingEmailPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Compte user = new Compte
            {
                CompteId = 1,
                CompteEmail = "clilleymd@last.fr",
            };

            var mockRepository = new Mock<IDataRepository<Compte>>();
            mockRepository.Setup(x => x.GetByStringAsync("clilleymd@last.fr").Result).Returns(user);
            var userController = new CompteController(mockRepository.Object);

            // Act
            var actionResult = userController.GetCompteByEmail("clilleymd@last.fr").Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(user, actionResult.Value as Compte);
        }

        [TestMethod]
        public void GetCompteByEmail_UnknownEmailPassed_ReturnsNotFoundResult_AvecMoq()
        {
            // Arrange
            Compte user = new Compte
            {
                CompteId = 1,
                CompteEmail = "clilleymd@last.fr"
            };

            var mockRepository = new Mock<IDataRepository<Compte>>();
            mockRepository.Setup(x => x.GetByStringAsync("clilleymd@last.fr").Result).Returns(user);
            var userController = new CompteController(mockRepository.Object);

            // Act
            var actionResult = userController.GetCompteByEmail("aifbafuba@last.fr").Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNull(actionResult.Value, "Est pas null");
            Assert.AreEqual(StatusCodes.Status404NotFound, ((NotFoundResult)actionResult.Result).StatusCode, "Pas de code 404");
        }


        #endregion
    }
}