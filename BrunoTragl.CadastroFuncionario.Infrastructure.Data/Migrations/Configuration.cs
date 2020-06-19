namespace BrunoTragl.CadastroFuncionario.Infrastructure.Data.Migrations
{
    using BrunoTragl.CadastroFuncionario.Domain.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DropCreateDatabaseIfModelChanges<BrunoTragl.CadastroFuncionario.Infrastructure.Data.CadastroFuncionarioContext>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BrunoTragl.CadastroFuncionario.Infrastructure.Data.CadastroFuncionarioContext context)
        {
            
        }
    }
}
