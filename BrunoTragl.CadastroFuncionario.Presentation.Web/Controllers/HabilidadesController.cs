using BrunoTragl.CadastroFuncionario.Business.Application.Interfaces;
using BrunoTragl.CadastroFuncionario.Presentation.Web.Models;
using System;
using System.Web.Mvc;

namespace BrunoTragl.CadastroFuncionario.Presentation.Web.Controllers
{
    public class HabilidadesController : Controller
    {
        IHabilidadeApplication _habilidadeApplication;
        public HabilidadesController(IHabilidadeApplication habilidadeApplication)
        {
            _habilidadeApplication = habilidadeApplication;
        }
        public JsonResult Get(int id)
        {
            try
            {
                return Json(HabilidadeViewModel.ToView(_habilidadeApplication.Get(id)), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult Get(int funcionarioId, int pageSize, int page)
        {
            try
            {
                return Json(HabilidadeViewModel.ToView(_habilidadeApplication.Get(funcionarioId, pageSize, page)), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult Post(HabilidadeViewModel vm)
        {
            try
            {
                return Json(HabilidadeViewModel.ToView(_habilidadeApplication.Post(vm.ToDomain())), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult Put(HabilidadeViewModel vm)
        {
            try
            {
                return Json(HabilidadeViewModel.ToView(_habilidadeApplication.Put(vm.Id, vm.ToDomain())), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult Patch(HabilidadeViewModel vm)
        {
            try
            {
                return Json(HabilidadeViewModel.ToView(_habilidadeApplication.Patch(vm.Id, vm.ToDomain())), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult Delete(int id)
        {
            try
            {
                return Json(_habilidadeApplication.Delete(id), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}