using BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Helpers
{
    public static class Helper
    {
        public static string BuscarValorCampo<T>(T tipo, string campo)
            where T : class
        {
            Type type = tipo.GetType();
            if (type != null)
            {
                PropertyInfo prop = type.GetProperty(campo);
                if (prop != null)
                {
                    object value = prop.GetValue(tipo);
                    if (value != null)
                    {
                        return value.ToString();
                    }
                }
            }
            return null;
        }

        public static Paged GetPaged(int count, int total, int page, int pageSize)
        {
            Paged paged = new Paged();
            paged.TotalData = total;

            if (total == 0)
            {
                paged.PageSize = 0;
                paged.Page = 0;
                paged.Count = 0;
                paged.TotalPages = 0;
                return paged;
            }

            paged.PageSize = pageSize > 0 ? pageSize : 30;
            paged.Page = page > 0 ? page : 1;
            paged.Count = count;

            int totalPages = total / paged.PageSize;
            if ((total % paged.PageSize) > 0)
                totalPages++;

            paged.TotalPages = totalPages;

            return paged;
        }
    }
}