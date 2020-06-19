using BrunoTragl.CadastroFuncionario.Domain.Model.Services;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;

namespace BrunoTragl.CadastroFuncionario.Presentation.Web.Models
{
    public class PagedViewModel
    {
        public int Pagina { get; set; }
        public int QuantidadePorPagina { get; set; }
        public int QuantidadePaginas { get; set; }
        public int QuantidadeItens { get; set; }
        public int QuantidadeTotalItens { get; set; }

        public static PagedViewModel ToView(Paged paged)
        {
            PagedViewModel vm = new PagedViewModel();
            vm.Pagina = paged.Pagina;
            vm.QuantidadeItens = paged.QuantidadeItens;
            vm.QuantidadePaginas = paged.QuantidadePaginas;
            vm.QuantidadePorPagina = paged.QuantidadePorPagina;
            vm.QuantidadeTotalItens = paged.QuantidadeTotalItens;
            return vm;
        }
    }
}