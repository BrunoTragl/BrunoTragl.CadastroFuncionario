using BrunoTragl.CadastroFuncionario.Domain.Model.Services;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;

namespace BrunoTragl.CadastroFuncionario.Presentation.Web.Models
{
    public class FuncionarioPagedViewModel
    {
        public IEnumerable<FuncionarioViewModel> Funcionarios { get; set; }
        public PagedViewModel Paginacao { get; set; }

        public static FuncionarioPagedViewModel ToView(FuncionarioPaged paged)
        {
            var vm = new FuncionarioPagedViewModel();
            var funcionariosVM = new List<FuncionarioViewModel>();
            paged.Funcionarios.ForEach((f) =>
            {
                var habilidadesVM = new List<HabilidadeViewModel>();
                f.Habilidades.ForEach((h) =>
                {
                    habilidadesVM.Add(HabilidadeViewModel.ToView(h));
                });
                funcionariosVM.Add(FuncionarioViewModel.ToView(f));
            });

            vm.Funcionarios = funcionariosVM;
            vm.Paginacao = PagedViewModel.ToView(paged.Paginacao);
            return vm;
        }
    }
}