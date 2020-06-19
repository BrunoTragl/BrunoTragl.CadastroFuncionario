namespace BrunoTragl.CadastroFuncionario.Domain.Model
{
    public class Habilidade
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int FuncionarioID { get; set; }
        public virtual Funcionario Funcionario { get; set; }
    }
}
