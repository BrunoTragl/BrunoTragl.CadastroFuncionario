using BrunoTragl.CadastroFuncionario.Business.Application.Interfaces;
using BrunoTragl.CadastroFuncionario.Business.Service.Interfaces;
using BrunoTragl.CadastroFuncionario.Domain.Model.Services;
using System;

namespace BrunoTragl.CadastroFuncionario.Business.Application
{
    public class HabilidadeApplication : IHabilidadeApplication
    {
        private readonly IHabilidadeHttpContext _apiContext;
        public HabilidadeApplication(IHabilidadeHttpContext apiContext)
        {
            _apiContext = apiContext;
        }
        public Habilidade Get(int id)
        {
            try
            {
                return _apiContext.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public HabilidadePaged Get(int funcionarioId, int pageSize, int page)
        {
            try
            {
                return _apiContext.Get(funcionarioId, pageSize, page);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Habilidade Post(Habilidade habilidade)
        {
            try
            {
                return _apiContext.Post(habilidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Habilidade Put(int id, Habilidade habilidade)
        {
            try
            {
                return _apiContext.Put(id, habilidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Habilidade Patch(int id, Habilidade habilidade)
        {
            try
            {
                return _apiContext.Patch(id, habilidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Delete(int id)
        {
            try
            {
                return _apiContext.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
