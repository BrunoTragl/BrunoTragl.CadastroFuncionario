using System;
using System.Collections.Generic;

namespace BrunoTragl.CadastroFuncionario.Domain.Model
{
    public class Funcionario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
