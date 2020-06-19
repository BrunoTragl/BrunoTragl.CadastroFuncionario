using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrunoTragl.CadastroFuncionario.Presentation.WebAPI;
using BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Controllers;

namespace BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Organizar
            HomeController controller = new HomeController();

            // Agir
            ViewResult result = controller.Index() as ViewResult;

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
