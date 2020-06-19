using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BrunoTragl.CadastroFuncionario.Domain.Model.Services
{
    public class Paged
    {
        [JsonProperty("Page")]
        public int Pagina { get; set; }
        [JsonProperty("PageSize")]
        public int QuantidadePorPagina { get; set; }
        [JsonProperty("TotalPages")]
        public int QuantidadePaginas { get; set; }
        [JsonProperty("Count")]
        public int QuantidadeItens { get; set; }
        [JsonProperty("TotalData")]
        public int QuantidadeTotalItens { get; set; }
    }
}
