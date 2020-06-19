using System.Collections.Generic;

namespace BrunoTragl.CadastroFuncionario.Presentation.Web.Models
{
    public class HabilidadePagedViewModel
    {
        public IEnumerable<HabilidadeViewModel> Habilidades { get; set; }        
        public PagedViewModel Paginacao { get; set; }
    }
}