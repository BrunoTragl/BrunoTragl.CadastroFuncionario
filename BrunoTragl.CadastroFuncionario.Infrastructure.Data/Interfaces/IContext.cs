using BrunoTragl.CadastroFuncionario.Domain.Model;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BrunoTragl.CadastroFuncionario.Infrastructure.Data
{
    public interface IContext
    {
        DbSet<Funcionario> Funcionarios { get; set; }
        DbSet<HabilidadeUnico> HabilidadeUnico { get; set; }
        DbSet<Habilidade> Habilidades { get; set; }
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
    }
}
