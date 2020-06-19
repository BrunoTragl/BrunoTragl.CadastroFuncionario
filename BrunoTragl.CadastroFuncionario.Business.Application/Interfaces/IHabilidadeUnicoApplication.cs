using BrunoTragl.CadastroFuncionario.Domain.Model.Services;
using System.Collections.Generic;

namespace BrunoTragl.CadastroFuncionario.Business.Application.Interfaces
{
    public interface IHabilidadeUnicoApplication
    {
        IEnumerable<HabilidadeUnico> Get();
        HabilidadeUnico Get(int id);
        HabilidadeUnico Post(HabilidadeUnico habilidade);
        string Delete(int id);
    }
}
