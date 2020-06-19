using BrunoTragl.CadastroFuncionario.Domain.Model;
using BrunoTragl.CadastroFuncionario.Infrastructure.Data;
using BrunoTragl.CadastroFuncionario.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BrunoTragl.CadastroFuncionario.Infrastructure.Repository
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        private readonly IContext _context;
        public HabilidadeRepository(IContext context)
        {
            _context = context;
        }
        public Habilidade Add(Habilidade habilidade)
        {
            try
            {
                _context.Habilidades.Add(habilidade);
                _context.SaveChanges();
                return habilidade;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Habilidade habilidade)
        {
            try
            {
                _context.Habilidades.Attach(habilidade);
                _context.Habilidades.Remove(habilidade);
                _context.SaveChanges();
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
                _context.Entry(habilidade);
                _context.SaveChanges();
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
                //_context.Habilidades.Include("Funcionarios");
                return _context.Habilidades.Find(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Habilidade> FindByName(string nome)
        {
            try
            {
                _context.Habilidades.Include("Funcionario");
                return _context.Habilidades.Where(h => h.Nome == nome);
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
                return _context.Habilidades;
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
                return _context.Habilidades.Select(h => h.Nome).Distinct();
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
                return _context.Habilidades.Where(exp);
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
                var habilidadesFuncionario = _context.Habilidades.Include("Funcionario").Where(hf => hf.Funcionario.ID == idFuncionario).ToList();
                if (habilidadesFuncionario.Count() == 0)
                    return habilidadesFuncionario;

                if (page_size <= 0 && page <= 0)
                {
                    return habilidadesFuncionario.Take(30).ToList();
                }

                if (page > 0)
                {
                    page_size = page_size > 0 ? page_size : 30;
                    int skip = (page * page_size) - page_size;
                    return habilidadesFuncionario.Skip(skip).Take(page_size).ToList();
                }

                return habilidadesFuncionario.Take(page_size).ToList();
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
                return _context.Habilidades.Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
