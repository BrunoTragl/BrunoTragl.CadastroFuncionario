using BrunoTragl.CadastroFuncionario.Domain.Model.Services;
using System.Collections.Generic;

namespace BrunoTragl.CadastroFuncionario.Business.Service.Interfaces
{
    public interface IHabilidadeUnicoHttpContext
    {
        IEnumerable<HabilidadeUnico> Get();
        HabilidadeUnico Get(int id);
        HabilidadeUnico Post(HabilidadeUnico habilidade);
        string Delete(int id);
    }
}
