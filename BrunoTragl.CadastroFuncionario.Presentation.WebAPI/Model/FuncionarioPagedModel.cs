using System;
using System.Collections.Generic;

namespace BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Model
{
    public class FuncionarioPagedModel
    {
        public IEnumerable<FuncionarioModel> Data { get; set; }
        public Paged PagedData { get; set; }
    }
}