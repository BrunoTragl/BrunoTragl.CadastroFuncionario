using BrunoTragl.CadastroFuncionario.Domain.Model.Services;

namespace BrunoTragl.CadastroFuncionario.Business.Application.Interfaces
{
    public interface IHabilidadeApplication
    {
        Habilidade Get(int id);
        HabilidadePaged Get(int funcionarioId, int pageSize, int page);
        Habilidade Post(Habilidade habilidade);
        Habilidade Put(int id, Habilidade habilidade);
        Habilidade Patch(int id, Habilidade habilidade);
        string Delete(int id);
    }
}
