using System;
using System.Collections.Generic;

namespace BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Model
{
    public class HabilidadePagedModel
    {
        public IEnumerable<HabilidadeModel> Data { get; set; }
        public Paged PagedData { get; set; }
    }
}