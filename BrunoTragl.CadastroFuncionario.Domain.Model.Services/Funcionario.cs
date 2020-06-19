using System;
using System.Collections.Generic;

namespace BrunoTragl.CadastroFuncionario.Domain.Model.Services
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public IEnumerable<Habilidade> Habilidades { get; set; }
        public bool Ativo { get; set; }
    }
}
