using Microsoft.Owin.Security.OAuth;
using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BrunoTragl.CadastroFuncionario.Presentation.WebAPI.AuthorizationProviders
{
    public class SimpleAuthServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new string[] { "*" });

            if (CredencialValida(context.UserName, context.Password))
            {
                ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
                context.Validated(identity);
            }
            else
                context.SetError("invalid_user_or_password", "Usuário e/ou senha incorreta.");
        }

        private bool CredencialValida(string clientId, string clientSecret)
        {
            return clientId == ConfigurationManager.AppSettings.Get("clientId")
                   && clientSecret == ConfigurationManager.AppSettings.Get("clientSecret");
        }
    }
}