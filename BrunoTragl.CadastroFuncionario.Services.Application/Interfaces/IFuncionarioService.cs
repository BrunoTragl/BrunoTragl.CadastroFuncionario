using BrunoTragl.CadastroFuncionario.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BrunoTragl.CadastroFuncionario.Services.Application.Interfaces
{
    public interface IFuncionarioService
    {
        Funcionario Add(Funcionario funcionario);
        void Edit(Funcionario funcionario);
        Funcionario Find(int id);
        IEnumerable<Funcionario> Search(Expression<Func<Funcionario, bool>> exp);
        IEnumerable<Funcionario> Paged(int page_size, int page);
        int Count();
        void SetValues(Funcionario entity, Funcionario externo);
    }
}
