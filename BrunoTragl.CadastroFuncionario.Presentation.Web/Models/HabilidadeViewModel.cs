using BrunoTragl.CadastroFuncionario.Domain.Model.Services;
using BrunoTragl.CadastroFuncionario.Presentation.Web.Controllers;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrunoTragl.CadastroFuncionario.Presentation.Web.Models
{
    public class HabilidadeViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int FuncionarioId { get; set; }
        public bool Selecionado { get; set; }

        public static HabilidadeViewModel ToView(Habilidade habilidade)
        {
            return new HabilidadeViewModel
            {
                Id = habilidade.Id,
                Nome = habilidade.Nome
            };
        }
        public static HabilidadePagedViewModel ToView(HabilidadePaged habilidade)
        {
            var vm = new HabilidadePagedViewModel();
            vm.Habilidades = new List<HabilidadeViewModel>();

            if (habilidade.Habilidades != null)
            {
                var habilidadesVM = new List<HabilidadeViewModel>();
                habilidade.Habilidades.ForEach((h) =>
                {
                    habilidadesVM.Add(new HabilidadeViewModel
                    {
                        Id = h.Id,
                        Nome = h.Nome
                    });
                });
            }

            vm.Paginacao = new PagedViewModel();
            if (habilidade.Paginacao != null)
            {
                vm.Paginacao.Pagina = habilidade.Paginacao.Pagina;
                vm.Paginacao.QuantidadeItens = habilidade.Paginacao.QuantidadeItens;
                vm.Paginacao.QuantidadePaginas = habilidade.Paginacao.QuantidadePaginas;
                vm.Paginacao.QuantidadePorPagina = habilidade.Paginacao.QuantidadePorPagina;
                vm.Paginacao.QuantidadeTotalItens = habilidade.Paginacao.QuantidadeTotalItens;
            }            
            return vm;
        }
        public static List<HabilidadeViewModel> ListToView(IEnumerable<HabilidadeUnico> habilidades)
        {
            List<HabilidadeViewModel> lista = new List<HabilidadeViewModel>();
            habilidades.ForEach((h) => lista.Add(ToView(h)));
            return lista;
        }
        private static HabilidadeViewModel ToView(HabilidadeUnico h)
        {
            return new HabilidadeViewModel
            {
                Nome = h.Habilidade
            };
        }
        public Habilidade ToDomain()
        {
            return new Habilidade
            {
                Id = Id,
                Nome = Nome,
                FuncionarioID = FuncionarioId
            };
        }        
    }
}