using Microsoft.VisualStudio.TestTools.UnitTesting;
using FIFA_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Action = FIFA_API.Models.EntityFramework.Action;
using FIFA_API.Models.DataManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FIFA_API.Controllers.Tests
{
    [TestClass()]
    public class ActionControllerTests
    {
        private FifaDbContext _context;
        private ActionController _controller;
        private IDataRepository<Action> _dataRepository;

        public ActionControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=localhost;port=5432;Database=FifaDB; uid=postgres; password=postgres;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new ActionManager(_context);
            _controller = new ActionController(_dataRepository);
        }


        [TestMethod()]
        public void ActionControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetAllActionsTest_OK()
        {
            var expected = _context.Action.ToList();

            var results = _controller.GetAllAction().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetActionByIdTest_OK()
        {
            Action expected = _context.Action.Where(u => u.ActionId == 1).First();

            var result = _controller.GetActionById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes actions");
        }



        [TestMethod()]
        public void GetActionByIdTest_NONOK()
        {
            var result = _controller.GetActionById(0).Result;

            Assert.IsNull(result.Value);
        }

        [TestMethod()]
        public void PutActionTest_OK()
        {
            Action expected = _context.Action.Where(u => u.ActionId == 1).First();
            expected.TypeAction = "Test";

            var result = _controller.PutAction(1, expected).Result;
            Action resultUser = _controller.GetActionById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultUser, "Pas les mêmes actions");
        }

        /*[TestMethod]
        public void PostActionTest_OK()
        {
            // Arrange
            Action actAtester = new Action()
            {
                TypeAction = "Test" + DateTime.UtcNow.ToString()
            };
            // Act
            var result = _controller.PostAction(actAtester).Result;

            // Assert
            Action? catRecupere = _context.Action.Where(u => u.TypeAction.ToUpper() == actAtester.TypeAction.ToUpper()).FirstOrDefault();

            actAtester.ActionId = catRecupere.ActionId;

            Assert.AreEqual(catRecupere, actAtester, "Actions pas identiques");
        }


        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeleteActionTest_OK()
        {
            Action user = new Action()
            {
                TypeAction = "Test" + DateTime.UtcNow.ToString()
            };

            _context.Action.Add(user);
            _context.SaveChanges();

            int id = _context.Action.Where(u => u.TypeAction == user.TypeAction).First().ActionId;

            var resultDelete = _controller.DeleteAction(id).Result;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
            _context.Action.Where(u => u.ActionId == id).First();
        }*/


        #region Test moq

        [TestMethod]
        public void PostAction_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Action>>();
            var catController = new ActionController(mockRepository.Object);
            Action cat = new Action
            {
                TypeAction = "Test"
            };
            // Act
            var actionResult = catController.PostAction(cat).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Action>), "Pas un ActionResult<Action>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Action), "Pas une Action");
            cat.ActionId = ((Action)result.Value).ActionId;
            Assert.AreEqual(cat, (Action)result.Value, "Actions pas identiques");
        }

        [TestMethod]
        public void DeleteAction_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Action act = new Action
            {
                ActionId = 1,
                TypeAction = "Test"
            };
            var mockRepository = new Mock<IDataRepository<Action>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(act);
            var actController = new ActionController(mockRepository.Object);
            // Act
            var actionResult = actController.DeleteAction(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutCategorieTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Action act = new Action
            {
                ActionId = 1,
                TypeAction = "Test"
            };
            Action actModif = new Action
            {
                ActionId = 1,
                TypeAction = "Update"
            };

            var mockRepository = new Mock<IDataRepository<Action>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(act);
            var catController = new ActionController(mockRepository.Object);

            // Act
            var actionResult = catController.PutAction(1, actModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }


        [TestMethod]
        public void GetActionById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Action act = new Action
            {
                ActionId = 1,
                TypeAction = "Test"
            };

            var mockRepository = new Mock<IDataRepository<Action>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(act);
            var actController = new ActionController(mockRepository.Object);

            // Act
            var actionResult = actController.GetActionById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(act, actionResult.Value as Action);
        }

        [TestMethod]
        public void GetActionById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Action>>();
            var catController = new ActionController(mockRepository.Object);
            // Act
            var actionResult = catController.GetActionById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}