using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PAF.DAS.Service.BL;
using PAF.DAS.Service.Interfaces;
using PAF.DAS.Service.Model;
using System;

namespace PAF.DAS.Service.Tests
{
    [TestClass]
    public class PaperServiceTests
    {
        [TestMethod]
        public void GetPaperSuccessfuTest()
        {
            //Arrange
            Paper expectedPaper = new Paper()
            {
                Id = new Guid(),
                DocumentType = DocumentType.CaseStudy,
                Author = "Juan",
                Title = "Sample",
                YearSubmitted="2017"         
            };
            var mockPaperService = new Mock<IPaperService>();
            var mockPaperDAL = new Mock<IPaperDAL>();
            mockPaperService.Setup(x => x.Get(It.IsAny<Guid>())).Returns(expectedPaper);
            mockPaperDAL.Setup(x => x.Get(It.IsAny<Guid>())).Returns(expectedPaper);

            //Act
            PaperService paperService = new PaperService(mockPaperDAL.Object);
            var result = paperService.Get(new Guid());

            //Assert
            Assert.AreSame(expectedPaper, result);
        }
        [TestMethod]
        public void GetPaperReturnsNullTest()
        {
            //Arrange
            var mockPaperService = new Mock<IPaperService>();
            var mockPaperDAL = new Mock<IPaperDAL>();
            mockPaperDAL.Setup(x => x.Get(It.IsAny<Guid>())).Returns((Paper)null);
            mockPaperService.Setup(x => x.Get(It.IsAny<Guid>())).Returns((Paper)null);

            //Act
            PaperService paperService = new PaperService(mockPaperDAL.Object);
            var result = paperService.Get(new Guid());

            //Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetPaperReturnsExceptionTest()
        {
            //Arrange
            var mockPaperService = new Mock<IPaperService>();
            var mockPaperDAL = new Mock<IPaperDAL>();
            mockPaperDAL.Setup(x => x.Get(It.IsAny<Guid>())).Throws(new Exception());
            mockPaperService.Setup(x => x.Get(It.IsAny<Guid>())).Throws(new Exception());

            //Act
            PaperService paperService= new PaperService(mockPaperDAL.Object);
            var result = paperService.Get(new Guid());

            //Assert
            //Expected exception was thrown
        }
    }
}
