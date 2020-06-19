using BrunoTragl.CadastroFuncionario.Domain.Model;
using BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Helpers;
using BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Model;
using BrunoTragl.CadastroFuncionario.Services.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Routing;

namespace BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Controllers
{
    public class HabilidadeController : BaseController
    {
        private readonly IHabilidadeService _habilidadeService;
        public HabilidadeController(IHabilidadeService habilidadeService)
        {
            _habilidadeService = habilidadeService;
        }
        public IHttpActionResult Get([FromUri] int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest($"Identificador {id} inválido");

                Habilidade habilidade = _habilidadeService.Find(id);
                if (habilidade == null)
                    return NotFound();

                return Ok(HabilidadeHelpers.DePara(habilidade));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult List([FromUri] string nome)
        {
            try
            {
                if (string.IsNullOrEmpty(nome))
                    return BadRequest($"Deve ser informado o nome da habilidade.");

                IEnumerable<Habilidade> habilidades = _habilidadeService.FindByName(nome);
                if (habilidades == null || habilidades.Count() == 0)
                    return NotFound();

                //TODO: Fazer de/para lista de habilidades
                //HabilidadeHelpers.DePara(habilidades);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Get([FromUri] int id_funcionario, [FromUri] int page_size, [FromUri] int page)
        {
            try
            {
                if (id_funcionario < 0)
                    return BadRequest($"Identificador id_funcionario {id_funcionario} inválido");

                IEnumerable<Habilidade> habilidades = _habilidadeService.Paged(id_funcionario, page_size, page);
                return Ok(HabilidadeHelpers.Paged(habilidades.ToList(), habilidades.Count(), _habilidadeService.Count(), page, page_size));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Post([FromBody] Habilidade habilidade)
        {
            try
            {
                string campoInvalido = string.Empty;
                if (habilidade == null || string.IsNullOrEmpty(habilidade.Nome))
                    return BadRequestCampoObrigatorio("Nome");

                return Ok(_habilidadeService.Add(habilidade));
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Put([FromUri] int id, [FromBody] Habilidade habilidade)
        {
            try
            {
                if (id < 0)
                    return BadRequest($"Identificador {id} inválido");

                Habilidade habilidadeEntity = _habilidadeService.Find(id);

                if (habilidade == null)
                    return NotFound();

                _habilidadeService.Edit(HabilidadeHelpers.DePara(habilidadeEntity, habilidade));

                return Ok(HabilidadeHelpers.DePara(habilidadeEntity));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Patch([FromUri] int id, [FromBody] Delta<Habilidade> habilidade)
        {
            try
            {
                if (id < 0)
                    return BadRequest($"Identificador {id} inválido");

                Habilidade habilidadeEntity = _habilidadeService.Find(id);

                if (habilidadeEntity == null)
                    return NotFound();

                habilidade.Patch(habilidadeEntity);

                _habilidadeService.Edit(habilidadeEntity);

                return Ok(HabilidadeHelpers.DePara(habilidadeEntity));
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

                Habilidade habilidadeEntity = _habilidadeService.Find(id);

                if (habilidadeEntity == null)
                    return NotFound();

                _habilidadeService.Delete(habilidadeEntity);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
