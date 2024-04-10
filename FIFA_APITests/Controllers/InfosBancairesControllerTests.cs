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
    public class InfosBancairesControllerTests
    {
        private FifaDbContext _context;
        private InfosBancairesController _controller;
        private IDataRepository<InfosBancaires> _dataRepository;

        public InfosBancairesControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new InfosBancairesManager(_context);
            _controller = new InfosBancairesController(_dataRepository);
        }


        [TestMethod()]
        public void InfosBancairesControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetInfosBancairesByIdTest_OK()
        {
            InfosBancaires expected = _context.InfosBancaires.Where(u => u.InfosBancairesId == 1).First();

            var result = _controller.GetInfosBancairesById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes InfosBancairess");
        }



        [TestMethod()]
        public void GetInfosBancairesByIdTest_NONOK()
        {
            var result = _controller.GetInfosBancairesById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutInfosBancairesTest_OK()
        {
            InfosBancaires expected = _context.InfosBancaires.Where(u => u.InfosBancairesId == 1).First();
            expected.InfosBancaireNumCarte = "123456789012";

            var result = _controller.PutInfosBancaires(1, expected).Result;
            InfosBancaires resultInfosBancaires = _controller.GetInfosBancairesById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultInfosBancaires, "Pas les mêmes InfosBancairess");
        }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostInfosBancaires_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<InfosBancaires>>();
            var ibcController = new InfosBancairesController(mockRepository.Object);
            InfosBancaires ibc = new InfosBancaires
            {
                InfosBancaireNumCarte = "123456789012"
            };
            // Act
            var actionResult = ibcController.PostInfosBancaires(ibc).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<InfosBancaires>), "Pas un ActionResult<InfosBancaires>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(InfosBancaires), "Pas un InfosBancaires");
            ibc.InfosBancairesId = ((InfosBancaires)result.Value).InfosBancairesId;
            Assert.AreEqual(ibc, (InfosBancaires)result.Value, "InfosBancairess pas identiques");
        }

        [TestMethod]
        public void DeleteInfosBancaires_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            InfosBancaires ibc = new InfosBancaires
            {
                InfosBancairesId = 1,
                InfosBancaireNumCarte = "123456789012"
            };
            var mockRepository = new Mock<IDataRepository<InfosBancaires>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(ibc);
            var ibcController = new InfosBancairesController(mockRepository.Object);
            // Act
            var actionResult = ibcController.DeleteInfosBancaires(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutInfosBancairesTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            InfosBancaires ibc = new InfosBancaires
            {
                InfosBancairesId = 1,
                InfosBancaireNumCarte = "123456789012"
            };
            InfosBancaires ibcModif = new InfosBancaires
            {
                InfosBancairesId = 1,
                InfosBancaireNumCarte = "123654789012"
            };

            var mockRepository = new Mock<IDataRepository<InfosBancaires>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(ibc);
            var ibcController = new InfosBancairesController(mockRepository.Object);

            // Act
            var actionResult = ibcController.PutInfosBancaires(1, ibcModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetInfosBancairesById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            InfosBancaires ibc = new InfosBancaires
            {
                InfosBancairesId = 1,
                InfosBancaireNumCarte = "123456789012"
            };

            var mockRepository = new Mock<IDataRepository<InfosBancaires>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(ibc);
            var ibcController = new InfosBancairesController(mockRepository.Object);

            // Act
            var actionResult = ibcController.GetInfosBancairesById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(ibc, actionResult.Value as InfosBancaires);
        }

        [TestMethod]
        public void GetInfosBancairesById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<InfosBancaires>>();
            var ibcController = new InfosBancairesController(mockRepository.Object);
            // Act
            var actionResult = ibcController.GetInfosBancairesById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}