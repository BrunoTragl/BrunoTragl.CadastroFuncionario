using System;
using System.Web.Http;

namespace BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Controllers
{
    public class BaseController : ApiController
    {
        protected IHttpActionResult BadRequestCampoObrigatorio(string campo)
        {
            try
            {
                return BadRequest($"O campo {campo} é obrigatório.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}