using BrunoTragl.CadastroFuncionario.Business.Service.Configuration;
using BrunoTragl.CadastroFuncionario.Business.Service.Interfaces;
using BrunoTragl.CadastroFuncionario.Domain.Model.Services;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace BrunoTragl.CadastroFuncionario.Business.Service
{
    public class HabilidadeHttpContext : IHabilidadeHttpContext
    {
        public Habilidade Get(int id)
        {
            try
            {
                using (HttpClient client = HttpContext.GetHttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(APIConfigurations.UrlHabilidade(id)).Result)
                    {
                        if (response.IsSuccessStatusCode)
                            return JsonConvert.DeserializeObject<Habilidade>(response.Content.ReadAsStringAsync().Result);
                    }
                }

                throw new Exception($"Ocorreu um erro ao buscar a habilidade com ID {id}.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public HabilidadePaged Get(int funcionarioId, int pageSize, int page)
        {
            try
            {
                using (HttpClient client = HttpContext.GetHttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(APIConfigurations.UrlHabilidades(funcionarioId, pageSize, page)).Result)
                    {
                        if (response.IsSuccessStatusCode)
                            return JsonConvert.DeserializeObject<HabilidadePaged>(response.Content.ReadAsStringAsync().Result);
                    }
                }

                throw new Exception($"Ocorreu um erro ao buscar as habilidades do funcionário com ID {funcionarioId}.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Habilidade Patch(int id, Habilidade habilidade)
        {
            try
            {
                using (HttpClient client = HttpContext.GetHttpClient())
                {
                    string jsonData = JsonConvert.SerializeObject(habilidade);
                    HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), APIConfigurations.UrlHabilidade(id))
                    {
                        Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
                    };

                    using (HttpResponseMessage response = client.SendAsync(request).Result)
                    {
                        if (response.IsSuccessStatusCode)
                            return JsonConvert.DeserializeObject<Habilidade>(response.Content.ReadAsStringAsync().Result);
                    }
                }

                throw new Exception($"Ocorreu um erro ao atualizar a habilidade com ID {id}.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Habilidade Post(Habilidade habilidade)
        {
            try
            {
                using (HttpClient client = HttpContext.GetHttpClient())
                {
                    string jsonData = JsonConvert.SerializeObject(habilidade);
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = client.PostAsync(APIConfigurations.UrlHabilidade(), content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                            return JsonConvert.DeserializeObject<Habilidade>(response.Content.ReadAsStringAsync().Result);
                    }
                }

                throw new Exception($"Ocorreu um erro ao criar a habilidade.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Habilidade Put(int id, Habilidade habilidade)
        {
            try
            {
                using (HttpClient client = HttpContext.GetHttpClient())
                {
                    string jsonData = JsonConvert.SerializeObject(habilidade);
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = client.PutAsync(APIConfigurations.UrlHabilidade(id), content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                            return JsonConvert.DeserializeObject<Habilidade>(response.Content.ReadAsStringAsync().Result);
                    }
                }

                throw new Exception($"Ocorreu um erro ao atualizar a habilidade com ID {id}.");
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
                    using (HttpResponseMessage response = client.DeleteAsync(APIConfigurations.UrlHabilidade(id)).Result)
                    {
                        if (response.IsSuccessStatusCode)
                            return "OK";
                    }
                }

                throw new Exception($"Ocorreu um erro ao excluir a habilidade com ID {id}.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
