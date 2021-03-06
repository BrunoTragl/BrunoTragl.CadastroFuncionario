﻿using BrunoTragl.CadastroFuncionario.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BrunoTragl.CadastroFuncionario.Services.Application.Interfaces
{
    public interface IHabilidadeUnicoService
    {
        HabilidadeUnico Add(HabilidadeUnico habilidadeUnico);
        void Edit(HabilidadeUnico habilidadeUnico);
        HabilidadeUnico Find(int id);
        IEnumerable<HabilidadeUnico> All();
        IEnumerable<HabilidadeUnico> Search(Expression<Func<HabilidadeUnico, bool>> exp);
        void Delete(HabilidadeUnico habilidadeUnico);
    }
}
