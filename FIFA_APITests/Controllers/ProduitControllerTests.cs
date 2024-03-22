﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.EntityFrameworkCore;
using FIFA_API.Models.DataManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FIFA_API.Controllers.Tests
{
    [TestClass()]
    public class ProduitControllerTests
    {
        private FifaDbContext _context;
        private ProduitController _controller;
        private IProduitRepository _dataRepository;

        public ProduitControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new ProduitManager(_context);
            _controller = new ProduitController(_dataRepository);
        }

        [TestMethod()]
        public void ProduitControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetAllProduitTest_Ok()
        {
            var expected = _context.Produit.ToList();

            var results = _controller.GetProduit().Result.Value;

            CollectionAssert.AreEqual(expected, results?.ToList(), "Pas les mêmes listes");
        }

        [TestMethod()]
        public void GetProduitByIdTest_OK()
        {
            Produit expected = _context.Produit.Where(u => u.ProduitId == 1).First();

            var result = _controller.GetProduitById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes produits");
        }

        [TestMethod()]
        public void GetProduitByIdTest_NONOK()
        {
            var result = _controller.GetProduitById(0).Result;

            Assert.IsNull(result.Value);
        }

        [TestMethod()]
        public void PutProduitTest_OK()
        {
            Produit expected = _context.Produit.Where(u => u.ProduitId == 1).First();
            expected.ProduitNom = "Test";

            var result = _controller.PutProduit(1, expected).Result;
            Produit resultUser = _controller.GetProduitById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultUser, "Pas les mêmes produits");
        }

        [TestMethod]
        public void PostProduitTest_OK()
        {
            // Arrange
            Produit proAtester = new Produit()
            {
                GenreId = 1,
                CategorieId = 1,
                ProduitNom = "Test" + DateTime.UtcNow.ToString(),
                ProduitDescription = "Test description",
            };
            // Act
            var result = _controller.PostProduit(proAtester).Result;

            // Assert
            Produit? proRecupere = _context.Produit.Where(u => u.ProduitNom.ToUpper() == proAtester.ProduitNom.ToUpper()).FirstOrDefault();

            proAtester.CategorieId = proRecupere.CategorieId;

            Assert.AreEqual(proRecupere, proAtester, "Produits pas identiques");
        }

        [TestMethod]
        public void GetSearchResults_OK()
        {
            // Arrange
            var mockRepository = new Mock<IProduitRepository>();
            var moqProduitController = new ProduitController(mockRepository.Object);

            var produitTrouve1 = new Produit()
            {
                ProduitNom = "un produit vert qui est un pull"
            };
            var produitTrouve2 = new Produit()
            {
                ProduitNom = "pull-vert"
            };
            var produitPasTrouve1 = new Produit()
            {
                ProduitNom = "pull rouge"
            };
            var produitPasTrouve2 = new Produit()
            {
                ProduitNom = "batte de baseball"
            };
            mockRepository.Object.AddAsync(produitTrouve1).Wait();

            // Act
            ActionResult<IEnumerable<Produit>> result = _controller.GetSearchResults("pull vert").Result;

            // Assert
            //Assert.IsInstanceOfType(result., typeof(ActionResult), "Le type du résultat n'est pas Ok");

            //Assert.IsNotNull(result.Value);
        }

/*
        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeleteCategorieTest_OK()
        {
            Produit pdt = new Produit()
            {
                ProduitNom = "Test" + DateTime.UtcNow.ToString()
            };

            _context.Produit.Add(pdt);
            _context.SaveChanges();

            int id = _context.Produit.Where(u => u.ProduitNom == pdt.ProduitNom).First().ProduitId;

            var resultDelete = _controller.DeleteProduit(id).Result;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
            _context.Produit.Where(u => u.ProduitId == id).First();
        }*/



        #region Test moq

        [TestMethod]
        public void PostProduit_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IProduitRepository>();
            var pdtController = new ProduitController(mockRepository.Object);
            Produit pdt = new Produit
            {
                GenreId = 1,
                CategorieId = 1,
                ProduitNom = "PostProduit" ,
                ProduitDescription = "postProduit est un test",
            };
            // Act
            var actionResult = pdtController.PostProduit(pdt).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Produit>), "Pas un ActionResult<produit>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Produit), "Pas un produit");
            pdt.CategorieId = ((Produit)result.Value).CategorieId;
            Assert.AreEqual(pdt, (Produit)result.Value, "Produits pas identiques");
        }

        [TestMethod]
        public void DeleteProduit_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Produit pdt = new Produit
            {
                ProduitId = 1,
                GenreId = 1,
                CategorieId = 1,
                ProduitNom = "PostProduit",
                ProduitDescription = "postProduit est un test",
            };
            var mockRepository = new Mock<IProduitRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(pdt);
            var pdtController = new ProduitController(mockRepository.Object);
            // Act
            var actionResult = pdtController.DeleteProduit(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult");
        }

        [TestMethod]
        public void PutProduitTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Produit pdt = new Produit
            {
                ProduitId = 1,
                GenreId = 1,
                CategorieId = 1,
                ProduitNom = "Produit",
                ProduitDescription = "Produit est un test",
            };
            Produit pdtModif = new Produit
            {
                ProduitId = 1,
                GenreId = 1,
                CategorieId = 1,
                ProduitNom = "NomModifierProduit",
                ProduitDescription = "ModifProduit est un test",
            };

            var mockRepository = new Mock<IProduitRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(pdt);
            var pdtController = new ProduitController(mockRepository.Object);

            // Act
            var actionResult = pdtController.PutProduit(1, pdtModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetProduitById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Produit pdt = new Produit
            {
                ProduitId = 1,
                GenreId = 1,
                CategorieId = 1,
                ProduitNom = "NomModifierProduit",
                ProduitDescription = "ModifProduit est un test",
            };

            var mockRepository = new Mock<IProduitRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(pdt);
            var pdtController = new ProduitController(mockRepository.Object);

            // Act
            var actionResult = pdtController.GetProduitById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(pdt, actionResult.Value as Produit);
        }

        [TestMethod]
        public void GetProduitById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IProduitRepository>();
            var pdtController = new ProduitController(mockRepository.Object);
            // Act
            var actionResult = pdtController.GetProduitById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }

        [TestMethod]
        public void Postcategorie_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IProduitRepository>();
            var pdtController = new ProduitController(mockRepository.Object);

            Produit pdt = new Produit
            {
                ProduitId = 1,
                GenreId = 1,
                CategorieId = 1,
                ProduitNom = "NomModifierProduit",
                ProduitDescription = "ModifProduit est un test",
            };

            // Act
            var actionResult = pdtController.PostProduit(pdt).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Produit>), "Pas un ActionResult<Produit>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Produit), "Pas une Produit");
            pdt.ProduitId = ((Produit)result.Value).ProduitId;
            Assert.AreEqual(pdt, (Produit)result.Value, "Categories pas identiques");
        }


        #endregion
    }
}