using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PAF.DAS.Service.BL;
using PAF.DAS.Service.Interfaces;
using PAF.DAS.Service.Model;
using System;

namespace PAF.DAS.Service.Test
{
    [TestClass]
    public class PaperArchieveServiceTests
    {
        [TestMethod]
        public void AddPaperArchieveSuccessfulTest()
        {
            //Arrange
            PaperArchieve expectedPaper = new PaperArchieve()
            {
                ID = new Guid(),
                PaperID = new Guid(),
                FileName = "Sample File",
                Location = "Sample Location"
            };
            var mockPaperArchieveService = new Mock<IPaperArchieveService>();
            var mockPaperArchieveDAL = new Mock<IPaperArchieveDAL>();
            mockPaperArchieveService.Setup(x => x.Add(It.IsAny<PaperArchieve>())).Returns(expectedPaper);
            mockPaperArchieveDAL.Setup(x => x.Add(It.IsAny<PaperArchieve>())).Returns(expectedPaper);

            //Act
            PaperArchieveService paperServiceArchieve = new PaperArchieveService(mockPaperArchieveDAL.Object);
            var result = paperServiceArchieve.Add(expectedPaper);

            //Assert
            Assert.AreSame(expectedPaper, result);
        }
        [TestMethod]
        public void AddPaperArchieveNotSuccessfulTest()
        {
            //Arrange
            PaperArchieve expectedPaper = new PaperArchieve()
            {
                ID = new Guid(),
                PaperID = new Guid(),
                Location = "Sample Location"
            };
            var mockPaperArchieveService = new Mock<IPaperArchieveService>();
            var mockPaperArchieveDAL = new Mock<IPaperArchieveDAL>();
            mockPaperArchieveService.Setup(x => x.Add(It.IsAny<PaperArchieve>())).Returns(expectedPaper);
            mockPaperArchieveDAL.Setup(x => x.Add(It.IsAny<PaperArchieve>())).Returns(expectedPaper);

            //Act
            PaperArchieveService paperServiceArchieve = new PaperArchieveService(mockPaperArchieveDAL.Object);
            var result = paperServiceArchieve.Add(expectedPaper);

            //Assert
            Assert.AreSame(expectedPaper, result);
        }
        [TestMethod]
        public void GetPaperArchieveSuccessfulTest()
        {
            //Arrange
            PaperArchieve expectedPaper = new PaperArchieve()
            {
                ID = new Guid(),
                PaperID = new Guid(),
                FileName = "Sample File",
                Location = "Sample Location"
            };
            var mockPaperArchieveService = new Mock<IPaperArchieveService>();
            var mockPaperArchieveDAL = new Mock<IPaperArchieveDAL>();
            mockPaperArchieveDAL.Setup(x => x.Get(It.IsAny<Guid>())).Returns(expectedPaper);
            mockPaperArchieveService.Setup(x => x.Get(It.IsAny<Guid>())).Returns(expectedPaper);

            //Act
            PaperArchieveService paperServiceArchieve = new PaperArchieveService(mockPaperArchieveDAL.Object);
            var result = paperServiceArchieve.Get(new Guid());

            //Assert
            Assert.AreSame(expectedPaper, result);
        }
        [TestMethod]
        public void GetPaperArchieveReturnsNullTest()
        {
            //Arrange
            var mockPaperArchieveService = new Mock<IPaperArchieveService>();
            var mockPaperArchieveDAL = new Mock<IPaperArchieveDAL>();
            mockPaperArchieveDAL.Setup(x => x.Get(It.IsAny<Guid>())).Returns((PaperArchieve)null);
            mockPaperArchieveService.Setup(x => x.Get(It.IsAny<Guid>())).Returns((PaperArchieve)null);

            //Act
            PaperArchieveService paperServiceArchieve = new PaperArchieveService(mockPaperArchieveDAL.Object);
            var result = paperServiceArchieve.Get(new Guid());

            //Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetPaperArchieveReturnsExceptionTest()
        {
            //Arrange
            var mockPaperArchieveService = new Mock<IPaperArchieveService>();
            var mockPaperArchieveDAL = new Mock<IPaperArchieveDAL>();
            mockPaperArchieveDAL.Setup(x => x.Get(It.IsAny<Guid>())).Throws(new Exception());
            mockPaperArchieveService.Setup(x => x.Get(It.IsAny<Guid>())).Throws(new Exception());

            //Act
            PaperArchieveService paperServiceArchieve = new PaperArchieveService(mockPaperArchieveDAL.Object);
            var result = paperServiceArchieve.Get(new Guid());

            //Assert
            //Expected exception was thrown
        }
    }
}
