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
    public class DocumentControllerTests
    {
        private FifaDbContext _context;
        private DocumentController _controller;
        private IDataRepository<Document> _dataRepository;

        public DocumentControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FifaDbContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sa13;uid=sa13;password=Fifa13;");
            _context = new FifaDbContext(builder.Options);
            _dataRepository = new DocumentManager(_context);
            _controller = new DocumentController(_dataRepository);
        }


        [TestMethod()]
        public void DocumentControllerTest_OK()
        {
            Assert.IsNotNull(_controller, "Le controlleur est null.");
        }

        [TestMethod()]
        public void GetDocumentsTest_OK()
        {
            var expected = _context.Document.ToList();

            var results = _controller.GetDocument().Result.Value;

            CollectionAssert.AreEqual(expected, results.ToList(), "Pas les mêmes listes");
        }


        [TestMethod()]
        public void GetDocumentByIdTest_OK()
        {
            Document expected = _context.Document.Where(u => u.DocumentId == 1).First();

            var result = _controller.GetDocumentById(1).Result.Value;

            Assert.AreEqual(expected, result, "Pas les mêmes Documents");
        }



        [TestMethod()]
        public void GetDocumentByIdTest_NONOK()
        {
            var result = _controller.GetDocumentById(0).Result;

            Assert.IsNull(result.Value);
        }

        #region Test remplacer par moq

        /*[TestMethod()]
        public void PutDocumentTest_OK()
        {
            Document expected = _context.Document.Where(u => u.DocumentId == 1).First();
            expected.DocumentTitre = "Test";

            var result = _controller.PutDocument(1, expected).Result;
            Document resultDocument = _controller.GetDocumentById(1).Result.Value;

            Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)result).StatusCode, "Pas de code 204");
            Assert.AreEqual(expected, resultDocument, "Pas les mêmes Documents");
        }*/
        /*
                [TestMethod]
                public void PostDocumentTest_OK()
                {
                    // Arrange
                    Document docAtester = new Document()
                    {
                        DocumentTitre = "Test" + DateTime.UtcNow.ToString()
                    };
                    // Act
                    var result = _controller.PostDocument(docAtester).Result;

                    // Assert
                    Document? docRecupere = _context.Document.Where(u => u.DocumentTitre.ToUpper() == docAtester.DocumentTitre.ToUpper()).FirstOrDefault();

                    docAtester.DocumentId = docRecupere.DocumentId;

                    Assert.AreEqual(docRecupere, docAtester, "Documents pas identiques");
                }


                [TestMethod()]
                [ExpectedException(typeof(InvalidOperationException))]
                public void DeleteDocumentTest_OK()
                {
                    Document doc = new Document()
                    {
                        DocumentTitre = "Test" + DateTime.UtcNow.ToString()
                    };

                    _context.Document.Add(doc);
                    _context.SaveChanges();

                    int id = _context.Document.Where(u => u.DocumentTitre == doc.DocumentTitre).First().DocumentId;

                    var resultDelete = _controller.DeleteDocument(id).Result;

                    Assert.AreEqual(StatusCodes.Status204NoContent, ((NoContentResult)resultDelete).StatusCode, "Pas de code 204");
                    _context.Document.Where(u => u.DocumentId == id).First();
                }*/

        #endregion

        #region Test moq

        [TestMethod]
        public void PostDocument_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Document>>();
            var docController = new DocumentController(mockRepository.Object);
            Document doc = new Document
            {
                DocumentTitre = "Test"
            };
            // Act
            var actionResult = docController.PostDocument(doc).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Document>), "Pas un ActionResult<Document>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Document), "Pas un Document");
            doc.DocumentId = ((Document)result.Value).DocumentId;
            Assert.AreEqual(doc, (Document)result.Value, "Documents pas identiques");
        }

        [TestMethod]
        public void DeleteDocument_ModelValidated_DeleteOK_AvecMoq()
        {
            // Arrange
            Document doc = new Document
            {
                DocumentId = 1,
                DocumentTitre = "Test"
            };
            var mockRepository = new Mock<IDataRepository<Document>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(doc);
            var docController = new DocumentController(mockRepository.Object);
            // Act
            var actionResult = docController.DeleteDocument(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutDocumentTest_ModelValidated_PutOK_AvecMoq()
        {
            // Arrange
            Document doc = new Document
            {
                DocumentId = 1,
                DocumentTitre = "Test"
            };
            Document docModif = new Document
            {
                DocumentId = 1,
                DocumentTitre = "Update"
            };

            var mockRepository = new Mock<IDataRepository<Document>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(doc);
            var docController = new DocumentController(mockRepository.Object);

            // Act
            var actionResult = docController.PutDocument(1, docModif).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void GetDocumentById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Document doc = new Document
            {
                DocumentId = 1,
                DocumentTitre = "Testgetidmoq"
            };

            var mockRepository = new Mock<IDataRepository<Document>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(doc);
            var docController = new DocumentController(mockRepository.Object);

            // Act
            var actionResult = docController.GetDocumentById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(doc, actionResult.Value as Document);
        }

        [TestMethod]
        public void GetDocumentById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Document>>();
            var docController = new DocumentController(mockRepository.Object);
            // Act
            var actionResult = docController.GetDocumentById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));

        }


        #endregion
    }
}