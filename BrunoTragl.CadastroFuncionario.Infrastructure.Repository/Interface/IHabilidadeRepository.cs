using BrunoTragl.CadastroFuncionario.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BrunoTragl.CadastroFuncionario.Infrastructure.Repository.Interface
{
    public interface IHabilidadeRepository
    {
        Habilidade Add(Habilidade habilidade);
        void Edit(Habilidade habilidade);
        Habilidade Find(int id);
        IEnumerable<Habilidade> FindByName(string nome);
        IEnumerable<Habilidade> All();
        IEnumerable<string> AllNames();
        IEnumerable<Habilidade> Paged(int idFuncionario, int page_size, int page);
        int Count();
        IEnumerable<Habilidade> Search(Expression<Func<Habilidade, bool>> exp);
        void Delete(Habilidade habilidade);
    }
}
