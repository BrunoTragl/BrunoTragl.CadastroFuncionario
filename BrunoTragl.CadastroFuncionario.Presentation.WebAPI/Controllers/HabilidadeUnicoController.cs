using BrunoTragl.CadastroFuncionario.Domain.Model;
using BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Helpers;
using BrunoTragl.CadastroFuncionario.Services.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Controllers
{
    public class HabilidadeUnicoController : BaseController
    {
        private readonly IHabilidadeUnicoService _habilidadeUnicoService;
        public HabilidadeUnicoController(IHabilidadeUnicoService habilidadeUnicoService)
        {
            _habilidadeUnicoService = habilidadeUnicoService;
        }
        public IHttpActionResult Get([FromUri] int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest($"Identificador {id} inválido");

                HabilidadeUnico habilidadeUnico = _habilidadeUnicoService.Find(id);

                if (habilidadeUnico == null)
                    return NotFound();

                return Ok(habilidadeUnico);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<HabilidadeUnico> habilidadesUnicos = _habilidadeUnicoService.All();
                
                if (habilidadesUnicos.Count() == 0)
                    return NotFound();

                return Ok(habilidadesUnicos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Post([FromBody] HabilidadeUnico habilidadeUnico)
        {
            try
            {
                string campoInvalido = string.Empty;
                if (!HabilidadeUnicoHelpers.RequestValido(habilidadeUnico, out campoInvalido))
                    return BadRequestCampoObrigatorio(campoInvalido);

                return Ok(_habilidadeUnicoService.Add(habilidadeUnico));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Delete([FromUri] int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest($"Identificador {id} inválido");

                HabilidadeUnico habilidadeUnico = _habilidadeUnicoService.Find(id);

                if (habilidadeUnico == null)
                    return NotFound();

                _habilidadeUnicoService.Delete(habilidadeUnico);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
