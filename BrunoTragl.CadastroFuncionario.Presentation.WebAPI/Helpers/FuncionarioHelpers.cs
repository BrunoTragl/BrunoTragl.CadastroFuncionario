using BrunoTragl.CadastroFuncionario.Domain.Model;
using BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Model;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Injection;

namespace BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Helpers
{
    public static class FuncionarioHelpers
    {
        public static Funcionario DePara(Funcionario entity, Funcionario funcionarioExterno)
        {
            try
            {
                entity.Ativo = funcionarioExterno.Ativo;
                entity.DataNascimento = funcionarioExterno.DataNascimento;
                entity.Email = funcionarioExterno.Email;
                entity.Nome = funcionarioExterno.Nome;
                entity.Sexo = funcionarioExterno.Sexo;
                entity.Sobrenome = funcionarioExterno.Sobrenome;
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static FuncionarioModel DePara(Funcionario entity)
        {
            try
            {
                FuncionarioModel model = new FuncionarioModel();
                model.Id = entity.ID;
                model.Ativo = entity.Ativo;
                model.DataNascimento = entity.DataNascimento;
                model.Email = entity.Email;
                var habilidadeModel = new List<HabilidadeModel>();
                entity.Habilidades.ForEach((habilidade) =>
                {
                    habilidadeModel.Add(new HabilidadeModel 
                    { 
                        Id = habilidade.ID, 
                        Nome = habilidade.Nome 
                    });
                });
                model.Habilidades = habilidadeModel;
                model.Nome = entity.Nome;
                model.Sexo = entity.Sexo;
                model.Sobrenome = entity.Sobrenome;
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool RequestValido(Funcionario funcionario, out string campo)
        {
            campo = "Nome";
            if (string.IsNullOrEmpty(Helper.BuscarValorCampo(funcionario, campo)))
                return false;

            campo = "Email";
            if (string.IsNullOrEmpty(Helper.BuscarValorCampo(funcionario, campo)))
                return false;

            campo = "DataNascimento";
            if (string.IsNullOrEmpty(Helper.BuscarValorCampo(funcionario, campo)))
                return false;

            campo = "Habilidades";
            if (string.IsNullOrEmpty(Helper.BuscarValorCampo(funcionario, campo)))
                return false;

            return true;
        }
        public static FuncionarioPagedModel Paged(IEnumerable<Funcionario> funcionarios, int total, int page, int pageSize)
        {
            FuncionarioPagedModel paged = new FuncionarioPagedModel();
            List<FuncionarioModel> funcionariosModel = new List<FuncionarioModel>();
            funcionarios.ForEach((f) =>
            {
                List<HabilidadeModel> habilidades = new List<HabilidadeModel>();
                f.Habilidades.ForEach((h) =>
                {
                    habilidades.Add(new HabilidadeModel
                    {
                        Id = h.ID,
                        Nome = h.Nome
                    });
                });
                funcionariosModel.Add(new FuncionarioModel
                {
                    Ativo = f.Ativo,
                    DataNascimento = f.DataNascimento,
                    Email = f.Email,
                    Habilidades = habilidades,
                    Id = f.ID,
                    Nome = f.Nome,
                    Sexo = f.Sexo,
                    Sobrenome = f.Sobrenome
                });
            });
            paged.Data = funcionariosModel;
            paged.PagedData = Helper.GetPaged(funcionarios.Count(), total, page, pageSize);
            return paged;
        }
    }
}