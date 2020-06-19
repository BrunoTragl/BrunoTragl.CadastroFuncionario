using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BrunoTragl.CadastroFuncionario.Domain.Model.Services
{
    public class FuncionarioPaged
    {
        [JsonProperty("Data")]
        public IEnumerable<Funcionario> Funcionarios { get; set; }
        [JsonProperty("PagedData")]
        public Paged Paginacao { get; set; }
    }
}
