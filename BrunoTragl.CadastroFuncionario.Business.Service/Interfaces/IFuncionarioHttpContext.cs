using BrunoTragl.CadastroFuncionario.Domain.Model.Services;

namespace BrunoTragl.CadastroFuncionario.Business.Service.Interfaces
{
    public interface IFuncionarioHttpContext
    {
        Funcionario Get(int id);
        FuncionarioPaged Get(int pageSize, int page);
        Funcionario Post(Funcionario funcionario);
        FuncionarioSimples Put(int id, FuncionarioSimples funcionario);
        FuncionarioSimples Patch(int id, FuncionarioAtivacao funcionario);
    }
}
