using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BrunoTragl.CadastroFuncionario.Domain.Model.Services
{
    public class HabilidadePaged
    {
        [JsonProperty("Data")]
        public IEnumerable<Habilidade> Habilidades { get; set; }
        [JsonProperty("PagedData")]
        public Paged Paginacao { get; set; }
    }
}
