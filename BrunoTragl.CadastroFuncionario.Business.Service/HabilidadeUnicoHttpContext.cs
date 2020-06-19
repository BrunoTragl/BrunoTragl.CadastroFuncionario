using BrunoTragl.CadastroFuncionario.Business.Service.Configuration;
using BrunoTragl.CadastroFuncionario.Business.Service.Interfaces;
using BrunoTragl.CadastroFuncionario.Domain.Model.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BrunoTragl.CadastroFuncionario.Business.Service
{
    public class HabilidadeUnicoHttpContext : IHabilidadeUnicoHttpContext
    {
        public IEnumerable<HabilidadeUnico> Get()
        {
            try
            {
                using (HttpClient client = HttpContext.GetHttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(APIConfigurations.UrlHabilidadeUnico()).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string json = response.Content.ReadAsStringAsync().Result;
                            return JsonConvert.DeserializeObject<IEnumerable<HabilidadeUnico>>(json);
                        }
                    }
                }

                throw new Exception($"Ocorreu um erro ao buscar as habilidades únicas.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public HabilidadeUnico Get(int id)
        {
            try
            {
                using (HttpClient client = HttpContext.GetHttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(APIConfigurations.UrlHabilidadeUnico(id)).Result)
                    {
                        if (response.IsSuccessStatusCode)
                            return JsonConvert.DeserializeObject<HabilidadeUnico>(response.Content.ReadAsStringAsync().Result);
                    }
                }

                throw new Exception($"Ocorreu um erro ao buscar a habilidade única com ID {id}.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public HabilidadeUnico Post(HabilidadeUnico habilidade)
        {
            try
            {
                using (HttpClient client = HttpContext.GetHttpClient())
                {
                    string jsonData = JsonConvert.SerializeObject(habilidade);
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = client.PostAsync(APIConfigurations.UrlHabilidadeUnico(), content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                            return JsonConvert.DeserializeObject<HabilidadeUnico>(response.Content.ReadAsStringAsync().Result);
                    }
                }

                throw new Exception($"Ocorreu um erro ao criar a habilidade única.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Delete(int id)
        {
            try
            {
                using (HttpClient client = HttpContext.GetHttpClient())
                {
                    using (HttpResponseMessage response = client.DeleteAsync(APIConfigurations.UrlHabilidadeUnico(id)).Result)
                    {
                        if (response.IsSuccessStatusCode)
                            return "OK";
                    }
                }

                throw new Exception($"Ocorreu um erro ao excluir a habilidade única com ID {id}.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
