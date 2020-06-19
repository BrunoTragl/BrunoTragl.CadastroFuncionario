using System.Web.Http;
using Unity;
using Unity.WebApi;
using BrunoTragl.CadastroFuncionario.Infrastructure.Data;
using BrunoTragl.CadastroFuncionario.Infrastructure.Repository;
using BrunoTragl.CadastroFuncionario.Infrastructure.Repository.Interface;
using BrunoTragl.CadastroFuncionario.Services.Application;
using BrunoTragl.CadastroFuncionario.Services.Application.Interfaces;
using Unity.Lifetime;

namespace BrunoTragl.CadastroFuncionario.Presentation.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IFuncionarioRepository, FuncionarioRepository>(new TransientLifetimeManager());
            container.RegisterType<IHabilidadeUnicoRepository, HabilidadeUnicoRepository>(new TransientLifetimeManager());
            container.RegisterType<IHabilidadeRepository, HabilidadeRepository>(new TransientLifetimeManager());

            container.RegisterType<IFuncionarioService, FuncionarioService>(new TransientLifetimeManager());
            container.RegisterType<IHabilidadeUnicoService, HabilidadeUnicoService>(new TransientLifetimeManager());
            container.RegisterType<IHabilidadeService, HabilidadeService>(new TransientLifetimeManager());

            container.RegisterType<IContext, CadastroFuncionarioContext>(new TransientLifetimeManager());

            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}