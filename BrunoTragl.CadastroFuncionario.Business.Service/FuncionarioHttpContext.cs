using BrunoTragl.CadastroFuncionario.Business.Service.Configuration;
using BrunoTragl.CadastroFuncionario.Business.Service.Interfaces;
using BrunoTragl.CadastroFuncionario.Domain.Model.Services;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace BrunoTragl.CadastroFuncionario.Business.Service
{
    public class FuncionarioHttpContext : IFuncionarioHttpContext
    {
        public Funcionario Get(int id)
        {
            try
            {
                using(HttpClient client = HttpContext.GetHttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(APIConfigurations.UrlFuncionario(id)).Result)
                    {
                        if (response.IsSuccessStatusCode)
                            return JsonConvert.DeserializeObject<Funcionario>(response.Content.ReadAsStringAsync().Result);
                    }
                }

                throw new Exception($"Ocorreu um erro ao buscar o funcionário com ID {id}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FuncionarioPaged Get(int pageSize, int page)
        {
            try
            {
                using (HttpClient client = HttpContext.GetHttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(APIConfigurations.UrlFuncionarios(pageSize, page)).Result)
                    {
                        if (response.IsSuccessStatusCode)
                            return JsonConvert.DeserializeObject<FuncionarioPaged>(response.Content.ReadAsStringAsync().Result);
                    }
                }

                throw new Exception($"Ocorreu um erro ao buscar funcionários.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Funcionario Post(Funcionario funcionario)
        {
            try
            {
                using (HttpClient client = HttpContext.GetHttpClient())
                {
                    string jsonData = JsonConvert.SerializeObject(funcionario);
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = client.PostAsync(APIConfigurations.UrlFuncionario(), content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                            return JsonConvert.DeserializeObject<Funcionario>(response.Content.ReadAsStringAsync().Result);
                    }
                }

                throw new Exception($"Ocorreu um erro ao criar um funcionário.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FuncionarioSimples Put(int id, FuncionarioSimples funcionario)
        {
            try
            {
                using (HttpClient client = HttpContext.GetHttpClient())
                {
                    string jsonData = JsonConvert.SerializeObject(funcionario);
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = client.PutAsync(APIConfigurations.UrlFuncionario(id), content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                            return JsonConvert.DeserializeObject<FuncionarioSimples>(response.Content.ReadAsStringAsync().Result);
                    }
                }

                throw new Exception($"Ocorreu um erro ao atualizar o funcionário com ID {id}.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FuncionarioSimples Patch(int id, FuncionarioAtivacao funcionario)
        {
            try
            {
                using (HttpClient client = HttpContext.GetHttpClient())
                {
                    string jsonData = JsonConvert.SerializeObject(funcionario);
                    HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), APIConfigurations.UrlFuncionario(id))
                    {
                        Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
                    };
                    using (HttpResponseMessage response = client.SendAsync(request).Result)
                    {
                        if (response.IsSuccessStatusCode)
                            return JsonConvert.DeserializeObject<FuncionarioSimples>(response.Content.ReadAsStringAsync().Result);
                    }
                }

                throw new Exception($"Ocorreu um erro ao atualizar o funcionário com ID {id}.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
