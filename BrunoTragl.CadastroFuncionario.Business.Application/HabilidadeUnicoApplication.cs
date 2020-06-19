using BrunoTragl.CadastroFuncionario.Business.Application.Interfaces;
using BrunoTragl.CadastroFuncionario.Business.Service.Interfaces;
using BrunoTragl.CadastroFuncionario.Domain.Model.Services;
using System;
using System.Collections.Generic;

namespace BrunoTragl.CadastroFuncionario.Business.Application
{
    public class HabilidadeUnicoApplication : IHabilidadeUnicoApplication
    {
        private readonly IHabilidadeUnicoHttpContext _apiContext;
        public HabilidadeUnicoApplication(IHabilidadeUnicoHttpContext apiContext)
        {
            _apiContext = apiContext;
        }
        public IEnumerable<HabilidadeUnico> Get()
        {
            try
            {
                return _apiContext.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public HabilidadeUnico Get(int id)
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
        public HabilidadeUnico Post(HabilidadeUnico habilidade)
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
