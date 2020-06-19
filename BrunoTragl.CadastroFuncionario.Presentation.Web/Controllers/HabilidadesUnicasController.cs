using BrunoTragl.CadastroFuncionario.Business.Application.Interfaces;
using BrunoTragl.CadastroFuncionario.Presentation.Web.Models;
using System;
using System.Web.Mvc;

namespace BrunoTragl.CadastroFuncionario.Presentation.Web.Controllers
{
    public class HabilidadesUnicasController : Controller
    {
        IHabilidadeUnicoApplication _habilidadeUnicoApplication;
        public HabilidadesUnicasController(IHabilidadeUnicoApplication habilidadeUnicoApplication)
        {
            _habilidadeUnicoApplication = habilidadeUnicoApplication;
        }
        [HttpGet]
        public JsonResult List()
        {
            try
            {
                return Json(HabilidadeUnicaViewModel.ListToView(_habilidadeUnicoApplication.Get()), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public JsonResult Get(int id)
        {
            try
            {
                return Json(HabilidadeUnicaViewModel.ToView(_habilidadeUnicoApplication.Get(id)), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult Post(HabilidadeUnicaViewModel vm)
        {
            try
            {
                HabilidadeUnicaViewModel.ToView(_habilidadeUnicoApplication.Post(vm.ToDomain()));
                TempData["sucesso"] = true;
                return RedirectToAction("Index", "Configuracao");
            }
            catch (Exception ex)
            {
                TempData["sucesso"] = false;
                TempData["erro"] = ex;
                return RedirectToAction("Index", "Configuracao");
            }
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                return Json(_habilidadeUnicoApplication.Delete(id), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}