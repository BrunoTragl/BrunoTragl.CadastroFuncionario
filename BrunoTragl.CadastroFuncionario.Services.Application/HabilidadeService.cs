using BrunoTragl.CadastroFuncionario.Domain.Model;
using BrunoTragl.CadastroFuncionario.Infrastructure.Repository.Interface;
using BrunoTragl.CadastroFuncionario.Services.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BrunoTragl.CadastroFuncionario.Services.Application
{
    public class HabilidadeService : IHabilidadeService
    {
        IHabilidadeRepository _repository;
        public HabilidadeService(IHabilidadeRepository repository)
        {
            _repository = repository;
        }
        public Habilidade Add(Habilidade habilidade)
        {
            try
            {
                return _repository.Add(habilidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Habilidade habilidade)
        {
            try
            {
                _repository.Delete(habilidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Edit(Habilidade habilidade)
        {
            try
            {
                _repository.Edit(habilidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Habilidade Find(int id)
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
        public IEnumerable<Habilidade> FindByName(string nome)
        {
            try
            {
                return _repository.FindByName(nome);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Habilidade> All()
        {
            try
            {
                return _repository.All();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<string> AllNames()
        {
            try
            {
                return _repository.AllNames();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Habilidade> Search(Expression<Func<Habilidade, bool>> exp)
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
        public IEnumerable<Habilidade> Paged(int idFuncionario, int page_size, int page)
        {
            try
            {
                return _repository.Paged(idFuncionario, page_size, page);
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
    }
}
