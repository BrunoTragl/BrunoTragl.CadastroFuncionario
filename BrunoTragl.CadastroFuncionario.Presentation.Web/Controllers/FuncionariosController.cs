using BrunoTragl.CadastroFuncionario.Business.Application.Interfaces;
using BrunoTragl.CadastroFuncionario.Presentation.Web.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace BrunoTragl.CadastroFuncionario.Presentation.Web.Controllers
{
    public class FuncionariosController : Controller
    {
        IFuncionarioApplication _funcionarioApplication;
        IHabilidadeUnicoApplication _habilidadeUnicoApplication;
        public FuncionariosController(IFuncionarioApplication funcionarioApplication, IHabilidadeUnicoApplication habilidadeUnicoApplication)
        {
            _funcionarioApplication = funcionarioApplication;
            _habilidadeUnicoApplication = habilidadeUnicoApplication;
        }
        public ActionResult Detalhes(int id)
        {
            return View(FuncionarioViewModel.ToView(_funcionarioApplication.Get(id)));
        }
        public ActionResult Novo()
        {
            try
            {
                FuncionarioViewModel vm = new FuncionarioViewModel();
                vm.Habilidades = HabilidadeViewModel.ListToView(_habilidadeUnicoApplication.Get());
                return View(vm);
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
                return Json(FuncionarioViewModel.ToView(_funcionarioApplication.Get(id)), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public JsonResult List(int pageSize, int page)
        {
            try
            {
                return Json(FuncionarioPagedViewModel.ToView(_funcionarioApplication.Get(pageSize, page)), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult Post(FuncionarioViewModel vm)
        {
            try
            {
                if (!vm.Habilidades.Any(h => h.Selecionado))
                {
                    ModelState.AddModelError("Habilidades", "O funcionário deve ter no mínimo uma habilidade.");
                }

                if (ModelState.IsValid)
                {
                    vm.Habilidades = vm.Habilidades.Where(h => h.Selecionado).ToList();
                    vm.Ativo = true;
                    FuncionarioViewModel novo = FuncionarioViewModel.ToView(_funcionarioApplication.Post(vm.ToDomain()));
                    return RedirectToAction("Detalhes", new { id = novo.Id });
                }

                return View("Novo", vm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        public ActionResult Put(FuncionarioViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FuncionarioSimplesViewModel vmSimples = FuncionarioSimplesViewModel.Converter(vm);
                    var retorno = FuncionarioSimplesViewModel.ToView(vm.Id, _funcionarioApplication.Put(vm.Id, vmSimples.ToDomain()));
                    TempData["sucesso"] = true;
                    return RedirectToAction("Detalhes", new { id = retorno.Id });
                }

                FuncionarioViewModel fEntity = FuncionarioViewModel.ToView(_funcionarioApplication.Get(vm.Id));
                vm.Habilidades = fEntity.Habilidades;
                return View("Detalhes", vm);
            }
            catch (Exception ex)
            {
                TempData["sucesso"] = false;
                TempData["erro"] = ex;
                return RedirectToAction("Detalhes", new { id = vm.Id });
            }
        }
        [HttpPost]
        public JsonResult Ativacao(FuncionarioAtivacaoViewModel vm)
        {
            try
            {
                return Json(_funcionarioApplication.Patch(vm.Id, vm.ToDomain()), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}