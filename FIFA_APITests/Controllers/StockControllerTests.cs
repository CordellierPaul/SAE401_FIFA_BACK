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
    public class StockControllerTests
    {
        private FifaDbContext _context;
        private StockController _controller;
        private IDataRepositoryWithoutStr<Stock> _dataRepository;

        public StockControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new StockManager(_context);
            _controller = new StockController(_dataRepository);
        }


        [TestMethod()]
        public void StockControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetStocksTest_OK()
        {
            var expected = _context.Stock.ToList();

            var results = _controller.GetStock().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetStockByIdTest_OK()
        {
            Stock expected = _context.Stock.Where(u => u.StockId == 1).First();

            var result = _controller.GetStockById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Stocks");
        }



        [TestMethod()]
        public void GetStockByIdTest_NONOK()
        {
            var result = _controller.GetStockById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutStockTest_OK()
        {
            Stock expected = _context.Stock.Where(u => u.StockId == 1).First();
            expected.QuantiteStockee = 3;

            var result = _controller.PutStock(1, expected).Result;
            Stock resultStock = _controller.GetStockById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultStock, "Pas les mêmes Stocks");
        }*/


        #endregion

        #region Test moq

        [TestMethod]
        public void PostStock_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepositoryWithoutStr<Stock>>();
            var stkController = new StockController(mockRepository.Object);
            Stock stk = new Stock
            {
                QuantiteStockee = 3
            };
            // Act
            var actionResult = stkController.PostStock(stk).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Stock>), "Pas un ActionResult<Stock>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Stock), "Pas un Stock");
            stk.StockId = ((Stock)result.Value).StockId;
            Assert.AreEqual(stk, (Stock)result.Value, "Stocks pas identiques");
        }

        [TestMethod]
        public void DeleteStock_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Stock stk = new Stock
            {
                StockId = 1,
                QuantiteStockee = 3
            };
            var mockRepository = new Mock<IDataRepositoryWithoutStr<Stock>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(stk);
            var stkController = new StockController(mockRepository.Object);
            // Act
            var actionResult = stkController.DeleteStock(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutStockTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Stock stk = new Stock
            {
                StockId = 1,
                QuantiteStockee = 3
            };
            Stock stkModif = new Stock
            {
                StockId = 1,
                QuantiteStockee = 5
            };

            var mockRepository = new Mock<IDataRepositoryWithoutStr<Stock>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(stk);
            var stkController = new StockController(mockRepository.Object);

            // Act
            var actionResult = stkController.PutStock(1, stkModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetStockById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Stock stk = new Stock
            {
                StockId = 1,
                QuantiteStockee = 5
            };

            var mockRepository = new Mock<IDataRepositoryWithoutStr<Stock>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(stk);
            var stkController = new StockController(mockRepository.Object);

            // Act
            var actionResult = stkController.GetStockById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(stk, actionResult.Value as Stock);
        }

        [TestMethod]
        public void GetStockById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepositoryWithoutStr<Stock>>();
            var stkController = new StockController(mockRepository.Object);
            // Act
            var actionResult = stkController.GetStockById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}