using BrunoTragl.CadastroFuncionario.Domain.Model.Services;
using BrunoTragl.CadastroFuncionario.Presentation.Web.Controllers;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;

namespace BrunoTragl.CadastroFuncionario.Presentation.Web.Models
{
    public class HabilidadeUnicaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public static IEnumerable<HabilidadeUnicaViewModel> ListToView(IEnumerable<HabilidadeUnico> habilidades)
        {
            List<HabilidadeUnicaViewModel> lista = new List<HabilidadeUnicaViewModel>();
            habilidades.ForEach((h) => lista.Add(ToView(h)));
            return lista;
        }
        public static HabilidadeUnicaViewModel ToView(HabilidadeUnico habilidade)
        {
            return new HabilidadeUnicaViewModel
            {
                Id = habilidade.Id,
                Nome = habilidade.Habilidade
            };
        }
        public HabilidadeUnico ToDomain()
        {
            return new HabilidadeUnico
            {
                Id = Id,
                Habilidade = Nome
            };
        }        
    }
}