using Newtonsoft.Json;

namespace BrunoTragl.CadastroFuncionario.Domain.Model.Services
{
    public class AccessToken
    {
        [JsonProperty("access_token")]
        public string Token { get; set; }
        [JsonProperty("expires_in")]
        public int TokenExpireIn { get; set; }
    }
}
