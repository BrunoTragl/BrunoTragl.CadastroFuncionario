using System;
using System.Collections.Generic;

namespace BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Model
{
    public class FuncionarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public IEnumerable<HabilidadeModel> Habilidades { get; set; }
        public bool Ativo { get; set; }
    }
}