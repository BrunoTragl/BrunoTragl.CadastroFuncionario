using BrunoTragl.CadastroFuncionario.Business.Application;
using BrunoTragl.CadastroFuncionario.Business.Application.Interfaces;
using System.Web.Mvc;

namespace BrunoTragl.CadastroFuncionario.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        IFuncionarioApplication _funcionarioApplication;
        public HomeController(IFuncionarioApplication funcionarioApplication)
        {
            _funcionarioApplication = funcionarioApplication;
        }
        public ActionResult Index()
        {
            var teste = _funcionarioApplication.Get(10, 1);
            return View(teste);
        }
    }
}