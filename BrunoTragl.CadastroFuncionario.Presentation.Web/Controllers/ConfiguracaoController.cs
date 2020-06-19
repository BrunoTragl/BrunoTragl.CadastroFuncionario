using BrunoTragl.CadastroFuncionario.Business.Application.Interfaces;
using BrunoTragl.CadastroFuncionario.Presentation.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BrunoTragl.CadastroFuncionario.Presentation.Web.Controllers
{
    public class ConfiguracaoController : Controller
    {
        private readonly IHabilidadeUnicoApplication _habilidadeUnicaApplication;
        public ConfiguracaoController(IHabilidadeUnicoApplication habilidadeUnicaApplication)
        {
            _habilidadeUnicaApplication = habilidadeUnicaApplication;
        }
        public ActionResult Index()
        {
            return View(HabilidadeUnicaViewModel.ListToView(_habilidadeUnicaApplication.Get()));
        }
    }
}