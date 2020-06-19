using Newtonsoft.Json;

namespace BrunoTragl.CadastroFuncionario.Domain.ModelService
{
    public class AccessToken
    {
        [JsonIgnore()]
        public string Token { get; set; }
    }
}
