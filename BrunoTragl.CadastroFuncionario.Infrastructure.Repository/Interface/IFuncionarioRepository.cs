using BrunoTragl.CadastroFuncionario.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BrunoTragl.CadastroFuncionario.Infrastructure.Repository.Interface
{
    public interface IFuncionarioRepository
    {
        Funcionario Add(Funcionario funcionario);
        void Edit(Funcionario funcionario);
        Funcionario Find(int id);
        IEnumerable<Funcionario> Paged(int page_size, int page);
        int Count();
        IEnumerable<Funcionario> Search(Expression<Func<Funcionario, bool>> exp);
        void SetValues(Funcionario entity, Funcionario externo);
    }
}
