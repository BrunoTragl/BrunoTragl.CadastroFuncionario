using BrunoTragl.CadastroFuncionario.Domain.Model;
using BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Model;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Helpers
{
    public static class HabilidadeHelpers
    {
        public static Habilidade DePara(Habilidade entity, Habilidade habilidadeExterno)
        {
            try
            {
                entity.Nome = habilidadeExterno.Nome;
                return entity;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static HabilidadeModel DePara(Habilidade entity)
        {
            try
            {
                HabilidadeModel model = new HabilidadeModel();
                model.Id = entity.ID;
                model.Nome = entity.Nome;
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<HabilidadeModel> ListDePara(IEnumerable<Habilidade> entity)
        {
            try
            {
                List<HabilidadeModel> model = new List<HabilidadeModel>();
                //model.Id = entity.ID;
                //model.Nome = entity.Nome;
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static IEnumerable<Habilidade> RemoverHabilidadesFuncionario(Funcionario entity, Funcionario funcionarioExterno)
        {
            List<Habilidade> removerHabilidades = new List<Habilidade>();
            entity.Habilidades.ForEach((habilidade) =>
            {
                if (!funcionarioExterno.Habilidades.Any(h => h.Nome == habilidade.Nome))
                    removerHabilidades.Add(habilidade);
            });

            removerHabilidades.ForEach((habilidade) => entity.Habilidades.Remove(habilidade));

            return removerHabilidades;
        }
        public static IEnumerable<Habilidade> AdicionarHabilidadesFuncionario(Funcionario entity, Funcionario funcionarioExterno)
        {
            IList<Habilidade> novasHabilidades = new List<Habilidade>();
            funcionarioExterno.Habilidades.ForEach((habilidade) =>
            {
                if (!entity.Habilidades.Any(h => h.Nome == habilidade.Nome))
                {
                    novasHabilidades.Add(new Habilidade
                    {
                        FuncionarioID = entity.ID,
                        Nome = habilidade.Nome
                    });

                    entity.Habilidades.Add(new Habilidade
                    {
                        Nome = habilidade.Nome
                    });
                    //novasHabilidades = true;
                }
            });
            return novasHabilidades;
        }
        public static bool RequestValido(Habilidade habilidade, out string campo)
        {
            campo = "Id";
            if (string.IsNullOrEmpty(Helper.BuscarValorCampo(habilidade, campo)))
                return false;

            campo = "Nome";
            if (string.IsNullOrEmpty(Helper.BuscarValorCampo(habilidade, campo)))
                return false;

            return true; 
        }
        public static HabilidadePagedModel Paged(IEnumerable<Habilidade> habilidades, int count, int total, int page, int pageSize)
        {
            try
            {
                HabilidadePagedModel paged = new HabilidadePagedModel();
                paged.PagedData = Helper.GetPaged(count, total, page, pageSize);
                List<HabilidadeModel> habilidadesModel = new List<HabilidadeModel>();
                habilidades.ForEach((h) =>
                {
                    habilidadesModel.Add(new HabilidadeModel
                    {
                        Id = h.ID,
                        Nome = h.Nome
                    });
                });
                paged.Data = habilidadesModel;
                return paged;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}