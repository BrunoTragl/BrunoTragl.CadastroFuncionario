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
    public class HabilidadeUnicoRepository : IHabilidadeUnicoRepository
    {
        private readonly IContext _context;
        public HabilidadeUnicoRepository(IContext context)
        {
            _context = context;
        }
        public HabilidadeUnico Add(HabilidadeUnico habilidadeUnico)
        {
            try
            {
                _context.HabilidadeUnico.Add(habilidadeUnico);
                _context.SaveChanges();
                return habilidadeUnico;
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
                return _context.HabilidadeUnico;
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
                _context.HabilidadeUnico.Attach(habilidadeUnico);
                _context.HabilidadeUnico.Remove(habilidadeUnico);
                _context.SaveChanges();
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
                _context.Entry(habilidadeUnico).State = EntityState.Modified;
                _context.SaveChanges();
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
                return _context.HabilidadeUnico.Find(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<HabilidadeUnico> Search(Expression<Func<HabilidadeUnico, bool>> exp)
        {
            try
            {
                return _context.HabilidadeUnico.Where(exp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
