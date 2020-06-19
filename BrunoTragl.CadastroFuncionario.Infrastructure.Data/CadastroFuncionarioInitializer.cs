using BrunoTragl.CadastroFuncionario.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BrunoTragl.CadastroFuncionario.Infrastructure.Data
{
    public class CadastroFuncionarioInitializer : DropCreateDatabaseIfModelChanges<CadastroFuncionarioContext>
    {
        protected override void Seed(CadastroFuncionarioContext context)
        {
            var funcionarios = new List<Funcionario>
            {
                new Funcionario() { Nome = "Bruno", Sobrenome = "Tragl", DataNascimento = new DateTime(1989,11,16), Email = "brunotragl@outlook.com", Sexo = "M", Ativo = true },
                new Funcionario() { Nome = "Aline", Sobrenome = "Pereira", DataNascimento = new DateTime(1989,11,7), Email = "aline@outlook.com", Sexo = "F", Ativo = true },
                new Funcionario() { Nome = "Thiago", Sobrenome = "Constelo", DataNascimento = new DateTime(1984,10,21), Email = "thiago@outlook.com", Sexo = "M", Ativo = true },
                new Funcionario() { Nome = "Gustavo Henrique", Sobrenome = "Souza", DataNascimento = new DateTime(1983,5,13), Email = "gustavo@outlook.com", Sexo = "M", Ativo = true },
                new Funcionario() { Nome = "Guilherme", Sobrenome = "Otavio", DataNascimento = new DateTime(1995,05,10), Email = "guilherme@outlook.com", Sexo = "M", Ativo = true },
                new Funcionario() { Nome = "Junior", Sobrenome = "Damasceno", DataNascimento = new DateTime(1973,08,19), Email = "junior@outlook.com", Sexo = "M", Ativo = true },
                new Funcionario() { Nome = "Jorge", Sobrenome = "Rubens", DataNascimento = new DateTime(1992,02,15), Email = "jorge@outlook.com", Sexo = "M", Ativo = true },
                new Funcionario() { Nome = "Italo", Sobrenome = "Gonçalvez", DataNascimento = new DateTime(1980,06,13), Email = "italo@outlook.com", Sexo = "M", Ativo = true },
                new Funcionario() { Nome = "Rita", Sobrenome = "de Cassias", DataNascimento = new DateTime(1975,12,02), Email = "rita@outlook.com", Sexo = "F", Ativo = true },
                new Funcionario() { Nome = "Rosangela", Sobrenome = "Alves", DataNascimento = new DateTime(1969,09,05), Email = "rosangela@outlook.com", Sexo = "F", Ativo = true },
                new Funcionario() { Nome = "Rebeca", Sobrenome = "Amadio", DataNascimento = new DateTime(2000,01,18), Email = "rebeca@outlook.com", Sexo = "F", Ativo = true },
                new Funcionario() { Nome = "Roberta", Sobrenome = "Uislan", DataNascimento = new DateTime(1990,02,20), Email = "roberta@outlook.com", Sexo = "F", Ativo = true },
                new Funcionario() { Nome = "Fernanda", Sobrenome = "Amaral", DataNascimento = new DateTime(1979,11,13), Email = "fernanda@outlook.com", Sexo = "F", Ativo = true },
                new Funcionario() { Nome = "Fernando", Sobrenome = "Tevez", DataNascimento = new DateTime(1955,10,21), Email = "fernando@outlook.com", Sexo = "M", Ativo = true },
                new Funcionario() { Nome = "Jucelino", Sobrenome = "Grugel", DataNascimento = new DateTime(1963,04,17), Email = "jucelino@outlook.com", Sexo = "M", Ativo = true },
                new Funcionario() { Nome = "Francisco", Sobrenome = "Nunes", DataNascimento = new DateTime(1978,03,29), Email = "francisco@outlook.com", Sexo = "M", Ativo = true },
                new Funcionario() { Nome = "Amabile", Sobrenome = "Batista", DataNascimento = new DateTime(1993,05,04), Email = "amabile@outlook.com", Sexo = "F", Ativo = true },
                new Funcionario() { Nome = "Henrique", Sobrenome = "Junior", DataNascimento = new DateTime(1995,07,16), Email = "henrique@outlook.com", Sexo = "M", Ativo = true },
                new Funcionario() { Nome = "Jhonatan", Sobrenome = "Castelo", DataNascimento = new DateTime(1994,09,21), Email = "jhonatan@outlook.com", Sexo = "M", Ativo = true },
                new Funcionario() { Nome = "Yago", Sobrenome = "Fernandes", DataNascimento = new DateTime(1981,07,26), Email = "yago@outlook.com", Sexo = "M", Ativo = true },
                new Funcionario() { Nome = "Alice", Sobrenome = "Miguel", DataNascimento = new DateTime(2000,03,28), Email = "alice@outlook.com", Sexo = "F", Ativo = true },
                new Funcionario() { Nome = "Sophia", Sobrenome = "Arthur", DataNascimento = new DateTime(1969,11,02), Email = "sophia@outlook.com", Sexo = "F", Ativo = true },
                new Funcionario() { Nome = "Helena", Sobrenome = "Bernardo", DataNascimento = new DateTime(1989,05,03), Email = "helena@outlook.com", Sexo = "F", Ativo = true },
                new Funcionario() { Nome = "Valentina", Sobrenome = "Rocha", DataNascimento = new DateTime(1989,04,11), Email = "valentina@outlook.com", Sexo = "F", Ativo = true },
                new Funcionario() { Nome = "Laura", Sobrenome = "Davi", DataNascimento = new DateTime(1999,06,12), Email = "laura@outlook.com", Sexo = "F", Ativo = true },
                new Funcionario() { Nome = "Isabella", Sobrenome = "Lourenço", DataNascimento = new DateTime(1998,05,20), Email = "isabella@outlook.com", Sexo = "F", Ativo = true }
            };

            funcionarios.ForEach(f => context.Funcionarios.Add(f));
            context.SaveChanges();

            var habilidades = new List<Habilidade>
            {
                new Habilidade { Nome = "C#", FuncionarioID = 1 },
                new Habilidade { Nome = "ASP", FuncionarioID = 1 },
                new Habilidade { Nome = "SQL", FuncionarioID = 2 },
                new Habilidade { Nome = "C#", FuncionarioID = 2 },
                new Habilidade { Nome = "ASP", FuncionarioID = 3 },
                new Habilidade { Nome = "Angular", FuncionarioID = 3 },
                new Habilidade { Nome = "Java", FuncionarioID = 3 },
                new Habilidade { Nome = "C#", FuncionarioID = 4 },
                new Habilidade { Nome = "SQL", FuncionarioID = 4 },
                new Habilidade { Nome = "ASP", FuncionarioID = 5 },
                new Habilidade { Nome = "C#", FuncionarioID = 5 },
                new Habilidade { Nome = "ASP", FuncionarioID = 6 },
                new Habilidade { Nome = "C#", FuncionarioID = 6 },
                new Habilidade { Nome = "SQL", FuncionarioID = 6 },
                new Habilidade { Nome = "Angular", FuncionarioID = 6 },
                new Habilidade { Nome = "Java", FuncionarioID = 6 },
                new Habilidade { Nome = "Java", FuncionarioID = 7 },
                new Habilidade { Nome = "C#", FuncionarioID = 7 },
                new Habilidade { Nome = "SQL", FuncionarioID = 8 },
                new Habilidade { Nome = "C#", FuncionarioID = 9 },
                new Habilidade { Nome = "Java", FuncionarioID = 9 },
                new Habilidade { Nome = "SQL", FuncionarioID = 9 },
                new Habilidade { Nome = "C#", FuncionarioID = 10 },
                new Habilidade { Nome = "Angular", FuncionarioID = 10 },
                new Habilidade { Nome = "SQL", FuncionarioID = 10 },
                new Habilidade { Nome = "Angular", FuncionarioID = 11 },
                new Habilidade { Nome = "ASP", FuncionarioID = 12 },
                new Habilidade { Nome = "SQL", FuncionarioID = 13 },
                new Habilidade { Nome = "ASP", FuncionarioID = 14 },
                new Habilidade { Nome = "SQL", FuncionarioID = 14 },
                new Habilidade { Nome = "Angular", FuncionarioID = 15 },
                new Habilidade { Nome = "C#", FuncionarioID = 15 },
                new Habilidade { Nome = "C#", FuncionarioID = 16 },
                new Habilidade { Nome = "Angular", FuncionarioID = 17 },
                new Habilidade { Nome = "ASP", FuncionarioID = 18 },
                new Habilidade { Nome = "SQL", FuncionarioID = 19 },
                new Habilidade { Nome = "ASP", FuncionarioID = 20 },
                new Habilidade { Nome = "SQL", FuncionarioID = 21 },
                new Habilidade { Nome = "C#", FuncionarioID = 22 },
                new Habilidade { Nome = "ASP", FuncionarioID = 23 },
                new Habilidade { Nome = "Java", FuncionarioID = 24 },
                new Habilidade { Nome = "SQL", FuncionarioID = 24 },
                new Habilidade { Nome = "Java", FuncionarioID = 25 },
                new Habilidade { Nome = "C#", FuncionarioID = 25 },
                new Habilidade { Nome = "Java", FuncionarioID = 26 },
                new Habilidade { Nome = "ASP", FuncionarioID = 26 }
            };

            habilidades.ForEach(h => context.Habilidades.Add(h));
            context.SaveChanges();

            var habilidadesUnicas = new List<HabilidadeUnico>
            {
                new HabilidadeUnico { Habilidade = "Angular" },
                new HabilidadeUnico { Habilidade = "ASP" },
                new HabilidadeUnico { Habilidade = "C#" },
                new HabilidadeUnico { Habilidade = "Java" },
                new HabilidadeUnico { Habilidade = "SQL" }
            };

            habilidadesUnicas.ForEach(h => context.HabilidadeUnico.Add(h));
            context.SaveChanges();
        }
    }
}
