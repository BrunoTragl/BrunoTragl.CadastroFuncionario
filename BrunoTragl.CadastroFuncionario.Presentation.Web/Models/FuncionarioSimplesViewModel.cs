using BrunoTragl.CadastroFuncionario.Domain.Model.Services;
using BrunoTragl.CadastroFuncionario.Presentation.Web.Enumerable;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrunoTragl.CadastroFuncionario.Presentation.Web.Models
{
    public class FuncionarioSimplesViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public bool Ativo { get; set; }

        public static FuncionarioSimplesViewModel ToView(int id, FuncionarioSimples funcionario)
        {
            var vm = new FuncionarioSimplesViewModel
            {
                Id = id,
                Nome = funcionario.Nome,
                Sobrenome = funcionario.Sobrenome,
                Email = funcionario.Email,
                DataNascimento = funcionario.DataNascimento,
                Sexo = funcionario.Sexo,
                Ativo = funcionario.Ativo
            };

            return vm;
        }
        public static FuncionarioSimplesViewModel Converter(FuncionarioViewModel funcionario)
        {
            var dataSplit = funcionario.DataNascimento.Split('/');
            DateTime dtNascimento = new DateTime(int.Parse(dataSplit[2]), int.Parse(dataSplit[1]), int.Parse(dataSplit[0]));
            var vm = new FuncionarioSimplesViewModel
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Sobrenome = funcionario.Sobrenome,
                Email = funcionario.Email,
                DataNascimento = dtNascimento,
                Sexo = funcionario.Sexo,
                Ativo = funcionario.Ativo
            };

            return vm;
        }
        public FuncionarioSimples ToDomain()
        {
            var domain = new FuncionarioSimples
            {
                Nome = Nome,
                Sobrenome = Sobrenome,
                Email = Email,
                DataNascimento = DataNascimento,
                Sexo = Sexo == SexoEnum.Masculino.ToString() ? "M" : "F",
                Ativo = Ativo
            };
            return domain;
        }
    }
}