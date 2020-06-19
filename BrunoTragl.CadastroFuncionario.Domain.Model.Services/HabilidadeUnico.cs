using Newtonsoft.Json;

namespace BrunoTragl.CadastroFuncionario.Domain.Model.Services
{
    public class HabilidadeUnico
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        public string Habilidade { get; set; }
    }
}
