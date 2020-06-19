using BrunoTragl.CadastroFuncionario.Domain.Model;
using BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Helpers;
using BrunoTragl.CadastroFuncionario.Services.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;

namespace BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Controllers
{
    [Authorize]
    public class FuncionarioController : BaseController
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }
        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest($"Identificador {id} inválido");

                Funcionario funcionario = _funcionarioService.Find(id);

                if (funcionario == null)
                    return NotFound();

                return Ok(FuncionarioHelpers.DePara(funcionario));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        public IHttpActionResult Get([FromUri] int page_size, [FromUri] int page)
        {
            try
            {
                IEnumerable<Funcionario> funcionarios = _funcionarioService.Paged(page_size, page);
                return Ok(FuncionarioHelpers.Paged(funcionarios.ToList(), _funcionarioService.Count(), page, page_size));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        public IHttpActionResult Post([FromBody] Funcionario funcionario)
        {
            try
            {
                string campoInvalido = string.Empty;
                if (!FuncionarioHelpers.RequestValido(funcionario, out campoInvalido))
                    return BadRequestCampoObrigatorio(campoInvalido);

                return Ok(FuncionarioHelpers.DePara(_funcionarioService.Add(funcionario)));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Funcionario funcionario)
        {
            try
            {
                if (id <= 0)
                    return BadRequest($"Identificador {id} inválido");

                Funcionario funcionarioEntity = _funcionarioService.Find(id);

                if (funcionario == null)
                    return NotFound();

                _funcionarioService.Edit(FuncionarioHelpers.DePara(funcionarioEntity, funcionario));

                return Ok(FuncionarioHelpers.DePara(funcionarioEntity));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpDelete]
        public IHttpActionResult Patch([FromUri] int id, [FromBody] Delta<Funcionario> funcionario)
        {
            try
            {
                if (id < 0)
                    return BadRequest($"Identificador {id} inválido");

                Funcionario funcionarioEntity = _funcionarioService.Find(id);

                if (funcionarioEntity == null)
                    return NotFound();

                funcionario.Patch(funcionarioEntity);
                


                _funcionarioService.Edit(funcionarioEntity);

                return Ok(FuncionarioHelpers.DePara(funcionarioEntity));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
