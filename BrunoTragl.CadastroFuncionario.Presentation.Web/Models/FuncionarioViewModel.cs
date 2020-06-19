using BrunoTragl.CadastroFuncionario.Domain.Model.Services;
using BrunoTragl.CadastroFuncionario.Presentation.Web.Enumerable;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Web.Caching;

namespace BrunoTragl.CadastroFuncionario.Presentation.Web.Models
{
    public class FuncionarioViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(150)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(150)]
        public string Sobrenome { get; set; }
        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string DataNascimento { get; set; }
        public string Idade { get; set; }
        [MaxLength(250)]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Sexo { get; set; }
        public List<HabilidadeViewModel> Habilidades { get; set; }
        public bool Ativo { get; set; }

        public static FuncionarioViewModel ToView(Funcionario funcionario)
        {
            var agora = DateTime.Now;
            var nascimento = funcionario.DataNascimento;
            int idade = agora.Year - nascimento.Year;
            if (agora.Month < nascimento.Month || (agora.Month == nascimento.Month && agora.Day < nascimento.Day))
                idade--;
            
            var vm = new FuncionarioViewModel
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Sobrenome = funcionario.Sobrenome,
                Email = funcionario.Email,
                DataNascimento = funcionario.DataNascimento.ToString("dd/MM/yyyy"),
                Idade = idade.ToString(),
                Sexo = funcionario.Sexo == "F" ? SexoEnum.Feminino.ToString() : SexoEnum.Masculino.ToString(),
                Ativo = funcionario.Ativo
            };
            
            var habilidades = new List<HabilidadeViewModel>();
            funcionario.Habilidades.ForEach((habilidade) => habilidades.Add(new HabilidadeViewModel
            {
                Id = habilidade.Id,
                Nome = habilidade.Nome
            }));

            vm.Habilidades = habilidades;
            return vm;
        }
        public Funcionario ToDomain()
        {
            var data = DataNascimento.Split('/');
            var domain = new Funcionario
            {
                Id = Id,
                Nome = Nome,
                Sobrenome = Sobrenome,
                Email = Email,
                DataNascimento = new DateTime(int.Parse(data[2]), int.Parse(data[1]), int.Parse(data[0])),
                Sexo = Sexo == SexoEnum.Masculino.ToString() ? "M" : "F",
                Ativo = Ativo
            };
            var habilidades = new List<Habilidade>();
            Habilidades.ForEach((habilidade) => habilidades.Add(new Habilidade
            {
                Nome = habilidade.Nome
            }));
            domain.Habilidades = habilidades;
            return domain;
        }
    }
}