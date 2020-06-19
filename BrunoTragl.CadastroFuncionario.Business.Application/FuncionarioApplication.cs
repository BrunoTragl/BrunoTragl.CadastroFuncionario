using BrunoTragl.CadastroFuncionario.Business.Application.Interfaces;
using BrunoTragl.CadastroFuncionario.Business.Service.Interfaces;
using BrunoTragl.CadastroFuncionario.Domain.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrunoTragl.CadastroFuncionario.Business.Application
{
    public class FuncionarioApplication : IFuncionarioApplication
    {
        private readonly IFuncionarioHttpContext _apiContext;
        public FuncionarioApplication(IFuncionarioHttpContext apiContext)
        {
            _apiContext = apiContext;
        }
        public Funcionario Get(int id)
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
        public FuncionarioPaged Get(int pageSize, int page)
        {
            try
            {
                return _apiContext.Get(pageSize, page);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Funcionario Post(Funcionario funcionario)
        {
            try
            {
                return _apiContext.Post(funcionario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FuncionarioSimples Put(int id, FuncionarioSimples funcionario)
        {
            try
            {
                return _apiContext.Put(id, funcionario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FuncionarioSimples Patch(int id, FuncionarioAtivacao funcionario)
        {
            try
            {
                return _apiContext.Patch(id, funcionario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
