using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Integrated3M.Framework.API;
using Integrated3M.Framework.API.Controllers;

namespace Integrated3M.Framework.API.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
