using BrunoTragl.CadastroFuncionario.Domain.Model;
using BrunoTragl.CadastroFuncionario.Infrastructure.Repository.Interface;
using BrunoTragl.CadastroFuncionario.Services.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BrunoTragl.CadastroFuncionario.Services.Application
{
    public class FuncionarioService : IFuncionarioService
    {
        IFuncionarioRepository _repository;
        public FuncionarioService(IFuncionarioRepository repository)
        {
            _repository = repository;
        }
        public void SetValues(Funcionario entity, Funcionario externo)
        {
            try
            {
                _repository.SetValues(entity, externo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Funcionario Add(Funcionario funcionario)
        {
            try
            {
                return _repository.Add(funcionario);                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Funcionario> Paged(int page_size, int page)
        {
            try
            {
                return _repository.Paged(page_size, page);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Count()
        {
            try
            {
                return _repository.Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Edit(Funcionario funcionario)
        {
            try
            {
                _repository.Edit(funcionario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Funcionario Find(int id)
        {
            try
            {
                return _repository.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Funcionario> Search(Expression<Func<Funcionario, bool>> exp)
        {
            try
            {
                return _repository.Search(exp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
