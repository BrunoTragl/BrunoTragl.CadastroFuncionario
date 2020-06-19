using System.Collections.Generic;

namespace BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Model
{
    public class Paged
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public int TotalPages { get; set; }
        public int TotalData { get; set; }
    }
}