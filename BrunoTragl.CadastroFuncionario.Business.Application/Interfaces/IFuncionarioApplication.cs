using BrunoTragl.CadastroFuncionario.Domain.Model.Services;

namespace BrunoTragl.CadastroFuncionario.Business.Application.Interfaces
{
    public interface IFuncionarioApplication
    {
        Funcionario Get(int id);
        FuncionarioPaged Get(int pageSize, int page);
        Funcionario Post(Funcionario funcionario);
        FuncionarioSimples Put(int id, FuncionarioSimples funcionario);
        FuncionarioSimples Patch(int id, FuncionarioAtivacao funcionario);
    }
}
