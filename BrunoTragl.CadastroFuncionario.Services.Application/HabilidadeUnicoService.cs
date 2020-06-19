using BrunoTragl.CadastroFuncionario.Domain.Model;
using BrunoTragl.CadastroFuncionario.Infrastructure.Repository.Interface;
using BrunoTragl.CadastroFuncionario.Services.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BrunoTragl.CadastroFuncionario.Services.Application
{
    public class HabilidadeUnicoService : IHabilidadeUnicoService
    {
        IHabilidadeUnicoRepository _repository;
        public HabilidadeUnicoService(IHabilidadeUnicoRepository repository)
        {
            _repository = repository;
        }
        public HabilidadeUnico Add(HabilidadeUnico habilidadeUnico)
        {
            try
            {
                return _repository.Add(habilidadeUnico);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<HabilidadeUnico> All()
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
        public void Delete(HabilidadeUnico habilidadeUnico)
        {
            try
            {
                _repository.Delete(habilidadeUnico);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Edit(HabilidadeUnico habilidadeUnico)
        {
            try
            {
                _repository.Edit(habilidadeUnico);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public HabilidadeUnico Find(int id)
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
        public IEnumerable<HabilidadeUnico> Search(Expression<Func<HabilidadeUnico, bool>> exp)
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
