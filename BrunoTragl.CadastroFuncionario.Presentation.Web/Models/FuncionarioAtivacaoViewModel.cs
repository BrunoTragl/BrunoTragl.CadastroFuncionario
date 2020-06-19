using BrunoTragl.CadastroFuncionario.Domain.Model.Services;

namespace BrunoTragl.CadastroFuncionario.Presentation.Web.Models
{
    public class FuncionarioAtivacaoViewModel
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }

        public FuncionarioAtivacao ToDomain()
        {
            return new FuncionarioAtivacao
            {
                Id = Id,
                Ativo = Ativo
            };
        }
    }
}