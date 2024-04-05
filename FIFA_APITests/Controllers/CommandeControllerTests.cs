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
    public class CommandeControllerTests
    {
        private FifaDbContext _context;
        private CommandeController _controller;
        private ICommandeRepository _dataRepository;

        public CommandeControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new CommandeManager(_context);
            _controller = new CommandeController(_dataRepository);
        }


        [TestMethod()]
        public void CommandeControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetCommandesTest_OK()
        {
            var expected = _context.Commande.ToList();

            var results = _controller.GetCommande().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetCommandeByIdTest_OK()
        {
            Commande expected = _context.Commande.Where(u => u.CommandeId == 1).First();

            var result = _controller.GetCommandeById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Commandes");
        }



        [TestMethod()]
        public void GetCommandeByIdTest_NONOK()
        {
            var result = _controller.GetCommandeById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutCommandeTest_OK()
        {
            Commande expected = _context.Commande.Where(u => u.CommandeId == 1).First();
            expected.CommandeTitre = "Test";

            var result = _controller.PutCommande(1, expected).Result;
            Commande resultCommande = _controller.GetCommandeById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultCommande, "Pas les mêmes Commandes");
        }*/
        /*
                [TestMethod]
                public void PostCommandeTest_OK()
                {
                    // Arrange
                    Commande cmdAtester = new Commande()
                    {
                        CommandeTitre = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostCommande(cmdAtester).Result;

                    // Assert
                    Commande? cmdRecupere = _context.Commande.Where(u => u.CommandeTitre.ToUpper() == cmdAtester.CommandeTitre.ToUpper()).FirstOrDefault();

                    cmdAtester.CommandeId = cmdRecupere.CommandeId;

                    Assert.AreEqual(cmdRecupere, cmdAtester, "Commandes pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteCommandeTest_OK()
                {
                    Commande cmd = new Commande()
                    {
                        CommandeTitre = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Commande.Add(cmd);
                    _context.SaveChanges();

                    int id = _context.Commande.Where(u => u.CommandeTitre == cmd.CommandeTitre).First().CommandeId;

                    var resultDelete = _controller.DeleteCommande(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Commande.Where(u => u.CommandeId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostCommande_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<ICommandeRepository>();
            var cmdController = new CommandeController(mockRepository.Object);
            Commande cmd = new Commande
            {
                CommandeDateCommande = DateTime.Now,
                CommandeDomicile = true,
                CommandeEtatCommande = "EN COURS",
                CommandePrix = 10,
                AdresseCommande = new Adresse(),
                UtilisateurCommandant = new Utilisateur(),

            };
            // Act
            var actionResult = cmdController.PostCommande(cmd).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Commande>), "Pas un ActionResult<Commande>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Commande), "Pas un Commande");
            cmd.CommandeId = ((Commande)result.Value).CommandeId;
            Assert.AreEqual(cmd, (Commande)result.Value, "Commandes pas identiques");
        }

        [TestMethod]
        public void DeleteCommande_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Commande cmd = new Commande
            {
                CommandeId = 1,
                CommandeDateCommande = DateTime.Now,
                CommandeDomicile = true,
                CommandeEtatCommande = "EN COURS",
                CommandePrix = 10,
                AdresseCommande = new Adresse(),
                UtilisateurCommandant = new Utilisateur(),
            };
            var mockRepository = new Mock<ICommandeRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(cmd);
            var cmdController = new CommandeController(mockRepository.Object);
            // Act
            var actionResult = cmdController.DeleteCommande(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutCommandeTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Commande cmd = new Commande
            {
                CommandeId = 1,
                CommandeDateCommande = DateTime.Now,
                CommandeDomicile = true,
                CommandeEtatCommande = "EN COURS",
                CommandePrix = 10,
                AdresseCommande = new Adresse(),
                UtilisateurCommandant = new Utilisateur(),
            };
            Commande cmdModif = new Commande
            {
                CommandeId = 1,
                CommandeDateCommande = DateTime.Now,
                CommandeDomicile = true,
                CommandeEtatCommande = "LIVREE",
                CommandePrix = 10,
                AdresseCommande = new Adresse(),
                UtilisateurCommandant = new Utilisateur(),
            };

            var mockRepository = new Mock<ICommandeRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(cmd);
            var cmdController = new CommandeController(mockRepository.Object);

            // Act
            var actionResult = cmdController.PutCommande(1, cmdModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetCommandeById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Commande cmd = new Commande
            {
                CommandeId = 1,
                CommandeDateCommande = DateTime.Now,
                CommandeDomicile = true,
                CommandeEtatCommande = "EN COURS",
                CommandePrix = 10,
                AdresseCommande = new Adresse(),
                UtilisateurCommandant = new Utilisateur(),
            };

            var mockRepository = new Mock<ICommandeRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(cmd);
            var cmdController = new CommandeController(mockRepository.Object);

            // Act
            var actionResult = cmdController.GetCommandeById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(cmd, actionResult.Value as Commande);
        }

        [TestMethod]
        public void GetCommandeById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<ICommandeRepository>();
            var cmdController = new CommandeController(mockRepository.Object);
            // Act
            var actionResult = cmdController.GetCommandeById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}