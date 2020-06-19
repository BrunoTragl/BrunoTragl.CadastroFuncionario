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
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly IContext _context;
        public FuncionarioRepository(IContext context)
        {
            _context = context;                
        }
        public void SetValues(Funcionario entity, Funcionario externo)
        {
            try
            {
                _context.Entry(entity).CurrentValues.SetValues(externo);
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
                _context.Funcionarios.Add(funcionario);
                _context.SaveChanges();
                return funcionario;
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
                _context.Funcionarios.Include("Habilidades");
                IEnumerable<Funcionario> funcionarios = _context.Funcionarios.OrderBy(f => f.Nome);
                if (page_size <= 0 && page <= 0)
                {
                    return funcionarios.Take(30);
                }
                else if (page > 0)
                {
                    page_size = page_size > 0 ? page_size : 30;
                    int skip = (page * page_size) - page_size;
                    return funcionarios.Skip(skip).Take(page_size);
                }

                return funcionarios.Take(page_size);
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
                return _context.Funcionarios.Count();
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
                _context.Entry(funcionario).State = EntityState.Modified;
                _context.SaveChanges();
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
                _context.Funcionarios.Include("Habilidades");
                return _context.Funcionarios.Find(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Funcionario> Search(Expression<Func<Funcionario, bool>> exp)
        {
            try
            {
                _context.Funcionarios.Include("Habilidade");
                return _context.Funcionarios.Where(exp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
