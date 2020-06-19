using BrunoTragl.CadastroFuncionario.Presentation.WebAPI.AuthorizationProviders;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Configuration;
using System.Web.Http;

[assembly: OwinStartup(typeof(BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Startup))]

namespace BrunoTragl.CadastroFuncionario.Presentation.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            UnityConfig.RegisterComponents(config);
            ConfigureOAuth(app);
            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oAuthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = false,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(GetAccessTokenExpireSeconds()),
                Provider = new SimpleAuthServerProvider()
            };

            app.UseOAuthAuthorizationServer(oAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private double GetAccessTokenExpireSeconds()
        {
            string accessTokenExpireSetting = ConfigurationManager.AppSettings.Get("accessTokenExpire");
            double accessTokenExpire = 0;
            
            if (!double.TryParse(accessTokenExpireSetting, out accessTokenExpire))
                accessTokenExpire = 300;
            
            return accessTokenExpire;
        }
    }
}