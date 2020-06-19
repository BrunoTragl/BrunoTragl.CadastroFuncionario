using BrunoTragl.CadastroFuncionario.Domain.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BrunoTragl.CadastroFuncionario.Infrastructure.Data
{
    public class CadastroFuncionarioContext : DbContext, IContext
    {
        public CadastroFuncionarioContext()
            : base("CadastroFuncionarioContext")
        {
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.ValidateOnSaveEnabled = true;
            Database.SetInitializer(new CadastroFuncionarioInitializer());
        }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Habilidade> Habilidades { get; set; }
        public DbSet<HabilidadeUnico> HabilidadeUnico { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().ToTable("funcionarios");
            modelBuilder.Entity<Habilidade>().ToTable("habilidades");
            modelBuilder.Entity<HabilidadeUnico>().ToTable("habilidadesUnico");
            modelBuilder.Conventions.Remove(new PluralizingTableNameConvention());
        }
    }
}
